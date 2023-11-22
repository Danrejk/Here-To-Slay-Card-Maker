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
            nameText = new TextBox();
            labelLeader = new Label();
            labelDescription = new Label();
            logo = new PictureBox();
            chosenClass = new ComboBox();
            labelClass = new Label();
            LeaderImgDialog = new OpenFileDialog();
            selectImgButton = new Button();
            selectImgText = new TextBox();
            labelImg = new Label();
            gradient = new CheckBox();
            nameWhite = new CheckBox();
            descriptionText = new TextBox();
            previewImg = new PictureBox();
            previewContextMenu = new ContextMenuStrip(components);
            openImageLocationToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyImageToClipboardToolStripMenuItem = new ToolStripMenuItem();
            gitLabel2 = new LinkLabel();
            gitLabel1 = new LinkLabel();
            SaveRenderDialog = new SaveFileDialog();
            leaderImgToolTip = new ToolTip(components);
            advancedNameBox = new FlowLayoutPanel();
            advancedName = new PictureBox();
            advancedClass = new PictureBox();
            advancedClassBox = new FlowLayoutPanel();
            splitClass = new CheckBox();
            chosenSecondClass = new ComboBox();
            labelSecondClass = new Label();
            menuStrip1 = new MenuStrip();
            LeaderCard = new ToolStripMenuItem();
            MonsterCard = new ToolStripMenuItem();
            language = new ToolStripComboBox();
            HeroCard = new ToolStripMenuItem();
            heroReq3 = new ComboBox();
            heroReq2 = new ComboBox();
            heroReq1 = new ComboBox();
            heroReq4 = new ComboBox();
            labelReq = new Label();
            heroReq5 = new ComboBox();
            badOutputNum = new NumericUpDown();
            badOutputSym = new ComboBox();
            badOutputText = new TextBox();
            labelBad = new Label();
            labelGood = new Label();
            goodOutputText = new TextBox();
            goodOutputSym = new ComboBox();
            goodOutputNum = new NumericUpDown();
            clearSecondClass = new Button();
            clearHeroReq1 = new Button();
            clearHeroReq2 = new Button();
            clearHeroReq4 = new Button();
            clearHeroReq5 = new Button();
            clearHeroReq3 = new Button();
            maxItems = new NumericUpDown();
            labelMaxItem = new Label();
            itemImg = new PictureBox();
            itemImg2 = new PictureBox();
            itemImgMore = new Label();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)previewImg).BeginInit();
            previewContextMenu.SuspendLayout();
            advancedNameBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advancedName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)advancedClass).BeginInit();
            advancedClassBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)badOutputNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)goodOutputNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemImg2).BeginInit();
            SuspendLayout();
            // 
            // RENDER
            // 
            RENDER.BackColor = Color.White;
            RENDER.Cursor = Cursors.Hand;
            RENDER.FlatAppearance.BorderColor = Color.FromArgb(118, 110, 109);
            RENDER.FlatStyle = FlatStyle.Flat;
            RENDER.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            RENDER.Location = new Point(119, 525);
            RENDER.Name = "RENDER";
            RENDER.Size = new Size(175, 75);
            RENDER.TabIndex = 0;
            RENDER.Text = "RENDER";
            RENDER.UseVisualStyleBackColor = false;
            RENDER.Click += RenderButton_Press;
            // 
            // nameText
            // 
            nameText.BackColor = Color.White;
            nameText.BorderStyle = BorderStyle.None;
            nameText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nameText.Location = new Point(119, 195);
            nameText.Margin = new Padding(0);
            nameText.Name = "nameText";
            nameText.Size = new Size(175, 22);
            nameText.TabIndex = 2;
            nameText.TextChanged += renderPreview;
            // 
            // labelLeader
            // 
            labelLeader.BackColor = Color.Transparent;
            labelLeader.FlatStyle = FlatStyle.Flat;
            labelLeader.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelLeader.ForeColor = Color.White;
            labelLeader.ImageAlign = ContentAlignment.BottomLeft;
            labelLeader.Location = new Point(115, 175);
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
            labelDescription.Location = new Point(53, 426);
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
            chosenClass.Location = new Point(145, 249);
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
            labelClass.Location = new Point(142, 229);
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
            // selectImgButton
            // 
            selectImgButton.BackColor = SystemColors.Control;
            selectImgButton.Cursor = Cursors.Help;
            selectImgButton.FlatAppearance.BorderColor = Color.White;
            selectImgButton.FlatStyle = FlatStyle.Flat;
            selectImgButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectImgButton.Location = new Point(270, 349);
            selectImgButton.Margin = new Padding(0);
            selectImgButton.Name = "selectImgButton";
            selectImgButton.Size = new Size(24, 22);
            selectImgButton.TabIndex = 10;
            selectImgButton.Text = "⋯";
            selectImgButton.TextAlign = ContentAlignment.TopCenter;
            selectImgButton.UseVisualStyleBackColor = false;
            selectImgButton.Click += selectImg_Click;
            // 
            // selectImgText
            // 
            selectImgText.BackColor = Color.White;
            selectImgText.BorderStyle = BorderStyle.None;
            selectImgText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectImgText.Location = new Point(119, 349);
            selectImgText.Margin = new Padding(0);
            selectImgText.Multiline = true;
            selectImgText.Name = "selectImgText";
            selectImgText.PlaceholderText = "e.g. C:\\Users\\Me\\Downloads\\franki.png";
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
            labelImg.Location = new Point(115, 329);
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
            // nameWhite
            // 
            nameWhite.AutoSize = true;
            nameWhite.BackColor = Color.Transparent;
            nameWhite.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            nameWhite.ForeColor = Color.White;
            nameWhite.Location = new Point(0, 0);
            nameWhite.Margin = new Padding(0);
            nameWhite.Name = "nameWhite";
            nameWhite.Size = new Size(92, 19);
            nameWhite.TabIndex = 14;
            nameWhite.Text = "White Name";
            nameWhite.UseVisualStyleBackColor = false;
            nameWhite.CheckedChanged += renderPreview;
            // 
            // descriptionText
            // 
            descriptionText.BackColor = Color.White;
            descriptionText.BorderStyle = BorderStyle.None;
            descriptionText.Location = new Point(57, 446);
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
            previewImg.BackColor = SystemColors.ActiveCaptionText;
            previewImg.ContextMenuStrip = previewContextMenu;
            previewImg.Cursor = Cursors.Hand;
            previewImg.Dock = DockStyle.Right;
            previewImg.Location = new Point(414, 0);
            previewImg.Name = "previewImg";
            previewImg.Size = new Size(414, 711);
            previewImg.SizeMode = PictureBoxSizeMode.StretchImage;
            previewImg.TabIndex = 16;
            previewImg.TabStop = false;
            previewImg.Click += previewImg_Click;
            // 
            // previewContextMenu
            // 
            previewContextMenu.Items.AddRange(new ToolStripItem[] { openImageLocationToolStripMenuItem, toolStripSeparator1, copyImageToClipboardToolStripMenuItem });
            previewContextMenu.Name = "previewContextMenu";
            previewContextMenu.RenderMode = ToolStripRenderMode.System;
            previewContextMenu.Size = new Size(189, 54);
            // 
            // openImageLocationToolStripMenuItem
            // 
            openImageLocationToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            openImageLocationToolStripMenuItem.Name = "openImageLocationToolStripMenuItem";
            openImageLocationToolStripMenuItem.Size = new Size(188, 22);
            openImageLocationToolStripMenuItem.Text = "Open image location";
            openImageLocationToolStripMenuItem.Click += previewImg_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(185, 6);
            // 
            // copyImageToClipboardToolStripMenuItem
            // 
            copyImageToClipboardToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            copyImageToClipboardToolStripMenuItem.Name = "copyImageToClipboardToolStripMenuItem";
            copyImageToClipboardToolStripMenuItem.Size = new Size(188, 22);
            copyImageToClipboardToolStripMenuItem.Text = "Copy";
            copyImageToClipboardToolStripMenuItem.Click += copyImageToClipboardToolStripMenuItem_Click;
            // 
            // gitLabel2
            // 
            gitLabel2.ActiveLinkColor = SystemColors.ControlDark;
            gitLabel2.AutoSize = true;
            gitLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gitLabel2.LinkColor = Color.FromArgb(205, 208, 215);
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
            gitLabel1.ActiveLinkColor = SystemColors.ControlDark;
            gitLabel1.AutoSize = true;
            gitLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gitLabel1.LinkColor = Color.FromArgb(205, 208, 215);
            gitLabel1.Location = new Point(0, 672);
            gitLabel1.Name = "gitLabel1";
            gitLabel1.Size = new Size(55, 15);
            gitLabel1.TabIndex = 19;
            gitLabel1.TabStop = true;
            gitLabel1.Text = "@Beukot";
            gitLabel1.LinkClicked += linkLabel2_LinkClicked;
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
            advancedNameBox.Controls.Add(nameWhite);
            advancedNameBox.Controls.Add(gradient);
            advancedNameBox.Location = new Point(134, 217);
            advancedNameBox.Margin = new Padding(0);
            advancedNameBox.Name = "advancedNameBox";
            advancedNameBox.Size = new Size(197, 18);
            advancedNameBox.TabIndex = 21;
            advancedNameBox.Visible = false;
            // 
            // advancedName
            // 
            advancedName.BackColor = Color.Transparent;
            advancedName.Cursor = Cursors.Hand;
            advancedName.Image = Properties.Resources.closed;
            advancedName.Location = new Point(119, 219);
            advancedName.Name = "advancedName";
            advancedName.Size = new Size(12, 12);
            advancedName.SizeMode = PictureBoxSizeMode.Zoom;
            advancedName.TabIndex = 22;
            advancedName.TabStop = false;
            advancedName.Click += advanced_Click;
            // 
            // advancedClass
            // 
            advancedClass.BackColor = Color.Transparent;
            advancedClass.Cursor = Cursors.Hand;
            advancedClass.Image = Properties.Resources.closed;
            advancedClass.Location = new Point(145, 277);
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
            advancedClassBox.Location = new Point(160, 274);
            advancedClassBox.Margin = new Padding(0);
            advancedClassBox.Name = "advancedClassBox";
            advancedClassBox.Size = new Size(190, 18);
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
            chosenSecondClass.Location = new Point(210, 249);
            chosenSecondClass.Margin = new Padding(0);
            chosenSecondClass.Name = "chosenSecondClass";
            chosenSecondClass.Size = new Size(120, 25);
            chosenSecondClass.TabIndex = 27;
            chosenSecondClass.Visible = false;
            chosenSecondClass.SelectedIndexChanged += renderPreview;
            // 
            // labelSecondClass
            // 
            labelSecondClass.BackColor = Color.Transparent;
            labelSecondClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelSecondClass.ForeColor = Color.FromArgb(245, 240, 232);
            labelSecondClass.Location = new Point(207, 229);
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { LeaderCard, MonsterCard, language, HeroCard });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 0, 0, 2);
            menuStrip1.Size = new Size(414, 25);
            menuStrip1.TabIndex = 29;
            menuStrip1.Text = "menuStrip1";
            // 
            // LeaderCard
            // 
            LeaderCard.BackColor = SystemColors.Control;
            LeaderCard.Name = "LeaderCard";
            LeaderCard.Size = new Size(82, 23);
            LeaderCard.Text = "Leader Card";
            LeaderCard.Click += LeaderCard_Click;
            // 
            // MonsterCard
            // 
            MonsterCard.BackColor = SystemColors.Control;
            MonsterCard.Margin = new Padding(6, 0, 0, 0);
            MonsterCard.Name = "MonsterCard";
            MonsterCard.RightToLeft = RightToLeft.No;
            MonsterCard.Size = new Size(91, 23);
            MonsterCard.Text = "Monster Card";
            MonsterCard.Click += MonsterCard_Click;
            // 
            // language
            // 
            language.Alignment = ToolStripItemAlignment.Right;
            language.DropDownStyle = ComboBoxStyle.DropDownList;
            language.Margin = new Padding(0);
            language.Name = "language";
            language.Size = new Size(85, 23);
            language.SelectedIndexChanged += language_SelectedIndexChanged;
            // 
            // HeroCard
            // 
            HeroCard.BackColor = SystemColors.Control;
            HeroCard.Margin = new Padding(6, 0, 0, 0);
            HeroCard.Name = "HeroCard";
            HeroCard.Size = new Size(73, 23);
            HeroCard.Text = "Hero Card";
            HeroCard.Click += HeroCard_Click;
            // 
            // heroReq3
            // 
            heroReq3.BackColor = Color.White;
            heroReq3.DropDownStyle = ComboBoxStyle.DropDownList;
            heroReq3.FlatStyle = FlatStyle.Flat;
            heroReq3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            heroReq3.FormattingEnabled = true;
            heroReq3.Location = new Point(70, 331);
            heroReq3.Margin = new Padding(3, 3, 0, 3);
            heroReq3.Name = "heroReq3";
            heroReq3.Size = new Size(120, 25);
            heroReq3.TabIndex = 30;
            heroReq3.Visible = false;
            heroReq3.SelectedIndexChanged += renderPreview;
            // 
            // heroReq2
            // 
            heroReq2.BackColor = Color.White;
            heroReq2.DropDownStyle = ComboBoxStyle.DropDownList;
            heroReq2.FlatStyle = FlatStyle.Flat;
            heroReq2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            heroReq2.FormattingEnabled = true;
            heroReq2.Location = new Point(208, 303);
            heroReq2.Margin = new Padding(3, 3, 0, 3);
            heroReq2.Name = "heroReq2";
            heroReq2.Size = new Size(120, 25);
            heroReq2.TabIndex = 31;
            heroReq2.Visible = false;
            heroReq2.SelectedIndexChanged += renderPreview;
            // 
            // heroReq1
            // 
            heroReq1.BackColor = Color.White;
            heroReq1.DropDownStyle = ComboBoxStyle.DropDownList;
            heroReq1.FlatStyle = FlatStyle.Flat;
            heroReq1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            heroReq1.FormattingEnabled = true;
            heroReq1.Location = new Point(70, 303);
            heroReq1.Margin = new Padding(3, 3, 0, 3);
            heroReq1.Name = "heroReq1";
            heroReq1.Size = new Size(120, 25);
            heroReq1.TabIndex = 32;
            heroReq1.Visible = false;
            heroReq1.SelectedIndexChanged += renderPreview;
            // 
            // heroReq4
            // 
            heroReq4.BackColor = Color.White;
            heroReq4.DropDownStyle = ComboBoxStyle.DropDownList;
            heroReq4.FlatStyle = FlatStyle.Flat;
            heroReq4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            heroReq4.FormattingEnabled = true;
            heroReq4.Location = new Point(208, 331);
            heroReq4.Margin = new Padding(3, 3, 0, 3);
            heroReq4.Name = "heroReq4";
            heroReq4.Size = new Size(120, 25);
            heroReq4.TabIndex = 33;
            heroReq4.Visible = false;
            heroReq4.SelectedIndexChanged += renderPreview;
            // 
            // labelReq
            // 
            labelReq.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelReq.BackColor = Color.Transparent;
            labelReq.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelReq.ForeColor = Color.White;
            labelReq.Location = new Point(67, 283);
            labelReq.Margin = new Padding(0);
            labelReq.Name = "labelReq";
            labelReq.RightToLeft = RightToLeft.No;
            labelReq.Size = new Size(172, 20);
            labelReq.TabIndex = 34;
            labelReq.Text = "Requirements";
            labelReq.TextAlign = ContentAlignment.BottomLeft;
            labelReq.Visible = false;
            // 
            // heroReq5
            // 
            heroReq5.BackColor = Color.White;
            heroReq5.DropDownStyle = ComboBoxStyle.DropDownList;
            heroReq5.FlatStyle = FlatStyle.Flat;
            heroReq5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            heroReq5.FormattingEnabled = true;
            heroReq5.Location = new Point(142, 359);
            heroReq5.Margin = new Padding(3, 3, 0, 3);
            heroReq5.Name = "heroReq5";
            heroReq5.Size = new Size(120, 25);
            heroReq5.TabIndex = 35;
            heroReq5.Visible = false;
            heroReq5.SelectedIndexChanged += renderPreview;
            // 
            // badOutputNum
            // 
            badOutputNum.Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Regular, GraphicsUnit.Point);
            badOutputNum.Location = new Point(84, 415);
            badOutputNum.Margin = new Padding(0);
            badOutputNum.Name = "badOutputNum";
            badOutputNum.Size = new Size(35, 24);
            badOutputNum.TabIndex = 36;
            badOutputNum.TextAlign = HorizontalAlignment.Right;
            badOutputNum.Visible = false;
            badOutputNum.ValueChanged += renderPreview;
            // 
            // badOutputSym
            // 
            badOutputSym.DropDownStyle = ComboBoxStyle.DropDownList;
            badOutputSym.FlatStyle = FlatStyle.Flat;
            badOutputSym.ForeColor = Color.White;
            badOutputSym.FormattingEnabled = true;
            badOutputSym.Location = new Point(118, 416);
            badOutputSym.Margin = new Padding(0);
            badOutputSym.Name = "badOutputSym";
            badOutputSym.Size = new Size(35, 23);
            badOutputSym.TabIndex = 37;
            badOutputSym.Visible = false;
            badOutputSym.SelectedIndexChanged += OutputSym_SelectedIndexChanged;
            // 
            // badOutputText
            // 
            badOutputText.BorderStyle = BorderStyle.None;
            badOutputText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            badOutputText.Location = new Point(156, 416);
            badOutputText.Margin = new Padding(0);
            badOutputText.Multiline = true;
            badOutputText.Name = "badOutputText";
            badOutputText.Size = new Size(175, 23);
            badOutputText.TabIndex = 38;
            badOutputText.Visible = false;
            badOutputText.TextChanged += renderPreview;
            // 
            // labelBad
            // 
            labelBad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelBad.BackColor = Color.Transparent;
            labelBad.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelBad.ForeColor = Color.White;
            labelBad.Location = new Point(81, 396);
            labelBad.Margin = new Padding(0);
            labelBad.Name = "labelBad";
            labelBad.RightToLeft = RightToLeft.No;
            labelBad.Size = new Size(244, 20);
            labelBad.TabIndex = 39;
            labelBad.Text = "Roll Requirement - Fail";
            labelBad.TextAlign = ContentAlignment.BottomLeft;
            labelBad.Visible = false;
            // 
            // labelGood
            // 
            labelGood.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelGood.BackColor = Color.Transparent;
            labelGood.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelGood.ForeColor = Color.White;
            labelGood.Location = new Point(81, 437);
            labelGood.Margin = new Padding(0);
            labelGood.Name = "labelGood";
            labelGood.RightToLeft = RightToLeft.No;
            labelGood.Size = new Size(250, 20);
            labelGood.TabIndex = 43;
            labelGood.Text = "Roll Requirement - Slay Monster";
            labelGood.TextAlign = ContentAlignment.BottomLeft;
            labelGood.Visible = false;
            // 
            // goodOutputText
            // 
            goodOutputText.BorderStyle = BorderStyle.None;
            goodOutputText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            goodOutputText.Location = new Point(156, 457);
            goodOutputText.Multiline = true;
            goodOutputText.Name = "goodOutputText";
            goodOutputText.Size = new Size(175, 23);
            goodOutputText.TabIndex = 42;
            goodOutputText.Text = "UBIJ tego potwora.";
            goodOutputText.Visible = false;
            goodOutputText.TextChanged += renderPreview;
            // 
            // goodOutputSym
            // 
            goodOutputSym.DropDownStyle = ComboBoxStyle.DropDownList;
            goodOutputSym.FlatStyle = FlatStyle.Flat;
            goodOutputSym.ForeColor = Color.White;
            goodOutputSym.FormattingEnabled = true;
            goodOutputSym.Location = new Point(118, 457);
            goodOutputSym.Margin = new Padding(0);
            goodOutputSym.Name = "goodOutputSym";
            goodOutputSym.Size = new Size(35, 23);
            goodOutputSym.TabIndex = 41;
            goodOutputSym.Visible = false;
            goodOutputSym.SelectedIndexChanged += OutputSym_SelectedIndexChanged;
            // 
            // goodOutputNum
            // 
            goodOutputNum.BorderStyle = BorderStyle.FixedSingle;
            goodOutputNum.Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Regular, GraphicsUnit.Point);
            goodOutputNum.Location = new Point(84, 457);
            goodOutputNum.Name = "goodOutputNum";
            goodOutputNum.Size = new Size(35, 24);
            goodOutputNum.TabIndex = 40;
            goodOutputNum.TextAlign = HorizontalAlignment.Right;
            goodOutputNum.Visible = false;
            goodOutputNum.ValueChanged += renderPreview;
            // 
            // clearSecondClass
            // 
            clearSecondClass.Anchor = AnchorStyles.None;
            clearSecondClass.BackColor = SystemColors.ControlLight;
            clearSecondClass.FlatAppearance.BorderSize = 0;
            clearSecondClass.FlatStyle = FlatStyle.Flat;
            clearSecondClass.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearSecondClass.ForeColor = Color.FromArgb(230, 44, 47);
            clearSecondClass.Location = new Point(330, 249);
            clearSecondClass.Margin = new Padding(0);
            clearSecondClass.Name = "clearSecondClass";
            clearSecondClass.Size = new Size(15, 25);
            clearSecondClass.TabIndex = 44;
            clearSecondClass.Text = "X";
            clearSecondClass.UseVisualStyleBackColor = false;
            clearSecondClass.Visible = false;
            clearSecondClass.Click += clearSelectedClass;
            // 
            // clearHeroReq1
            // 
            clearHeroReq1.BackColor = SystemColors.ControlLight;
            clearHeroReq1.FlatAppearance.BorderSize = 0;
            clearHeroReq1.FlatStyle = FlatStyle.Flat;
            clearHeroReq1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearHeroReq1.ForeColor = Color.FromArgb(230, 44, 47);
            clearHeroReq1.Location = new Point(190, 303);
            clearHeroReq1.Margin = new Padding(0);
            clearHeroReq1.Name = "clearHeroReq1";
            clearHeroReq1.Size = new Size(15, 25);
            clearHeroReq1.TabIndex = 45;
            clearHeroReq1.Text = "X";
            clearHeroReq1.UseVisualStyleBackColor = false;
            clearHeroReq1.Visible = false;
            clearHeroReq1.Click += clearSelectedClass;
            // 
            // clearHeroReq2
            // 
            clearHeroReq2.BackColor = SystemColors.ControlLight;
            clearHeroReq2.FlatAppearance.BorderSize = 0;
            clearHeroReq2.FlatStyle = FlatStyle.Flat;
            clearHeroReq2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearHeroReq2.ForeColor = Color.FromArgb(230, 44, 47);
            clearHeroReq2.Location = new Point(328, 303);
            clearHeroReq2.Margin = new Padding(0);
            clearHeroReq2.Name = "clearHeroReq2";
            clearHeroReq2.Size = new Size(15, 25);
            clearHeroReq2.TabIndex = 46;
            clearHeroReq2.Text = "X";
            clearHeroReq2.UseVisualStyleBackColor = false;
            clearHeroReq2.Visible = false;
            clearHeroReq2.Click += clearSelectedClass;
            // 
            // clearHeroReq4
            // 
            clearHeroReq4.BackColor = SystemColors.ControlLight;
            clearHeroReq4.FlatAppearance.BorderSize = 0;
            clearHeroReq4.FlatStyle = FlatStyle.Flat;
            clearHeroReq4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearHeroReq4.ForeColor = Color.FromArgb(230, 44, 47);
            clearHeroReq4.Location = new Point(328, 331);
            clearHeroReq4.Margin = new Padding(0);
            clearHeroReq4.Name = "clearHeroReq4";
            clearHeroReq4.Size = new Size(15, 25);
            clearHeroReq4.TabIndex = 48;
            clearHeroReq4.Text = "X";
            clearHeroReq4.UseVisualStyleBackColor = false;
            clearHeroReq4.Visible = false;
            clearHeroReq4.Click += clearSelectedClass;
            // 
            // clearHeroReq5
            // 
            clearHeroReq5.BackColor = SystemColors.ControlLight;
            clearHeroReq5.FlatAppearance.BorderSize = 0;
            clearHeroReq5.FlatStyle = FlatStyle.Flat;
            clearHeroReq5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearHeroReq5.ForeColor = Color.FromArgb(230, 44, 47);
            clearHeroReq5.Location = new Point(262, 359);
            clearHeroReq5.Margin = new Padding(0);
            clearHeroReq5.Name = "clearHeroReq5";
            clearHeroReq5.Size = new Size(15, 25);
            clearHeroReq5.TabIndex = 49;
            clearHeroReq5.Text = "X";
            clearHeroReq5.UseVisualStyleBackColor = false;
            clearHeroReq5.Visible = false;
            clearHeroReq5.Click += clearSelectedClass;
            // 
            // clearHeroReq3
            // 
            clearHeroReq3.BackColor = SystemColors.ControlLight;
            clearHeroReq3.FlatAppearance.BorderSize = 0;
            clearHeroReq3.FlatStyle = FlatStyle.Flat;
            clearHeroReq3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearHeroReq3.ForeColor = Color.FromArgb(230, 44, 47);
            clearHeroReq3.Location = new Point(190, 331);
            clearHeroReq3.Margin = new Padding(0);
            clearHeroReq3.Name = "clearHeroReq3";
            clearHeroReq3.Size = new Size(15, 25);
            clearHeroReq3.TabIndex = 47;
            clearHeroReq3.Text = "X";
            clearHeroReq3.UseVisualStyleBackColor = false;
            clearHeroReq3.Visible = false;
            clearHeroReq3.Click += clearSelectedClass;
            // 
            // maxItems
            // 
            maxItems.BorderStyle = BorderStyle.FixedSingle;
            maxItems.Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Regular, GraphicsUnit.Point);
            maxItems.Location = new Point(177, 398);
            maxItems.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            maxItems.Name = "maxItems";
            maxItems.Size = new Size(35, 24);
            maxItems.TabIndex = 50;
            maxItems.TextAlign = HorizontalAlignment.Right;
            maxItems.Value = new decimal(new int[] { 1, 0, 0, 0 });
            maxItems.Visible = false;
            maxItems.ValueChanged += maxItems_ValueChanged;
            // 
            // labelMaxItem
            // 
            labelMaxItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelMaxItem.BackColor = Color.Transparent;
            labelMaxItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelMaxItem.ForeColor = Color.White;
            labelMaxItem.Location = new Point(0, 379);
            labelMaxItem.Margin = new Padding(0);
            labelMaxItem.Name = "labelMaxItem";
            labelMaxItem.RightToLeft = RightToLeft.No;
            labelMaxItem.Size = new Size(414, 20);
            labelMaxItem.TabIndex = 51;
            labelMaxItem.Text = "Max Item Ammount";
            labelMaxItem.TextAlign = ContentAlignment.BottomCenter;
            labelMaxItem.Visible = false;
            // 
            // itemImg
            // 
            itemImg.Image = Properties.Resources.item;
            itemImg.Location = new Point(212, 398);
            itemImg.Margin = new Padding(1);
            itemImg.Name = "itemImg";
            itemImg.Size = new Size(24, 24);
            itemImg.SizeMode = PictureBoxSizeMode.Zoom;
            itemImg.TabIndex = 52;
            itemImg.TabStop = false;
            // 
            // itemImg2
            // 
            itemImg2.Image = Properties.Resources.item;
            itemImg2.Location = new Point(238, 398);
            itemImg2.Margin = new Padding(1);
            itemImg2.Name = "itemImg2";
            itemImg2.Size = new Size(24, 24);
            itemImg2.SizeMode = PictureBoxSizeMode.Zoom;
            itemImg2.TabIndex = 53;
            itemImg2.TabStop = false;
            itemImg2.Visible = false;
            // 
            // itemImgMore
            // 
            itemImgMore.AutoSize = true;
            itemImgMore.BackColor = Color.Transparent;
            itemImgMore.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            itemImgMore.ForeColor = Color.White;
            itemImgMore.Location = new Point(260, 397);
            itemImgMore.Margin = new Padding(0);
            itemImgMore.Name = "itemImgMore";
            itemImgMore.Size = new Size(24, 25);
            itemImgMore.TabIndex = 54;
            itemImgMore.Text = "+";
            itemImgMore.Visible = false;
            // 
            // Menu
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(39, 43, 52);
            BackgroundImage = Properties.Resources.gradient;
            ClientSize = new Size(828, 711);
            Controls.Add(itemImg2);
            Controls.Add(itemImg);
            Controls.Add(itemImgMore);
            Controls.Add(maxItems);
            Controls.Add(advancedNameBox);
            Controls.Add(badOutputText);
            Controls.Add(clearHeroReq5);
            Controls.Add(clearHeroReq4);
            Controls.Add(clearHeroReq3);
            Controls.Add(clearHeroReq2);
            Controls.Add(clearHeroReq1);
            Controls.Add(heroReq5);
            Controls.Add(heroReq4);
            Controls.Add(heroReq1);
            Controls.Add(heroReq2);
            Controls.Add(heroReq3);
            Controls.Add(clearSecondClass);
            Controls.Add(goodOutputText);
            Controls.Add(goodOutputSym);
            Controls.Add(goodOutputNum);
            Controls.Add(badOutputSym);
            Controls.Add(badOutputNum);
            Controls.Add(chosenSecondClass);
            Controls.Add(advancedClassBox);
            Controls.Add(advancedClass);
            Controls.Add(advancedName);
            Controls.Add(gitLabel1);
            Controls.Add(gitLabel2);
            Controls.Add(descriptionText);
            Controls.Add(labelImg);
            Controls.Add(selectImgText);
            Controls.Add(selectImgButton);
            Controls.Add(chosenClass);
            Controls.Add(labelDescription);
            Controls.Add(nameText);
            Controls.Add(RENDER);
            Controls.Add(logo);
            Controls.Add(labelLeader);
            Controls.Add(labelSecondClass);
            Controls.Add(labelClass);
            Controls.Add(menuStrip1);
            Controls.Add(previewImg);
            Controls.Add(labelGood);
            Controls.Add(labelBad);
            Controls.Add(labelMaxItem);
            Controls.Add(labelReq);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Menu";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Here To Slay - Custom leader card Generator";
            Load += renderPreview;
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)previewImg).EndInit();
            previewContextMenu.ResumeLayout(false);
            advancedNameBox.ResumeLayout(false);
            advancedNameBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)advancedName).EndInit();
            ((System.ComponentModel.ISupportInitialize)advancedClass).EndInit();
            advancedClassBox.ResumeLayout(false);
            advancedClassBox.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)badOutputNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)goodOutputNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemImg2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RENDER;
        private TextBox nameText;
        private Label labelLeader;
        private Label labelDescription;
        private PictureBox logo;
        private ComboBox chosenClass;
        private TextBox descriptionText;
        private Label labelClass;
        private OpenFileDialog LeaderImgDialog;
        private Button selectImgButton;
        private TextBox selectImgText;
        private Label labelImg;
        private CheckBox gradient;
        private CheckBox nameWhite;
        private PictureBox previewImg;
        private LinkLabel gitLabel2;
        private LinkLabel gitLabel1;
        private SaveFileDialog SaveRenderDialog;
        private ToolTip leaderImgToolTip;
        private FlowLayoutPanel advancedNameBox;
        private PictureBox advancedName;
        private PictureBox advancedClass;
        private FlowLayoutPanel advancedClassBox;
        private CheckBox splitClass;
        private ComboBox chosenSecondClass;
        private Label labelSecondClass;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem LeaderCard;
        private ToolStripMenuItem MonsterCard;
        private ToolStripComboBox language;
        private ComboBox heroReq3;
        private ComboBox heroReq2;
        private ComboBox heroReq1;
        private ComboBox heroReq4;
        private Label labelReq;
        private ComboBox heroReq5;
        private NumericUpDown badOutputNum;
        private ComboBox badOutputSym;
        private TextBox badOutputText;
        private Label labelBad;
        private Label labelGood;
        private TextBox goodOutputText;
        private ComboBox goodOutputSym;
        private NumericUpDown goodOutputNum;
        private Button clearSecondClass;
        private Button clearHeroReq1;
        private Button clearHeroReq2;
        private Button clearHeroReq4;
        private Button clearHeroReq5;
        private Button clearHeroReq3;
        private ToolStripMenuItem HeroCard;
        private NumericUpDown maxItems;
        private Label labelMaxItem;
        private PictureBox itemImg;
        private PictureBox itemImg2;
        private Label itemImgMore;
        private ContextMenuStrip previewContextMenu;
        private ToolStripMenuItem copyImageToClipboardToolStripMenuItem;
        private ToolStripMenuItem openImageLocationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}