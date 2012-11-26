using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageResize
{
    public partial class frmResize : Form
    {
        public frmResize()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try{
            String location = txtImg.Text;
            int height = Convert.ToInt32( txtHeight.Text);
            int width = Convert.ToInt32(txtWidth.Text);
            String thumb = "thumb";
            if (Directory.Exists(location))
            {
                String thumbLocation = Path.Combine(location, thumb); 
                if (!Directory.Exists(thumbLocation))
                {
                    Directory.CreateDirectory(thumbLocation);
                }

                foreach (String filename in Directory.GetFiles(location, "*.jpg"))
                {
                    String newFile = Path.Combine(thumbLocation,Path.GetFileName(filename));
                    ImageResize.ResizeImage(filename, newFile, height, width);
                }
            }
            else
            {
                MessageBox.Show("Folder does not exist!","Error");
            }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose the folder where we will search for JPEG images";
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtImg.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
