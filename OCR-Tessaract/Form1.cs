using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace OCR_Tessaract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    var img = new Bitmap(openFile.FileName);
                    var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                    var page = ocr.Process(img);
                    textBox1.Text = page.GetText();
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
