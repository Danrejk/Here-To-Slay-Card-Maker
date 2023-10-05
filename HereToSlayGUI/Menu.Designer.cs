namespace HereToSlayGUI
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            RENDER = new Button();
            language = new ComboBox();
            leaderNameText = new TextBox();
            labelLeader = new Label();
            labelDescription = new Label();
            logo = new PictureBox();
            chosenClass = new ComboBox();
            labelClass = new Label();
            openFileDialog1 = new OpenFileDialog();
            selectImg = new Button();
            selectImgText = new TextBox();
            labelImg = new Label();
            gradient = new CheckBox();
            leaderWhite = new CheckBox();
            descriptionText = new TextBox();
            previewImg = new PictureBox();
            gitLabel2 = new LinkLabel();
            gitLabel1 = new LinkLabel();
            wordSplitting = new CheckBox();
            sourceExportText = new TextBox();
            sourceExport = new Button();
            label1 = new Label();
            classIcons = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)previewImg).BeginInit();
            SuspendLayout();
            // 
            // RENDER
            // 
            RENDER.BackColor = Color.FromArgb(245, 240, 232);
            RENDER.Cursor = Cursors.Hand;
            RENDER.FlatAppearance.BorderColor = Color.FromArgb(118, 110, 109);
            RENDER.FlatStyle = FlatStyle.Flat;
            RENDER.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            RENDER.Location = new Point(111, 464);
            RENDER.Name = "RENDER";
            RENDER.Size = new Size(185, 74);
            RENDER.TabIndex = 0;
            RENDER.Text = "RENDER";
            RENDER.UseVisualStyleBackColor = false;
            RENDER.Click += Button_Press;
            // 
            // language
            // 
            language.BackColor = Color.FromArgb(245, 240, 232);
            language.DropDownStyle = ComboBoxStyle.DropDownList;
            language.FlatStyle = FlatStyle.Flat;
            language.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            language.FormattingEnabled = true;
            language.Location = new Point(342, 12);
            language.Name = "language";
            language.Size = new Size(66, 25);
            language.TabIndex = 1;
            language.SelectedIndexChanged += language_SelectedIndexChanged;
            // 
            // leaderNameText
            // 
            leaderNameText.BackColor = Color.FromArgb(245, 240, 232);
            leaderNameText.BorderStyle = BorderStyle.None;
            leaderNameText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            leaderNameText.Location = new Point(111, 176);
            leaderNameText.Margin = new Padding(0);
            leaderNameText.Name = "leaderNameText";
            leaderNameText.Size = new Size(185, 22);
            leaderNameText.TabIndex = 2;
            leaderNameText.TextChanged += renderPreview;
            // 
            // labelLeader
            // 
            labelLeader.BackColor = Color.Transparent;
            labelLeader.FlatStyle = FlatStyle.Flat;
            labelLeader.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelLeader.ForeColor = Color.FromArgb(245, 240, 232);
            labelLeader.ImageAlign = ContentAlignment.BottomLeft;
            labelLeader.Location = new Point(107, 156);
            labelLeader.Margin = new Padding(0);
            labelLeader.Name = "labelLeader";
            labelLeader.Size = new Size(150, 20);
            labelLeader.TabIndex = 4;
            labelLeader.Text = "Name";
            labelLeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // labelDescription
            // 
            labelDescription.BackColor = Color.Transparent;
            labelDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescription.ForeColor = Color.FromArgb(245, 240, 232);
            labelDescription.Location = new Point(108, 345);
            labelDescription.Margin = new Padding(0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(100, 20);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description";
            labelDescription.TextAlign = ContentAlignment.BottomLeft;
            // 
            // logo
            // 
            logo.BackColor = Color.Transparent;
            logo.Dock = DockStyle.Top;
            logo.Image = Properties.Resources.Logo0;
            logo.Location = new Point(0, 0);
            logo.Name = "logo";
            logo.Size = new Size(414, 150);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 6;
            logo.TabStop = false;
            // 
            // chosenClass
            // 
            chosenClass.BackColor = Color.FromArgb(245, 240, 232);
            chosenClass.DropDownStyle = ComboBoxStyle.DropDownList;
            chosenClass.FlatStyle = FlatStyle.Flat;
            chosenClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chosenClass.FormattingEnabled = true;
            chosenClass.Location = new Point(111, 226);
            chosenClass.Margin = new Padding(0);
            chosenClass.Name = "chosenClass";
            chosenClass.Size = new Size(100, 25);
            chosenClass.TabIndex = 7;
            chosenClass.SelectedIndexChanged += chosenClass_SelectedIndexChanged;
            chosenClass.Click += chosenClass_Click;
            // 
            // labelClass
            // 
            labelClass.BackColor = Color.Transparent;
            labelClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelClass.ForeColor = Color.FromArgb(245, 240, 232);
            labelClass.Location = new Point(107, 206);
            labelClass.Margin = new Padding(0);
            labelClass.Name = "labelClass";
            labelClass.Size = new Size(100, 20);
            labelClass.TabIndex = 9;
            labelClass.Text = "Class";
            labelClass.TextAlign = ContentAlignment.BottomLeft;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectImg
            // 
            selectImg.BackColor = SystemColors.Control;
            selectImg.Cursor = Cursors.Hand;
            selectImg.FlatAppearance.BorderColor = Color.White;
            selectImg.FlatStyle = FlatStyle.Flat;
            selectImg.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectImg.Location = new Point(269, 280);
            selectImg.Margin = new Padding(0);
            selectImg.Name = "selectImg";
            selectImg.Size = new Size(24, 22);
            selectImg.TabIndex = 10;
            selectImg.Text = "⋯";
            selectImg.TextAlign = ContentAlignment.TopCenter;
            selectImg.UseVisualStyleBackColor = false;
            selectImg.Click += selectImg_Click;
            // 
            // selectImgText
            // 
            selectImgText.BackColor = Color.FromArgb(245, 240, 232);
            selectImgText.BorderStyle = BorderStyle.None;
            selectImgText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectImgText.Location = new Point(111, 280);
            selectImgText.Margin = new Padding(0);
            selectImgText.Multiline = true;
            selectImgText.Name = "selectImgText";
            selectImgText.Size = new Size(161, 22);
            selectImgText.TabIndex = 11;
            selectImgText.WordWrap = false;
            selectImgText.TextChanged += renderPreview;
            // 
            // labelImg
            // 
            labelImg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelImg.BackColor = Color.Transparent;
            labelImg.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelImg.ForeColor = Color.FromArgb(245, 240, 232);
            labelImg.Location = new Point(107, 260);
            labelImg.Margin = new Padding(0);
            labelImg.Name = "labelImg";
            labelImg.RightToLeft = RightToLeft.No;
            labelImg.Size = new Size(100, 20);
            labelImg.TabIndex = 12;
            labelImg.Text = "Image Source";
            labelImg.TextAlign = ContentAlignment.BottomLeft;
            // 
            // gradient
            // 
            gradient.AutoSize = true;
            gradient.BackColor = Color.Transparent;
            gradient.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            gradient.ForeColor = Color.FromArgb(245, 240, 232);
            gradient.Location = new Point(136, 544);
            gradient.Name = "gradient";
            gradient.Size = new Size(142, 23);
            gradient.TabIndex = 13;
            gradient.Text = "Add back Gradient";
            gradient.UseVisualStyleBackColor = false;
            gradient.CheckedChanged += renderPreview;
            // 
            // leaderWhite
            // 
            leaderWhite.AutoSize = true;
            leaderWhite.BackColor = Color.Transparent;
            leaderWhite.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            leaderWhite.ForeColor = Color.FromArgb(245, 240, 232);
            leaderWhite.Location = new Point(136, 569);
            leaderWhite.Name = "leaderWhite";
            leaderWhite.Size = new Size(174, 23);
            leaderWhite.TabIndex = 14;
            leaderWhite.Text = "Make Leader text White";
            leaderWhite.UseVisualStyleBackColor = false;
            leaderWhite.CheckedChanged += renderPreview;
            // 
            // descriptionText
            // 
            descriptionText.BackColor = Color.FromArgb(245, 240, 232);
            descriptionText.BorderStyle = BorderStyle.None;
            descriptionText.Location = new Point(111, 365);
            descriptionText.Margin = new Padding(0);
            descriptionText.Multiline = true;
            descriptionText.Name = "descriptionText";
            descriptionText.RightToLeft = RightToLeft.No;
            descriptionText.Size = new Size(185, 78);
            descriptionText.TabIndex = 15;
            descriptionText.TextChanged += renderPreview;
            // 
            // previewImg
            // 
            previewImg.BackColor = SystemColors.ControlLight;
            previewImg.Dock = DockStyle.Right;
            previewImg.Location = new Point(414, 0);
            previewImg.Name = "previewImg";
            previewImg.Size = new Size(414, 711);
            previewImg.SizeMode = PictureBoxSizeMode.StretchImage;
            previewImg.TabIndex = 16;
            previewImg.TabStop = false;
            // 
            // gitLabel2
            // 
            gitLabel2.AutoSize = true;
            gitLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gitLabel2.LinkColor = Color.FromArgb(220, 101, 11);
            gitLabel2.Location = new Point(0, 687);
            gitLabel2.Name = "gitLabel2";
            gitLabel2.Size = new Size(58, 15);
            gitLabel2.TabIndex = 17;
            gitLabel2.TabStop = true;
            gitLabel2.Text = "@Danrejk";
            gitLabel2.LinkClicked += linkLabel1_LinkClicked;
            // 
            // gitLabel1
            // 
            gitLabel1.AutoSize = true;
            gitLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gitLabel1.LinkColor = Color.FromArgb(220, 101, 11);
            gitLabel1.Location = new Point(0, 672);
            gitLabel1.Name = "gitLabel1";
            gitLabel1.Size = new Size(55, 15);
            gitLabel1.TabIndex = 19;
            gitLabel1.TabStop = true;
            gitLabel1.Text = "@Beukot";
            gitLabel1.LinkClicked += linkLabel2_LinkClicked;
            // 
            // wordSplitting
            // 
            wordSplitting.AutoSize = true;
            wordSplitting.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            wordSplitting.ForeColor = Color.FromArgb(245, 240, 232);
            wordSplitting.Location = new Point(136, 598);
            wordSplitting.Name = "wordSplitting";
            wordSplitting.Size = new Size(115, 23);
            wordSplitting.TabIndex = 20;
            wordSplitting.Text = "Word Splitting";
            wordSplitting.UseVisualStyleBackColor = true;
            // 
            // sourceExportText
            // 
            sourceExportText.BackColor = Color.FromArgb(245, 240, 232);
            sourceExportText.BorderStyle = BorderStyle.None;
            sourceExportText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            sourceExportText.Location = new Point(136, 651);
            sourceExportText.Margin = new Padding(0);
            sourceExportText.Multiline = true;
            sourceExportText.Name = "sourceExportText";
            sourceExportText.Size = new Size(161, 22);
            sourceExportText.TabIndex = 21;
            sourceExportText.WordWrap = false;
            // 
            // sourceExport
            // 
            sourceExport.BackColor = SystemColors.Control;
            sourceExport.Cursor = Cursors.Hand;
            sourceExport.FlatAppearance.BorderColor = Color.White;
            sourceExport.FlatStyle = FlatStyle.Flat;
            sourceExport.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            sourceExport.Location = new Point(297, 651);
            sourceExport.Margin = new Padding(0);
            sourceExport.Name = "sourceExport";
            sourceExport.Size = new Size(24, 22);
            sourceExport.TabIndex = 22;
            sourceExport.Text = "⋯";
            sourceExport.TextAlign = ContentAlignment.TopCenter;
            sourceExport.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(245, 240, 232);
            label1.Location = new Point(133, 631);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(145, 20);
            label1.TabIndex = 23;
            label1.Text = "Export Location";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // classIcons
            // 
            classIcons.ColorDepth = ColorDepth.Depth8Bit;
            classIcons.ImageStream = (ImageListStreamer)resources.GetObject("classIcons.ImageStream");
            classIcons.TransparentColor = Color.Transparent;
            classIcons.Images.SetKeyName(0, "Warrior.png");
            // 
            // Menu
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(39, 43, 52);
            BackgroundImage = Properties.Resources.gradient;
            ClientSize = new Size(828, 711);
            Controls.Add(label1);
            Controls.Add(sourceExport);
            Controls.Add(sourceExportText);
            Controls.Add(wordSplitting);
            Controls.Add(gitLabel1);
            Controls.Add(gitLabel2);
            Controls.Add(descriptionText);
            Controls.Add(leaderWhite);
            Controls.Add(gradient);
            Controls.Add(labelImg);
            Controls.Add(selectImgText);
            Controls.Add(selectImg);
            Controls.Add(labelClass);
            Controls.Add(chosenClass);
            Controls.Add(labelDescription);
            Controls.Add(leaderNameText);
            Controls.Add(language);
            Controls.Add(RENDER);
            Controls.Add(logo);
            Controls.Add(previewImg);
            Controls.Add(labelLeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Menu";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Here To Slay - Custom leader card Generator";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)previewImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RENDER;
        private ComboBox language;
        private TextBox leaderNameText;
        private Label labelLeader;
        private Label labelDescription;
        private PictureBox logo;
        private ComboBox chosenClass;
        private TextBox descriptionText;
        private Label labelClass;
        private OpenFileDialog openFileDialog1;
        private Button selectImg;
        private TextBox selectImgText;
        private Label labelImg;
        private CheckBox gradient;
        private CheckBox leaderWhite;
        private PictureBox previewImg;
        private LinkLabel gitLabel2;
        private LinkLabel gitLabel1;
        private CheckBox wordSplitting;
        private TextBox sourceExportText;
        private Button sourceExport;
        private Label label1;
        private ImageList classIcons;
    }
}