namespace HereToSlay
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
            RENDER = new Button();
            leaderNameText = new TextBox();
            labelLeader = new Label();
            labelDescription = new Label();
            logo = new PictureBox();
            chosenClass = new ComboBox();
            labelClass = new Label();
            LeaderImgDialog = new OpenFileDialog();
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
            SaveRenderDialog = new SaveFileDialog();
            leaderImgToolTip = new ToolTip(components);
            advancedNameBox = new FlowLayoutPanel();
            advancedName = new PictureBox();
            advancedDescBox = new FlowLayoutPanel();
            advancedDesc = new PictureBox();
            advancedClass = new PictureBox();
            advancedClassBox = new FlowLayoutPanel();
            splitClass = new CheckBox();
            chosenSecondClass = new ComboBox();
            labelSecondClass = new Label();
            menuStrip1 = new MenuStrip();
            LeaderCard = new ToolStripMenuItem();
            MonsterCard = new ToolStripMenuItem();
            language = new ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)previewImg).BeginInit();
            advancedNameBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advancedName).BeginInit();
            advancedDescBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advancedDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)advancedClass).BeginInit();
            advancedClassBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RENDER
            // 
            RENDER.BackColor = Color.White;
            RENDER.Cursor = Cursors.Hand;
            RENDER.FlatAppearance.BorderColor = Color.FromArgb(118, 110, 109);
            RENDER.FlatStyle = FlatStyle.Flat;
            RENDER.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            RENDER.Location = new Point(119, 557);
            RENDER.Name = "RENDER";
            RENDER.Size = new Size(175, 75);
            RENDER.TabIndex = 0;
            RENDER.Text = "RENDER";
            RENDER.UseVisualStyleBackColor = false;
            RENDER.Click += RenderButton_Press;
            // 
            // leaderNameText
            // 
            leaderNameText.BackColor = Color.White;
            leaderNameText.BorderStyle = BorderStyle.None;
            leaderNameText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            leaderNameText.Location = new Point(119, 210);
            leaderNameText.Margin = new Padding(0);
            leaderNameText.Name = "leaderNameText";
            leaderNameText.Size = new Size(175, 22);
            leaderNameText.TabIndex = 2;
            leaderNameText.TextChanged += renderPreview;
            // 
            // labelLeader
            // 
            labelLeader.BackColor = Color.Transparent;
            labelLeader.FlatStyle = FlatStyle.Flat;
            labelLeader.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelLeader.ForeColor = Color.White;
            labelLeader.ImageAlign = ContentAlignment.BottomLeft;
            labelLeader.Location = new Point(115, 190);
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
            labelDescription.ForeColor = Color.White;
            labelDescription.Location = new Point(53, 440);
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
            logo.Location = new Point(0, 25);
            logo.Name = "logo";
            logo.Size = new Size(414, 150);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 6;
            logo.TabStop = false;
            // 
            // chosenClass
            // 
            chosenClass.BackColor = Color.White;
            chosenClass.DropDownStyle = ComboBoxStyle.DropDownList;
            chosenClass.FlatStyle = FlatStyle.Flat;
            chosenClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chosenClass.FormattingEnabled = true;
            chosenClass.Location = new Point(145, 264);
            chosenClass.Margin = new Padding(0);
            chosenClass.Name = "chosenClass";
            chosenClass.Size = new Size(120, 25);
            chosenClass.TabIndex = 7;
            chosenClass.SelectedIndexChanged += chosenClass_SelectedIndexChanged;
            // 
            // labelClass
            // 
            labelClass.BackColor = Color.Transparent;
            labelClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelClass.ForeColor = Color.FromArgb(245, 240, 232);
            labelClass.Location = new Point(142, 244);
            labelClass.Margin = new Padding(0);
            labelClass.Name = "labelClass";
            labelClass.Size = new Size(100, 20);
            labelClass.TabIndex = 9;
            labelClass.Text = "Class";
            labelClass.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LeaderImgDialog
            // 
            LeaderImgDialog.FileName = "openFileDialog1";
            // 
            // selectImg
            // 
            selectImg.BackColor = SystemColors.Control;
            selectImg.Cursor = Cursors.Hand;
            selectImg.FlatAppearance.BorderColor = Color.White;
            selectImg.FlatStyle = FlatStyle.Flat;
            selectImg.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectImg.Location = new Point(270, 364);
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
            selectImgText.BackColor = Color.White;
            selectImgText.BorderStyle = BorderStyle.None;
            selectImgText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectImgText.Location = new Point(119, 364);
            selectImgText.Margin = new Padding(0);
            selectImgText.Multiline = true;
            selectImgText.Name = "selectImgText";
            selectImgText.Size = new Size(151, 22);
            selectImgText.TabIndex = 11;
            selectImgText.WordWrap = false;
            selectImgText.TextChanged += renderPreview;
            // 
            // labelImg
            // 
            labelImg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelImg.BackColor = Color.Transparent;
            labelImg.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelImg.ForeColor = Color.White;
            labelImg.Location = new Point(115, 344);
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
            gradient.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gradient.ForeColor = Color.White;
            gradient.Location = new Point(92, 0);
            gradient.Margin = new Padding(0);
            gradient.Name = "gradient";
            gradient.Size = new Size(99, 19);
            gradient.TabIndex = 13;
            gradient.Text = "Back Gradient";
            gradient.UseVisualStyleBackColor = false;
            gradient.CheckedChanged += renderPreview;
            // 
            // leaderWhite
            // 
            leaderWhite.AutoSize = true;
            leaderWhite.BackColor = Color.Transparent;
            leaderWhite.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            leaderWhite.ForeColor = Color.White;
            leaderWhite.Location = new Point(0, 0);
            leaderWhite.Margin = new Padding(0);
            leaderWhite.Name = "leaderWhite";
            leaderWhite.Size = new Size(92, 19);
            leaderWhite.TabIndex = 14;
            leaderWhite.Text = "White Name";
            leaderWhite.UseVisualStyleBackColor = false;
            leaderWhite.CheckedChanged += renderPreview;
            // 
            // descriptionText
            // 
            descriptionText.BackColor = Color.White;
            descriptionText.BorderStyle = BorderStyle.None;
            descriptionText.Location = new Point(57, 460);
            descriptionText.Margin = new Padding(0);
            descriptionText.Multiline = true;
            descriptionText.Name = "descriptionText";
            descriptionText.RightToLeft = RightToLeft.No;
            descriptionText.Size = new Size(300, 65);
            descriptionText.TabIndex = 15;
            descriptionText.TextChanged += renderPreview;
            // 
            // previewImg
            // 
            previewImg.BackColor = SystemColors.ControlLight;
            previewImg.Cursor = Cursors.Hand;
            previewImg.Dock = DockStyle.Right;
            previewImg.Location = new Point(414, 25);
            previewImg.Name = "previewImg";
            previewImg.Size = new Size(414, 711);
            previewImg.SizeMode = PictureBoxSizeMode.StretchImage;
            previewImg.TabIndex = 16;
            previewImg.TabStop = false;
            previewImg.Click += previewImg_Click;
            // 
            // gitLabel2
            // 
            gitLabel2.ActiveLinkColor = SystemColors.ControlDark;
            gitLabel2.AutoSize = true;
            gitLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gitLabel2.LinkColor = Color.FromArgb(205, 208, 215);
            gitLabel2.Location = new Point(0, 712);
            gitLabel2.Name = "gitLabel2";
            gitLabel2.Size = new Size(58, 15);
            gitLabel2.TabIndex = 17;
            gitLabel2.TabStop = true;
            gitLabel2.Text = "@Danrejk";
            gitLabel2.LinkClicked += linkLabel1_LinkClicked;
            // 
            // gitLabel1
            // 
            gitLabel1.ActiveLinkColor = SystemColors.ControlDark;
            gitLabel1.AutoSize = true;
            gitLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gitLabel1.LinkColor = Color.FromArgb(205, 208, 215);
            gitLabel1.Location = new Point(0, 697);
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
            wordSplitting.BackColor = Color.Transparent;
            wordSplitting.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            wordSplitting.ForeColor = Color.White;
            wordSplitting.Location = new Point(0, 0);
            wordSplitting.Margin = new Padding(0);
            wordSplitting.Name = "wordSplitting";
            wordSplitting.Size = new Size(102, 19);
            wordSplitting.TabIndex = 20;
            wordSplitting.Text = "Word Splitting";
            wordSplitting.UseVisualStyleBackColor = false;
            // 
            // leaderImgToolTip
            // 
            leaderImgToolTip.AutoPopDelay = 5000;
            leaderImgToolTip.InitialDelay = 250;
            leaderImgToolTip.ReshowDelay = 100;
            leaderImgToolTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // advancedNameBox
            // 
            advancedNameBox.BackColor = Color.Transparent;
            advancedNameBox.Controls.Add(leaderWhite);
            advancedNameBox.Controls.Add(gradient);
            advancedNameBox.Location = new Point(134, 232);
            advancedNameBox.Margin = new Padding(0);
            advancedNameBox.Name = "advancedNameBox";
            advancedNameBox.Size = new Size(197, 18);
            advancedNameBox.TabIndex = 21;
            advancedNameBox.Visible = false;
            // 
            // advancedName
            // 
            advancedName.BackColor = Color.Transparent;
            advancedName.Image = Properties.Resources.closed;
            advancedName.Location = new Point(119, 234);
            advancedName.Name = "advancedName";
            advancedName.Size = new Size(12, 12);
            advancedName.SizeMode = PictureBoxSizeMode.Zoom;
            advancedName.TabIndex = 22;
            advancedName.TabStop = false;
            advancedName.Click += advanced_Click;
            // 
            // advancedDescBox
            // 
            advancedDescBox.Controls.Add(wordSplitting);
            advancedDescBox.Location = new Point(72, 526);
            advancedDescBox.Margin = new Padding(0);
            advancedDescBox.Name = "advancedDescBox";
            advancedDescBox.Size = new Size(285, 28);
            advancedDescBox.TabIndex = 23;
            advancedDescBox.Visible = false;
            // 
            // advancedDesc
            // 
            advancedDesc.BackColor = Color.Transparent;
            advancedDesc.Image = Properties.Resources.closed;
            advancedDesc.Location = new Point(57, 528);
            advancedDesc.Name = "advancedDesc";
            advancedDesc.Size = new Size(12, 12);
            advancedDesc.SizeMode = PictureBoxSizeMode.Zoom;
            advancedDesc.TabIndex = 24;
            advancedDesc.TabStop = false;
            advancedDesc.Visible = false;
            advancedDesc.Click += advanced_Click;
            // 
            // advancedClass
            // 
            advancedClass.BackColor = Color.Transparent;
            advancedClass.Image = Properties.Resources.closed;
            advancedClass.Location = new Point(145, 292);
            advancedClass.Name = "advancedClass";
            advancedClass.Size = new Size(12, 12);
            advancedClass.SizeMode = PictureBoxSizeMode.Zoom;
            advancedClass.TabIndex = 25;
            advancedClass.TabStop = false;
            advancedClass.Click += advanced_Click;
            // 
            // advancedClassBox
            // 
            advancedClassBox.Controls.Add(splitClass);
            advancedClassBox.Location = new Point(160, 289);
            advancedClassBox.Margin = new Padding(0);
            advancedClassBox.Name = "advancedClassBox";
            advancedClassBox.Size = new Size(190, 24);
            advancedClassBox.TabIndex = 26;
            advancedClassBox.Visible = false;
            // 
            // splitClass
            // 
            splitClass.AutoSize = true;
            splitClass.ForeColor = Color.White;
            splitClass.Location = new Point(0, 0);
            splitClass.Margin = new Padding(0);
            splitClass.Name = "splitClass";
            splitClass.Padding = new Padding(0, 1, 0, 0);
            splitClass.Size = new Size(79, 20);
            splitClass.TabIndex = 0;
            splitClass.Text = "Split Class";
            splitClass.UseVisualStyleBackColor = true;
            splitClass.CheckStateChanged += splitClass_CheckStateChanged;
            // 
            // chosenSecondClass
            // 
            chosenSecondClass.BackColor = Color.White;
            chosenSecondClass.DropDownStyle = ComboBoxStyle.DropDownList;
            chosenSecondClass.FlatStyle = FlatStyle.Flat;
            chosenSecondClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chosenSecondClass.FormattingEnabled = true;
            chosenSecondClass.Location = new Point(210, 264);
            chosenSecondClass.Margin = new Padding(0);
            chosenSecondClass.Name = "chosenSecondClass";
            chosenSecondClass.Size = new Size(120, 25);
            chosenSecondClass.TabIndex = 27;
            chosenSecondClass.Visible = false;
            chosenSecondClass.SelectedIndexChanged += chosenSecondClass_SelectedIndexChanged;
            // 
            // labelSecondClass
            // 
            labelSecondClass.BackColor = Color.Transparent;
            labelSecondClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelSecondClass.ForeColor = Color.FromArgb(245, 240, 232);
            labelSecondClass.Location = new Point(207, 244);
            labelSecondClass.Margin = new Padding(0);
            labelSecondClass.Name = "labelSecondClass";
            labelSecondClass.Size = new Size(100, 20);
            labelSecondClass.TabIndex = 28;
            labelSecondClass.Text = "Second Class";
            labelSecondClass.TextAlign = ContentAlignment.BottomLeft;
            labelSecondClass.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(17, 19, 23);
            menuStrip1.GripMargin = new Padding(2);
            menuStrip1.Items.AddRange(new ToolStripItem[] { LeaderCard, MonsterCard, language });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 0, 0, 2);
            menuStrip1.Size = new Size(828, 25);
            menuStrip1.TabIndex = 29;
            menuStrip1.Text = "menuStrip1";
            // 
            // LeaderCard
            // 
            LeaderCard.BackColor = SystemColors.ButtonFace;
            LeaderCard.Name = "LeaderCard";
            LeaderCard.Size = new Size(82, 23);
            LeaderCard.Text = "Leader Card";
            // 
            // MonsterCard
            // 
            MonsterCard.BackColor = SystemColors.ButtonFace;
            MonsterCard.Margin = new Padding(6, 0, 0, 0);
            MonsterCard.Name = "MonsterCard";
            MonsterCard.RightToLeft = RightToLeft.No;
            MonsterCard.Size = new Size(91, 23);
            MonsterCard.Text = "Monster Card";
            // 
            // language
            // 
            language.DropDownStyle = ComboBoxStyle.DropDownList;
            language.Name = "language";
            language.Size = new Size(121, 23);
            language.SelectedIndexChanged += language_SelectedIndexChanged;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 43, 52);
            BackgroundImage = Properties.Resources.gradient;
            ClientSize = new Size(828, 736);
            Controls.Add(chosenSecondClass);
            Controls.Add(advancedClassBox);
            Controls.Add(advancedClass);
            Controls.Add(advancedDesc);
            Controls.Add(advancedDescBox);
            Controls.Add(advancedName);
            Controls.Add(advancedNameBox);
            Controls.Add(gitLabel1);
            Controls.Add(gitLabel2);
            Controls.Add(descriptionText);
            Controls.Add(labelImg);
            Controls.Add(selectImgText);
            Controls.Add(selectImg);
            Controls.Add(chosenClass);
            Controls.Add(labelDescription);
            Controls.Add(leaderNameText);
            Controls.Add(RENDER);
            Controls.Add(logo);
            Controls.Add(previewImg);
            Controls.Add(labelLeader);
            Controls.Add(labelSecondClass);
            Controls.Add(labelClass);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Menu";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Here To Slay - Custom leader card Generator";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)previewImg).EndInit();
            advancedNameBox.ResumeLayout(false);
            advancedNameBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)advancedName).EndInit();
            advancedDescBox.ResumeLayout(false);
            advancedDescBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)advancedDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)advancedClass).EndInit();
            advancedClassBox.ResumeLayout(false);
            advancedClassBox.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RENDER;
        private TextBox leaderNameText;
        private Label labelLeader;
        private Label labelDescription;
        private PictureBox logo;
        private ComboBox chosenClass;
        private TextBox descriptionText;
        private Label labelClass;
        private OpenFileDialog LeaderImgDialog;
        private Button selectImg;
        private TextBox selectImgText;
        private Label labelImg;
        private CheckBox gradient;
        private CheckBox leaderWhite;
        private PictureBox previewImg;
        private LinkLabel gitLabel2;
        private LinkLabel gitLabel1;
        private CheckBox wordSplitting;
        private SaveFileDialog SaveRenderDialog;
        private ToolTip leaderImgToolTip;
        private FlowLayoutPanel advancedNameBox;
        private PictureBox advancedName;
        private FlowLayoutPanel advancedDescBox;
        private PictureBox advancedDesc;
        private PictureBox advancedClass;
        private FlowLayoutPanel advancedClassBox;
        private CheckBox splitClass;
        private ComboBox chosenSecondClass;
        private Label labelSecondClass;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem LeaderCard;
        private ToolStripMenuItem MonsterCard;
        private ToolStripComboBox language;
    }
}