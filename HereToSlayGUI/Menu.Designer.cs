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
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // RENDER
            // 
            RENDER.Location = new Point(290, 351);
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
            language.Location = new Point(722, 415);
            language.Name = "language";
            language.Size = new Size(66, 23);
            language.TabIndex = 1;
            language.SelectedIndexChanged += language_SelectedIndexChanged;
            // 
            // leaderNameText
            // 
            leaderNameText.Location = new Point(338, 156);
            leaderNameText.Name = "leaderNameText";
            leaderNameText.Size = new Size(100, 23);
            leaderNameText.TabIndex = 2;
            // 
            // labelLeader
            // 
            labelLeader.Location = new Point(157, 156);
            labelLeader.Name = "labelLeader";
            labelLeader.Size = new Size(175, 20);
            labelLeader.TabIndex = 4;
            labelLeader.Text = "Leader Name";
            labelLeader.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelDescription
            // 
            labelDescription.Location = new Point(184, 284);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(100, 20);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description";
            labelDescription.TextAlign = ContentAlignment.MiddleRight;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.Logo0;
            logo.Location = new Point(255, 12);
            logo.Name = "logo";
            logo.Size = new Size(264, 138);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 6;
            logo.TabStop = false;
            // 
            // chosenClass
            // 
            chosenClass.DropDownStyle = ComboBoxStyle.DropDownList;
            chosenClass.FormattingEnabled = true;
            chosenClass.Location = new Point(338, 190);
            chosenClass.Name = "chosenClass";
            chosenClass.Size = new Size(100, 23);
            chosenClass.TabIndex = 7;
            // 
            // labelClass
            // 
            labelClass.Location = new Point(232, 190);
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
            selectImg.Location = new Point(438, 226);
            selectImg.Name = "selectImg";
            selectImg.Size = new Size(25, 25);
            selectImg.TabIndex = 10;
            selectImg.Text = "...";
            selectImg.UseVisualStyleBackColor = true;
            // 
            // selectImgText
            // 
            selectImgText.Location = new Point(338, 227);
            selectImgText.Name = "selectImgText";
            selectImgText.Size = new Size(100, 23);
            selectImgText.TabIndex = 11;
            // 
            // labelImg
            // 
            labelImg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelImg.Location = new Point(232, 227);
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
            gradient.Location = new Point(525, 114);
            gradient.Name = "gradient";
            gradient.Size = new Size(124, 19);
            gradient.TabIndex = 13;
            gradient.Text = "Add back Gradient";
            gradient.UseVisualStyleBackColor = true;
            // 
            // leaderWhite
            // 
            leaderWhite.AutoSize = true;
            leaderWhite.Location = new Point(525, 131);
            leaderWhite.Name = "leaderWhite";
            leaderWhite.Size = new Size(150, 19);
            leaderWhite.TabIndex = 14;
            leaderWhite.Text = "Make Leader text White";
            leaderWhite.UseVisualStyleBackColor = true;
            // 
            // descriptionText
            // 
            descriptionText.Location = new Point(290, 257);
            descriptionText.Multiline = true;
            descriptionText.Name = "descriptionText";
            descriptionText.Size = new Size(185, 78);
            descriptionText.TabIndex = 15;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "Menu";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
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
    }
}