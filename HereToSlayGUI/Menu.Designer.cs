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
            button1 = new Button();
            language = new ComboBox();
            leaderNameText = new TextBox();
            labelName = new Label();
            labelDescription = new Label();
            logo = new PictureBox();
            chosenClass = new ComboBox();
            descriptionText = new RichTextBox();
            labelClass = new Label();
            openFileDialog1 = new OpenFileDialog();
            selectImg = new Button();
            selectImgText = new TextBox();
            labelImg = new Label();
            gradient = new CheckBox();
            LeaderWhite = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(290, 351);
            button1.Name = "button1";
            button1.Size = new Size(185, 74);
            button1.TabIndex = 0;
            button1.Text = "RENDER";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button_Press;
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
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(260, 159);
            labelName.Name = "labelName";
            labelName.Size = new Size(77, 15);
            labelName.TabIndex = 4;
            labelName.Text = "Leader Name";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(217, 288);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(67, 15);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description";
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
            chosenClass.FormattingEnabled = true;
            chosenClass.Location = new Point(338, 190);
            chosenClass.Name = "chosenClass";
            chosenClass.Size = new Size(100, 23);
            chosenClass.TabIndex = 7;
            chosenClass.SelectedIndexChanged += chosenClass_SelectedIndexChanged;
            // 
            // descriptionText
            // 
            descriptionText.Location = new Point(290, 256);
            descriptionText.Name = "descriptionText";
            descriptionText.Size = new Size(185, 78);
            descriptionText.TabIndex = 8;
            descriptionText.Text = "";
            // 
            // labelClass
            // 
            labelClass.AutoSize = true;
            labelClass.Location = new Point(260, 193);
            labelClass.Name = "labelClass";
            labelClass.Size = new Size(72, 15);
            labelClass.TabIndex = 9;
            labelClass.Text = "Leader Class";
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
            selectImg.Click += button2_Click;
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
            labelImg.AutoSize = true;
            labelImg.Location = new Point(254, 231);
            labelImg.Name = "labelImg";
            labelImg.Size = new Size(78, 15);
            labelImg.TabIndex = 12;
            labelImg.Text = "Leader Image";
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
            // LeaderWhite
            // 
            LeaderWhite.AutoSize = true;
            LeaderWhite.Location = new Point(525, 131);
            LeaderWhite.Name = "LeaderWhite";
            LeaderWhite.Size = new Size(150, 19);
            LeaderWhite.TabIndex = 14;
            LeaderWhite.Text = "Make Leader text White";
            LeaderWhite.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LeaderWhite);
            Controls.Add(gradient);
            Controls.Add(labelImg);
            Controls.Add(selectImgText);
            Controls.Add(selectImg);
            Controls.Add(labelClass);
            Controls.Add(descriptionText);
            Controls.Add(chosenClass);
            Controls.Add(logo);
            Controls.Add(labelDescription);
            Controls.Add(labelName);
            Controls.Add(leaderNameText);
            Controls.Add(language);
            Controls.Add(button1);
            Name = "Menu";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox language;
        private TextBox leaderNameText;
        private Label labelName;
        private Label labelDescription;
        private PictureBox logo;
        private ComboBox chosenClass;
        private RichTextBox descriptionText;
        private Label labelClass;
        private OpenFileDialog openFileDialog1;
        private Button selectImg;
        private TextBox selectImgText;
        private Label labelImg;
        private CheckBox gradient;
        private CheckBox LeaderWhite;
    }
}