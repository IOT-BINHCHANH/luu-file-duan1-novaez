using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using ZXing.Common;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace BarcodeLibTest
{
    public partial class frmMain : Form
    {
        private readonly IBarcodeReader barcodeReader;
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        private string configFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
        private static IDictionary<string, string> listOfKeysNeedToChange = new Dictionary<string, string>();
        string bar;
        
        public frmMain()
        {
            InitializeComponent();
            barcodeReader = new BarcodeReader();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(configFilePath))
            {
                string[] listLines = File.ReadAllLines(configFilePath);
                foreach (string s in listLines)
                {
                    string[] items = s.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (items != null && items.Length == 2)
                    {
                        listOfKeysNeedToChange.Add(items[0], items[1]);
                    }
                }
            } 
            else
            {
                if (MessageBox.Show("File dữ liệu vào không tồn tại", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    File.CreateText(configFilePath);
                }

            } 
            this.ActiveControl = txtData;
            txtData.Focus();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void convertBarcodeFromString(string str)
        {
            int W = Convert.ToInt32(203);
            int H = Convert.ToInt32(35);
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.CODE93;
            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;
                    //(RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone".ToString(), true);  // dau can phai ranh vay dau
                    BarcodeLib.LabelPositions labelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                    //(BarcodeLib.LabelPositions)Enum.Parse(typeof(BarcodeLib.LabelPositions), "BottomCenter".ToString(), true);
                    barcode.Image = b.Encode(type, str, Color.FromArgb(0, 0, 0),
                        Color.FromArgb(255, 255, 255), W, H, 
                        BarcodeLib.AlignmentPositions.CENTER, rotateFlipType, false, labelPosition);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 50,
                    Width = 50,
                    Margin = 0
                }
            };
            using (var bitmap = barcodeWriter.Write(str))
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    var image = Image.FromStream(stream);
                    pictureBox.Image = image;
                }
            }
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();
            txtData.Clear();
        }
     
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Single yPos = 0;
            Single leftMargin = e.MarginBounds.Left;
            Single topMargin = e.MarginBounds.Top;
            Image img = pictureBox.Image;
            Point loc = new Point(5, 50);
            Image img1 = barcode.Image;
            Point loc1 = new Point(5, 15);
            using (Font printFont = new Font("Tahoma", 8.0f,FontStyle.Bold))
            {
                e.Graphics.DrawImage(img, loc);
                e.Graphics.DrawImage(img1, loc1);
                e.Graphics.DrawString(bar, new Font("Tahoma", 8.0f, FontStyle.Bold), Brushes.Black, 60, 55, new StringFormat());
                e.Graphics.DrawString("Name:", new Font("Tahoma", 8.0f, FontStyle.Bold), Brushes.Black, 90, 80, new StringFormat());
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), printFont, Brushes.Black, 60, 70, new StringFormat());
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            convertBarcodeFromString(txtData.Text.Trim());

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            // cai nay ak
            if (keyData == Keys.Up||keyData == Keys.Down|| keyData == Keys.Left|| keyData == Keys.Right || keyData == Keys.Space)
            {
                string validStr = txtData.Text.Trim();
                if (listOfKeysNeedToChange != null && listOfKeysNeedToChange.ContainsKey(validStr))
                {
                    validStr = listOfKeysNeedToChange[validStr];
                    if (validStr.Length <= 18) //    string tmpStr = validStr.Substring(0, 4);
                    {
                        bar= validStr;
                        label1.Text = validStr;
                        label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        convertBarcodeFromString(validStr);
                    }
                }
                else
                {
                    if (MessageBox.Show("Dữ liệu vào dài vượt ngưỡng 18 kí tự", "Thông báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        File.CreateText(configFilePath);
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void enterInTextbox(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                string validStr = txtData.Text.Trim();
                if (listOfKeysNeedToChange != null && listOfKeysNeedToChange.ContainsKey(validStr))
                {
                    validStr = listOfKeysNeedToChange[validStr];
                }
                if (validStr.Length <= 18) //    string tmpStr = validStr.Substring(0, 4);
                {
                    bar = validStr;
                    label1.Text = validStr;
                    label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    convertBarcodeFromString(validStr);
                }
                else
                {
                    if (MessageBox.Show("Dữ liệu vào dài vượt ngưỡng 18 kí tự", "Thông báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        File.CreateText(configFilePath);
                    }
                }     
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }//class
}//namespace