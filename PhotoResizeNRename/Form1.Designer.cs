namespace PhotoResizeNRename
{
    partial class frmPhotoResizeNRename
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhotoResizeNRename));
            folderBrowserDialogForOriginalImageFolder = new FolderBrowserDialog();
            button1 = new Button();
            listView1 = new ListView();
            imageList1 = new ImageList(components);
            textBox1 = new TextBox();
            button2 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label3 = new Label();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            folderBrowserDialogConvertedImageFolder = new FolderBrowserDialog();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(341, 31);
            button1.TabIndex = 0;
            button1.Text = "Select Original Image Folder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            tableLayoutPanel1.SetColumnSpan(listView1, 2);
            listView1.Dock = DockStyle.Fill;
            listView1.LargeImageList = imageList1;
            listView1.Location = new Point(3, 40);
            listView1.Name = "listView1";
            listView1.Size = new Size(1149, 497);
            listView1.SmallImageList = imageList1;
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(50, 50);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 543);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(956, 23);
            textBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(965, 543);
            button2.Name = "button2";
            button2.Size = new Size(140, 25);
            button2.TabIndex = 3;
            button2.Text = "Change Folder";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 193F));
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(button2, 1, 2);
            tableLayoutPanel1.Controls.Add(listView1, 0, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.851852F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.14815F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tableLayoutPanel1.Size = new Size(1155, 635);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox2, 1, 0);
            tableLayoutPanel2.Controls.Add(textBox3, 2, 0);
            tableLayoutPanel2.Controls.Add(textBox4, 3, 0);
            tableLayoutPanel2.Controls.Add(label3, 3, 1);
            tableLayoutPanel2.Controls.Add(button3, 4, 0);
            tableLayoutPanel2.Controls.Add(progressBar1, 0, 1);
            tableLayoutPanel2.Location = new Point(3, 574);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(956, 49);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 0;
            label1.Text = "Size";
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(103, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(144, 23);
            textBox2.TabIndex = 1;
            textBox2.Text = "1024";
            textBox2.KeyPress += NumericTextBox_KeyPress;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(253, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(144, 23);
            textBox3.TabIndex = 2;
            textBox3.Text = "1024";
            textBox3.KeyPress += NumericTextBox_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(403, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(288, 23);
            textBox4.TabIndex = 3;
            textBox4.Text = "newimagename_{sequence number}";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(403, 24);
            label3.Name = "label3";
            label3.Size = new Size(224, 15);
            label3.TabIndex = 5;
            label3.Text = "* {original file name}, {sequence number}";
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(697, 3);
            button3.Name = "button3";
            tableLayoutPanel2.SetRowSpan(button3, 2);
            button3.Size = new Size(256, 43);
            button3.TabIndex = 6;
            button3.Text = "Convert !!";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            tableLayoutPanel2.SetColumnSpan(progressBar1, 3);
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(3, 27);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(394, 19);
            progressBar1.TabIndex = 7;
            // 
            // frmPhotoResizeNRename
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 635);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPhotoResizeNRename";
            Text = "ImageResizeNRename";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialogForOriginalImageFolder;
        private Button button1;
        private ListView listView1;
        private ImageList imageList1;
        private TextBox textBox1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
        private FolderBrowserDialog folderBrowserDialogConvertedImageFolder;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label3;
        private Button button3;
        private ProgressBar progressBar1;
    }
}