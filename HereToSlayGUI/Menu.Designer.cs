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
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)previewImg).BeginInit();
            SuspendLayout();
            // 
            // RENDER
            // 
            RENDER.Location = new Point(92, 625);
            RENDER.Name = "RENDER";
            RENDER.Size = new Size(185, 74);
            RENDER.TabIndex = 0;
            RENDER.Text = "RENDER";
            RENDER.UseVisualStyleBackColor = true;
            RENDER.Click += Button_Press;
            // 
            // language
            // 
            language.DropDownStyle = ComboBoxStyle.DropDownList;
            language.FormattingEnabled = true;
            language.Location = new Point(342, 675);
            language.Name = "language";
            language.Size = new Size(66, 23);
            language.TabIndex = 1;
            language.SelectedIndexChanged += language_SelectedIndexChanged;
            language.SelectedIndexChanged += renderPreview;
            // 
            // leaderNameText
            // 
            leaderNameText.Location = new Point(127, 167);
            leaderNameText.Name = "leaderNameText";
            leaderNameText.Size = new Size(150, 23);
            leaderNameText.TabIndex = 2;
            leaderNameText.TextChanged += renderPreview;
            // 
            // labelLeader
            // 
            labelLeader.Location = new Point(-54, 167);
            labelLeader.Name = "labelLeader";
            labelLeader.Size = new Size(175, 20);
            labelLeader.TabIndex = 4;
            labelLeader.Text = "Leader Name";
            labelLeader.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelDescription
            // 
            labelDescription.Location = new Point(-3, 349);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(100, 20);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description";
            labelDescription.TextAlign = ContentAlignment.MiddleRight;
            // 
            // logo
            // 
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
            chosenClass.DropDownStyle = ComboBoxStyle.DropDownList;
            chosenClass.FormattingEnabled = true;
            chosenClass.Location = new Point(149, 193);
            chosenClass.Name = "chosenClass";
            chosenClass.Size = new Size(100, 23);
            chosenClass.TabIndex = 7;
            chosenClass.SelectedIndexChanged += renderPreview;
            // 
            // labelClass
            // 
            labelClass.Location = new Point(21, 193);
            labelClass.Name = "labelClass";
            labelClass.Size = new Size(100, 20);
            labelClass.TabIndex = 9;
            labelClass.Text = "Leader Class";
            labelClass.TextAlign = ContentAlignment.MiddleRight;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectImg
            // 
            selectImg.Location = new Point(252, 255);
            selectImg.Name = "selectImg";
            selectImg.Size = new Size(25, 25);
            selectImg.TabIndex = 10;
            selectImg.Text = "...";
            selectImg.UseVisualStyleBackColor = true;
            selectImg.Click += selectImg_Click;
            // 
            // selectImgText
            // 
            selectImgText.Location = new Point(149, 255);
            selectImgText.Name = "selectImgText";
            selectImgText.Size = new Size(100, 23);
            selectImgText.TabIndex = 11;
            selectImgText.TextChanged += renderPreview;
            // 
            // labelImg
            // 
            labelImg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelImg.Location = new Point(43, 255);
            labelImg.Name = "labelImg";
            labelImg.RightToLeft = RightToLeft.No;
            labelImg.Size = new Size(100, 20);
            labelImg.TabIndex = 12;
            labelImg.Text = "Leader Image";
            labelImg.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gradient
            // 
            gradient.AutoSize = true;
            gradient.Location = new Point(137, 439);
            gradient.Name = "gradient";
            gradient.Size = new Size(124, 19);
            gradient.TabIndex = 13;
            gradient.Text = "Add back Gradient";
            gradient.UseVisualStyleBackColor = true;
            gradient.CheckedChanged += renderPreview;
            // 
            // leaderWhite
            // 
            leaderWhite.AutoSize = true;
            leaderWhite.Location = new Point(137, 414);
            leaderWhite.Name = "leaderWhite";
            leaderWhite.Size = new Size(150, 19);
            leaderWhite.TabIndex = 14;
            leaderWhite.Text = "Make Leader text White";
            leaderWhite.UseVisualStyleBackColor = true;
            leaderWhite.CheckedChanged += renderPreview;
            // 
            // descriptionText
            // 
            descriptionText.Location = new Point(109, 319);
            descriptionText.Multiline = true;
            descriptionText.Name = "descriptionText";
            descriptionText.Size = new Size(185, 78);
            descriptionText.TabIndex = 15;
            descriptionText.TextChanged += renderPreview;
            // 
            // previewImg
            // 
            previewImg.BackColor = SystemColors.Control;
            previewImg.Dock = DockStyle.Right;
            previewImg.Location = new Point(414, 0);
            previewImg.Name = "previewImg";
            previewImg.Size = new Size(414, 711);
            previewImg.SizeMode = PictureBoxSizeMode.StretchImage;
            previewImg.TabIndex = 16;
            previewImg.TabStop = false;
            // 
            // Menu
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(828, 711);
            Controls.Add(descriptionText);
            Controls.Add(leaderWhite);
            Controls.Add(gradient);
            Controls.Add(labelImg);
            Controls.Add(selectImgText);
            Controls.Add(selectImg);
            Controls.Add(labelClass);
            Controls.Add(chosenClass);
            Controls.Add(logo);
            Controls.Add(labelDescription);
            Controls.Add(labelLeader);
            Controls.Add(leaderNameText);
            Controls.Add(language);
            Controls.Add(RENDER);
            Controls.Add(previewImg);
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
    }
}