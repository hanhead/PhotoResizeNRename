using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace PhotoResizeNRename
{
    public partial class frmPhotoResizeNRename : Form
    {
        public frmPhotoResizeNRename()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogForOriginalImageFolder.ShowDialog();
            if (result == DialogResult.OK)
            {

                string folderPath = folderBrowserDialogForOriginalImageFolder.SelectedPath;
                textBox1.Text = folderPath + "\\convetedimages\\";
                string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file => file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".gif") || file.ToLower().EndsWith(".bmp"))
                    .ToArray();
                int i = 0;
                imageList1.Images.Clear();
                listView1.Items.Clear();
                foreach (string imageFile in imageFiles)
                {
                    Image image = Image.FromFile(imageFile);

                    imageList1.Images.Add(image);
                    listView1.Items.Add(new ListViewItem(Path.GetFileName(imageFile), i));
                    i++;
                }
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogConvertedImageFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialogConvertedImageFolder.SelectedPath;
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string folderPath = folderBrowserDialogForOriginalImageFolder.SelectedPath;
            if (string.IsNullOrEmpty(folderPath)) { MessageBox.Show("Please select target folder"); return; }
            textBox1.Text = folderPath + "\\convetedimages\\";
            string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                .Where(file => file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".gif") || file.ToLower().EndsWith(".bmp"))
                .ToArray();
            if (imageFiles.Length == 0)
            {
                MessageBox.Show("No image file(s)");
                return;
            }
            int seq = 1;
            string convertedImageFileFolder = Path.GetFullPath(textBox1.Text);
            progressBar1.Value = 0;
            progressBar1.Maximum = imageFiles.Count();
            foreach (string imageFile in imageFiles)
            {
                if (Directory.Exists(convertedImageFileFolder) == false)
                {
                    Directory.CreateDirectory(convertedImageFileFolder);
                }
                string fileName = Path.GetFileName(imageFile);
                string newFileName = textBox4.Text.Replace("{sequence number}", seq.ToString()).Replace("{original file name}", fileName.Substring(0, fileName.LastIndexOf("."))) + ".jpg";
                new ImageResizer().Resize2FileByRecommendJPEG(int.Parse(textBox2.Text), int.Parse(textBox3.Text), imageFile, Path.Combine(convertedImageFileFolder, newFileName));
                progressBar1.Value = seq;
                seq++;
            }
            MessageBox.Show("Successfully converted!!");
            Process.Start("explorer.exe", convertedImageFileFolder);
        }
    }
}