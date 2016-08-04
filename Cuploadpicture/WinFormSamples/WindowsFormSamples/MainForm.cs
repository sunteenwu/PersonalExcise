using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormSamples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var selectedImg = Image.FromFile(dialog.FileName);
                if (selectedImg != null)
                {
                    MessageBox.Show(this, string.Format("DpiX：{0}，DpiY：{1}",
                        selectedImg.HorizontalResolution
                        , selectedImg.VerticalResolution), "Image Property", MessageBoxButtons.OK);
                }
            }
        }
    }
}
