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
            cardType = new ToolStripMenuItem();
            LeaderCard = new ToolStripMenuItem();
            MonsterCard = new ToolStripMenuItem();
            HeroCard = new ToolStripMenuItem();
            ItemCard = new ToolStripMenuItem();
            MagicCard = new ToolStripMenuItem();
            language = new ToolStripComboBox();
            classReq3 = new ComboBox();
            classReq2 = new ComboBox();
            classReq1 = new ComboBox();
            classReq4 = new ComboBox();
            labelReq = new Label();
            classReq5 = new ComboBox();
            badOutputNum = new NumericUpDown();
            badOutputSym = new ComboBox();
            badOutputText = new TextBox();
            labelBad = new Label();
            labelGood = new Label();
            goodOutputText = new TextBox();
            goodOutputSym = new ComboBox();
            goodOutputNum = new NumericUpDown();
            clearSecondClass = new Button();
            clearClassReq1 = new Button();
            clearClassReq2 = new Button();
            clearClassReq4 = new Button();
            clearClassReq5 = new Button();
            clearClassReq3 = new Button();
            maxItems = new NumericUpDown();
            labelMaxItem = new Label();
            itemImg = new PictureBox();
            itemImg2 = new PictureBox();
            itemImgMore = new Label();
            advancedGeneral = new PictureBox();
            advancedGeneralBox = new FlowLayoutPanel();
            alternativeColor = new CheckBox();
            altColorToolTip = new ToolTip(components);
            itemChosenClass = new ComboBox();
            labelAdditionalReq = new CheckBox();
            additionalReq = new TextBox();
            labelHeroBonus = new CheckBox();
            heroBonus = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)advancedGeneral).BeginInit();
            advancedGeneralBox.SuspendLayout();
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
            labelClass.Size = new Size(120, 20);
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
            selectImgButton.Cursor = Cursors.Hand;
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
            labelImg.Size = new Size(155, 20);
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
            descriptionText.ScrollBars = ScrollBars.Vertical;
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
            leaderImgToolTip.AutoPopDelay = 50000;
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { cardType, language });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 0, 0, 2);
            menuStrip1.Size = new Size(414, 25);
            menuStrip1.TabIndex = 29;
            menuStrip1.Text = "menuStrip1";
            // 
            // cardType
            // 
            cardType.BackColor = SystemColors.Control;
            cardType.DropDownItems.AddRange(new ToolStripItem[] { LeaderCard, MonsterCard, HeroCard, ItemCard, MagicCard });
            cardType.Name = "cardType";
            cardType.Size = new Size(71, 23);
            cardType.Text = "Card Type";
            // 
            // LeaderCard
            // 
            LeaderCard.Name = "LeaderCard";
            LeaderCard.Size = new Size(118, 22);
            LeaderCard.Text = "Leader";
            LeaderCard.Click += LeaderCard_Click;
            // 
            // MonsterCard
            // 
            MonsterCard.Name = "MonsterCard";
            MonsterCard.Size = new Size(118, 22);
            MonsterCard.Text = "Monster";
            MonsterCard.Click += MonsterCard_Click;
            // 
            // HeroCard
            // 
            HeroCard.Name = "HeroCard";
            HeroCard.Size = new Size(118, 22);
            HeroCard.Text = "Hero";
            HeroCard.Click += HeroCard_Click;
            // 
            // ItemCard
            // 
            ItemCard.Name = "ItemCard";
            ItemCard.Size = new Size(118, 22);
            ItemCard.Text = "Item";
            ItemCard.Click += ItemCard_Click;
            // 
            // MagicCard
            // 
            MagicCard.Name = "MagicCard";
            MagicCard.Size = new Size(118, 22);
            MagicCard.Text = "Magic";
            MagicCard.Click += MagicCard_Click;
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
            // classReq3
            // 
            classReq3.BackColor = Color.White;
            classReq3.DropDownStyle = ComboBoxStyle.DropDownList;
            classReq3.FlatStyle = FlatStyle.Flat;
            classReq3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            classReq3.FormattingEnabled = true;
            classReq3.Location = new Point(180, 303);
            classReq3.Margin = new Padding(3, 3, 0, 3);
            classReq3.Name = "classReq3";
            classReq3.Size = new Size(42, 25);
            classReq3.TabIndex = 30;
            classReq3.Visible = false;
            classReq3.SelectedIndexChanged += renderPreview;
            // 
            // classReq2
            // 
            classReq2.BackColor = Color.White;
            classReq2.DropDownStyle = ComboBoxStyle.DropDownList;
            classReq2.FlatStyle = FlatStyle.Flat;
            classReq2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            classReq2.FormattingEnabled = true;
            classReq2.Location = new Point(122, 303);
            classReq2.Margin = new Padding(3, 3, 0, 3);
            classReq2.Name = "classReq2";
            classReq2.Size = new Size(42, 25);
            classReq2.TabIndex = 31;
            classReq2.Visible = false;
            classReq2.SelectedIndexChanged += renderPreview;
            // 
            // classReq1
            // 
            classReq1.BackColor = Color.White;
            classReq1.DropDownStyle = ComboBoxStyle.DropDownList;
            classReq1.FlatStyle = FlatStyle.Flat;
            classReq1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            classReq1.FormattingEnabled = true;
            classReq1.Location = new Point(64, 303);
            classReq1.Margin = new Padding(3, 3, 0, 3);
            classReq1.Name = "classReq1";
            classReq1.Size = new Size(42, 25);
            classReq1.TabIndex = 32;
            classReq1.Visible = false;
            classReq1.SelectedIndexChanged += renderPreview;
            // 
            // classReq4
            // 
            classReq4.BackColor = Color.White;
            classReq4.DropDownStyle = ComboBoxStyle.DropDownList;
            classReq4.FlatStyle = FlatStyle.Flat;
            classReq4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            classReq4.FormattingEnabled = true;
            classReq4.Location = new Point(238, 303);
            classReq4.Margin = new Padding(3, 3, 0, 3);
            classReq4.Name = "classReq4";
            classReq4.Size = new Size(42, 25);
            classReq4.TabIndex = 33;
            classReq4.Visible = false;
            classReq4.SelectedIndexChanged += renderPreview;
            // 
            // labelReq
            // 
            labelReq.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelReq.BackColor = Color.Transparent;
            labelReq.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelReq.ForeColor = Color.White;
            labelReq.Location = new Point(60, 283);
            labelReq.Margin = new Padding(0);
            labelReq.Name = "labelReq";
            labelReq.RightToLeft = RightToLeft.No;
            labelReq.Size = new Size(172, 20);
            labelReq.TabIndex = 34;
            labelReq.Text = "Requirements";
            labelReq.TextAlign = ContentAlignment.BottomLeft;
            labelReq.Visible = false;
            // 
            // classReq5
            // 
            classReq5.BackColor = Color.White;
            classReq5.DropDownStyle = ComboBoxStyle.DropDownList;
            classReq5.FlatStyle = FlatStyle.Flat;
            classReq5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            classReq5.FormattingEnabled = true;
            classReq5.Location = new Point(296, 303);
            classReq5.Margin = new Padding(3, 3, 0, 3);
            classReq5.Name = "classReq5";
            classReq5.Size = new Size(42, 25);
            classReq5.TabIndex = 35;
            classReq5.Visible = false;
            classReq5.SelectedIndexChanged += renderPreview;
            // 
            // badOutputNum
            // 
            badOutputNum.Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Regular, GraphicsUnit.Point);
            badOutputNum.Location = new Point(84, 425);
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
            badOutputSym.Location = new Point(118, 426);
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
            badOutputText.Location = new Point(156, 426);
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
            labelBad.Location = new Point(81, 406);
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
            labelGood.Location = new Point(81, 447);
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
            goodOutputText.Location = new Point(156, 467);
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
            goodOutputSym.Location = new Point(118, 467);
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
            goodOutputNum.Location = new Point(84, 467);
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
            // clearClassReq1
            // 
            clearClassReq1.BackColor = SystemColors.ControlLight;
            clearClassReq1.FlatAppearance.BorderSize = 0;
            clearClassReq1.FlatStyle = FlatStyle.Flat;
            clearClassReq1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearClassReq1.ForeColor = Color.FromArgb(230, 44, 47);
            clearClassReq1.Location = new Point(106, 303);
            clearClassReq1.Margin = new Padding(0);
            clearClassReq1.Name = "clearClassReq1";
            clearClassReq1.Size = new Size(13, 25);
            clearClassReq1.TabIndex = 45;
            clearClassReq1.Text = "X";
            clearClassReq1.UseVisualStyleBackColor = false;
            clearClassReq1.Visible = false;
            clearClassReq1.Click += clearSelectedClass;
            // 
            // clearClassReq2
            // 
            clearClassReq2.BackColor = SystemColors.ControlLight;
            clearClassReq2.FlatAppearance.BorderSize = 0;
            clearClassReq2.FlatStyle = FlatStyle.Flat;
            clearClassReq2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearClassReq2.ForeColor = Color.FromArgb(230, 44, 47);
            clearClassReq2.Location = new Point(164, 303);
            clearClassReq2.Margin = new Padding(0);
            clearClassReq2.Name = "clearClassReq2";
            clearClassReq2.Size = new Size(13, 25);
            clearClassReq2.TabIndex = 46;
            clearClassReq2.Text = "X";
            clearClassReq2.UseVisualStyleBackColor = false;
            clearClassReq2.Visible = false;
            clearClassReq2.Click += clearSelectedClass;
            // 
            // clearClassReq4
            // 
            clearClassReq4.BackColor = SystemColors.ControlLight;
            clearClassReq4.FlatAppearance.BorderSize = 0;
            clearClassReq4.FlatStyle = FlatStyle.Flat;
            clearClassReq4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearClassReq4.ForeColor = Color.FromArgb(230, 44, 47);
            clearClassReq4.Location = new Point(280, 303);
            clearClassReq4.Margin = new Padding(0);
            clearClassReq4.Name = "clearClassReq4";
            clearClassReq4.Size = new Size(13, 25);
            clearClassReq4.TabIndex = 48;
            clearClassReq4.Text = "X";
            clearClassReq4.UseVisualStyleBackColor = false;
            clearClassReq4.Visible = false;
            clearClassReq4.Click += clearSelectedClass;
            // 
            // clearClassReq5
            // 
            clearClassReq5.BackColor = SystemColors.ControlLight;
            clearClassReq5.FlatAppearance.BorderSize = 0;
            clearClassReq5.FlatStyle = FlatStyle.Flat;
            clearClassReq5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearClassReq5.ForeColor = Color.FromArgb(230, 44, 47);
            clearClassReq5.Location = new Point(338, 303);
            clearClassReq5.Margin = new Padding(0);
            clearClassReq5.Name = "clearClassReq5";
            clearClassReq5.Size = new Size(13, 25);
            clearClassReq5.TabIndex = 49;
            clearClassReq5.Text = "X";
            clearClassReq5.UseVisualStyleBackColor = false;
            clearClassReq5.Visible = false;
            clearClassReq5.Click += clearSelectedClass;
            // 
            // clearClassReq3
            // 
            clearClassReq3.BackColor = SystemColors.ControlLight;
            clearClassReq3.FlatAppearance.BorderSize = 0;
            clearClassReq3.FlatStyle = FlatStyle.Flat;
            clearClassReq3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clearClassReq3.ForeColor = Color.FromArgb(230, 44, 47);
            clearClassReq3.Location = new Point(222, 303);
            clearClassReq3.Margin = new Padding(0);
            clearClassReq3.Name = "clearClassReq3";
            clearClassReq3.Size = new Size(13, 25);
            clearClassReq3.TabIndex = 47;
            clearClassReq3.Text = "X";
            clearClassReq3.UseVisualStyleBackColor = false;
            clearClassReq3.Visible = false;
            clearClassReq3.Click += clearSelectedClass;
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
            // advancedGeneral
            // 
            advancedGeneral.BackColor = Color.Transparent;
            advancedGeneral.Cursor = Cursors.Hand;
            advancedGeneral.Image = Properties.Resources.closed;
            advancedGeneral.Location = new Point(119, 668);
            advancedGeneral.Name = "advancedGeneral";
            advancedGeneral.Size = new Size(12, 12);
            advancedGeneral.SizeMode = PictureBoxSizeMode.Zoom;
            advancedGeneral.TabIndex = 55;
            advancedGeneral.TabStop = false;
            advancedGeneral.Visible = false;
            advancedGeneral.Click += advanced_Click;
            // 
            // advancedGeneralBox
            // 
            advancedGeneralBox.Controls.Add(alternativeColor);
            advancedGeneralBox.Location = new Point(134, 665);
            advancedGeneralBox.Margin = new Padding(0);
            advancedGeneralBox.Name = "advancedGeneralBox";
            advancedGeneralBox.Size = new Size(190, 18);
            advancedGeneralBox.TabIndex = 27;
            advancedGeneralBox.Visible = false;
            // 
            // alternativeColor
            // 
            alternativeColor.AutoSize = true;
            alternativeColor.ForeColor = Color.White;
            alternativeColor.Location = new Point(0, 0);
            alternativeColor.Margin = new Padding(0);
            alternativeColor.Name = "alternativeColor";
            alternativeColor.Padding = new Padding(0, 1, 0, 0);
            alternativeColor.Size = new Size(131, 20);
            alternativeColor.TabIndex = 0;
            alternativeColor.Text = "Alternative Color (?)";
            alternativeColor.UseVisualStyleBackColor = true;
            alternativeColor.CheckedChanged += renderPreview;
            // 
            // altColorToolTip
            // 
            altColorToolTip.AutoPopDelay = 50000;
            altColorToolTip.InitialDelay = 250;
            altColorToolTip.ReshowDelay = 100;
            altColorToolTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // itemChosenClass
            // 
            itemChosenClass.BackColor = Color.White;
            itemChosenClass.DropDownStyle = ComboBoxStyle.DropDownList;
            itemChosenClass.FlatStyle = FlatStyle.Flat;
            itemChosenClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            itemChosenClass.FormattingEnabled = true;
            itemChosenClass.Location = new Point(145, 249);
            itemChosenClass.Margin = new Padding(0);
            itemChosenClass.Name = "itemChosenClass";
            itemChosenClass.Size = new Size(120, 25);
            itemChosenClass.TabIndex = 56;
            itemChosenClass.SelectedIndexChanged += chosenClass_SelectedIndexChanged;
            // 
            // labelAdditionalReq
            // 
            labelAdditionalReq.AutoSize = true;
            labelAdditionalReq.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelAdditionalReq.ForeColor = Color.White;
            labelAdditionalReq.Location = new Point(33, 334);
            labelAdditionalReq.Name = "labelAdditionalReq";
            labelAdditionalReq.Size = new Size(172, 23);
            labelAdditionalReq.TabIndex = 57;
            labelAdditionalReq.Text = "Additional Requirement";
            labelAdditionalReq.UseVisualStyleBackColor = true;
            // 
            // additionalReq
            // 
            additionalReq.Location = new Point(33, 354);
            additionalReq.Multiline = true;
            additionalReq.Name = "additionalReq";
            additionalReq.ScrollBars = ScrollBars.Vertical;
            additionalReq.Size = new Size(171, 48);
            additionalReq.TabIndex = 58;
            // 
            // labelHeroBonus
            // 
            labelHeroBonus.AutoSize = true;
            labelHeroBonus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelHeroBonus.ForeColor = Color.White;
            labelHeroBonus.Location = new Point(210, 334);
            labelHeroBonus.Name = "labelHeroBonus";
            labelHeroBonus.Size = new Size(166, 23);
            labelHeroBonus.TabIndex = 60;
            labelHeroBonus.Text = "Additional Hero Bonus";
            labelHeroBonus.UseVisualStyleBackColor = true;
            // 
            // heroBonus
            // 
            heroBonus.Location = new Point(210, 353);
            heroBonus.Multiline = true;
            heroBonus.Name = "heroBonus";
            heroBonus.ScrollBars = ScrollBars.Vertical;
            heroBonus.Size = new Size(171, 48);
            heroBonus.TabIndex = 61;
            // 
            // Menu
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(39, 43, 52);
            BackgroundImage = Properties.Resources.gradient;
            ClientSize = new Size(828, 711);
            Controls.Add(heroBonus);
            Controls.Add(labelHeroBonus);
            Controls.Add(additionalReq);
            Controls.Add(labelAdditionalReq);
            Controls.Add(itemChosenClass);
            Controls.Add(advancedGeneralBox);
            Controls.Add(advancedGeneral);
            Controls.Add(itemImg2);
            Controls.Add(itemImg);
            Controls.Add(itemImgMore);
            Controls.Add(maxItems);
            Controls.Add(advancedNameBox);
            Controls.Add(badOutputText);
            Controls.Add(clearClassReq5);
            Controls.Add(clearClassReq4);
            Controls.Add(clearClassReq3);
            Controls.Add(clearClassReq2);
            Controls.Add(clearClassReq1);
            Controls.Add(classReq5);
            Controls.Add(classReq4);
            Controls.Add(classReq1);
            Controls.Add(classReq2);
            Controls.Add(classReq3);
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
            ((System.ComponentModel.ISupportInitialize)advancedGeneral).EndInit();
            advancedGeneralBox.ResumeLayout(false);
            advancedGeneralBox.PerformLayout();
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
        private ToolStripComboBox language;
        private ComboBox classReq3;
        private ComboBox classReq2;
        private ComboBox classReq1;
        private ComboBox classReq4;
        private Label labelReq;
        private ComboBox classReq5;
        private NumericUpDown badOutputNum;
        private ComboBox badOutputSym;
        private TextBox badOutputText;
        private Label labelBad;
        private Label labelGood;
        private TextBox goodOutputText;
        private ComboBox goodOutputSym;
        private NumericUpDown goodOutputNum;
        private Button clearSecondClass;
        private Button clearClassReq1;
        private Button clearClassReq2;
        private Button clearClassReq4;
        private Button clearClassReq5;
        private Button clearClassReq3;
        private NumericUpDown maxItems;
        private Label labelMaxItem;
        private PictureBox itemImg;
        private PictureBox itemImg2;
        private Label itemImgMore;
        private ContextMenuStrip previewContextMenu;
        private ToolStripMenuItem copyImageToClipboardToolStripMenuItem;
        private ToolStripMenuItem openImageLocationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private PictureBox advancedGeneral;
        private FlowLayoutPanel advancedGeneralBox;
        private CheckBox alternativeColor;
        private ToolTip altColorToolTip;
        private ToolStripMenuItem cardType;
        private ToolStripMenuItem MonsterCard;
        private ToolStripMenuItem HeroCard;
        private ToolStripMenuItem ItemCard;
        private ToolStripMenuItem MagicCard;
        private ToolStripMenuItem LeaderCard;
        private ComboBox itemChosenClass;
        private CheckBox labelAdditionalReq;
        private TextBox additionalReq;
        private CheckBox labelHeroBonus;
        private TextBox heroBonus;
    }
}