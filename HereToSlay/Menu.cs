using GeneratorBackend;
using HereToSlay.Properties;
using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;


namespace HereToSlay
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.LEADER;

            #region Fonts
            Font fontUI = FontLoader.GetFont(Properties.Resources.SourceSansPro, 10);
            FontLoader.ChangeFontForAllControls(this, fontUI);
            selectImg.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            Font fontUIsmall = FontLoader.GetFont(Properties.Resources.SourceSansPro, 9);
            gradient.Font = fontUIsmall;
            leaderWhite.Font = fontUIsmall;
            splitClass.Font = fontUIsmall;
            gitLabel1.Font = fontUIsmall;
            gitLabel2.Font = fontUIsmall;

            Font fontLeader = FontLoader.GetFont(Properties.Resources.PatuaOne_polish, 13);
            leaderNameText.Font = fontLeader;
            RENDER.Font = fontLeader;

            Font fontLeaderSmall = FontLoader.GetFont(Properties.Resources.PatuaOne_polish, 10);
            FontLoader.ChangeFontForAllLabels(this, fontLeaderSmall);
            LeaderCard.Font = fontLeaderSmall;
            MonsterCard.Font = fontLeaderSmall;
            #endregion

            #region ComboBoxes
#pragma warning disable CS8622 // the warnings were annoying me, so I disabled them
            language.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            language.ComboBox.DrawItem += ImageCBox.ComboBox_DrawItem;
            language.Items.Add(new ImageCBox("English", Properties.Resources.en));
            language.Items.Add(new ImageCBox("Polski", Properties.Resources.pl));
            language.SelectedIndex = Properties.Settings.Default.Language;
            initialLang = true;

            chosenClass.DrawMode = DrawMode.OwnerDrawFixed;
            chosenClass.DrawItem += ImageCBox.ComboBox_DrawItem;

            chosenSecondClass.DrawMode = DrawMode.OwnerDrawFixed;
            chosenSecondClass.DrawItem += ImageCBox.ComboBox_DrawItem;

            badOutputSym.DrawMode = DrawMode.OwnerDrawFixed;
            badOutputSym.DrawItem += CustomComboBox.ComboBox_DrawItem;
            badOutputSym.Items.Add(new CustomComboBox("+", Color.FromArgb(109, 166, 88)));

            goodOutputSym.DrawMode = DrawMode.OwnerDrawFixed;
            goodOutputSym.DrawItem += CustomComboBox.ComboBox_DrawItem;
            badOutputSym.Items.Add(new CustomComboBox("-", Color.FromArgb(230, 44, 47)));

#pragma warning restore CS8622
            #endregion

            switch (Properties.Settings.Default.CardType)
            {
                case 0:
                    LeaderCard_Click(null, null);
                    break;
                case 1:
                    MonsterCard_Click(null, null);
                    break;
            }
        }

        #region The Rendering ones
        private void RenderButton_Press(object sender, EventArgs e)
        {
            using SaveFileDialog SaveRenderDialog = new();
            SaveRenderDialog.Filter = "Supported Image Files (*.png;*.jpeg;*.jpg;*.gif;*.bmp;*.webp;*.pbm;*.tiff;*.tga;)|*.png;*.jpeg;*.jpg;*.gif;*.bmp;*.webp;*.pbm;*.tiff;*.tga;|All Files (*.*)|*.*";
            SaveRenderDialog.FilterIndex = 1;

            if (SaveRenderDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = SaveRenderDialog.FileName;
                GeneratorBackend.Program.Generate(filePath, language.SelectedIndex, leaderNameText.Text, chosenClass.SelectedIndex, chosenSecondClass.SelectedIndex, selectImgText.Text, descriptionText.Text, gradient.Checked, leaderWhite.Checked);
                previewImg.ImageLocation = filePath;
            }
        }

        private CancellationTokenSource? cancellationTokenSource;
        bool initialLang = false; //it's so that when the program opens and sets the remembered language, it doesn't render the preview automatically.
        private async void renderPreview(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            if (initialLang)
            {
                try
                {
                    int timer = 1;
                    while (timer > 0)
                    {
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();

                        await Task.Delay(500, cancellationTokenSource.Token);
                        timer--;
                    }
                    if (timer >= 0)
                    {
                        GeneratorBackend.Program.Generate(null, language.SelectedIndex, leaderNameText.Text, chosenClass.SelectedIndex, chosenSecondClass.SelectedIndex, selectImgText.Text, descriptionText.Text, gradient.Checked, leaderWhite.Checked);
                        previewImg.ImageLocation = Path.Combine(Directory.GetCurrentDirectory(), "preview.png"); ;
                    }
                }
                catch (OperationCanceledException) { }
            }
        }
        #endregion

        #region Language
        private void language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialLang == true) // so that it doesn't overwrite the setting, before it can be read
            {
                Properties.Settings.Default.Language = language.SelectedIndex;
                Properties.Settings.Default.Save();
            }

            switch (language.SelectedIndex)
            {
                case 1:
                    logo.Image = Properties.Resources.Logo1;
                    labelLeader.Text = "Nazwa lidera";
                    labelClass.Text = "Klasa lidera";
                    labelSecondClass.Text = "Druga klasa";
                    labelImg.Text = "Obrazek lidera";
                    labelDescription.Text = "Opis mocy";
                    leaderImgToolTip.ToolTipTitle = "Wymiary obazka";
                    leaderImgToolTip.SetToolTip(selectImg, "Obrazek lidera (nie ca³a karta) ma wymiary 745x1176. \nProgram automatycznie przytnie i przybli¿y obraz, je¿eli bêdzie to potrzebne.\n\nWspierane rozszerzenia plików:\n.png, .jpeg, .jpg, .gif (pierwsza klatka), .bmp, .webp, .pbm, .tiff, .tga");
                    gradient.Text = "Tylni gradient";
                    leaderWhite.Text = "Bia³a nazwa";
                    splitClass.Text = "Podwójna Klasa";
                    break;
                default:
                    logo.Image = Properties.Resources.Logo0;
                    labelLeader.Text = "Leader name";
                    labelClass.Text = "Leader class";
                    labelSecondClass.Text = "Second class";
                    labelImg.Text = "Leader image";
                    labelDescription.Text = "Description";
                    leaderImgToolTip.ToolTipTitle = "Image dimentions";
                    leaderImgToolTip.SetToolTip(selectImg, "The leader image (not the whole card) dimentions are 745x1176. \nThe program will automatically crop and zoom the image, if needed.\n\nSupported file extensions:\n.png, .jpeg, .jpg, .gif (first frame), .bmp, .webp, .pbm, .tiff, .tga");
                    gradient.Text = "Back gradient";
                    leaderWhite.Text = "White name";
                    splitClass.Text = "Split Class";
                    break;
            }
            LocaliseClassOptions(language.SelectedIndex); // change class options based on selected language
            renderPreview(sender, e);
        }
        int currentClassIndex;
        int currentSecondClassIndex;
        private void LocaliseClassOptions(int lang)
        {
            currentClassIndex = chosenClass.SelectedIndex;
            chosenClass.Items.Clear();

            currentSecondClassIndex = chosenSecondClass.SelectedIndex;
            chosenSecondClass.Items.Clear();


            switch (lang)
            {
                case 1:
                    chosenClass.Items.Add(new ImageCBox("£owca", Properties.Resources.lowca.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Mag", Properties.Resources.mag.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Bard", Properties.Resources.najebus.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Stra¿nik", Properties.Resources.straznik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Wojownik", Properties.Resources.wojownik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Z³odziej", Properties.Resources.zlodziej.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Druid", Properties.Resources.druid.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Awanturnik", Properties.Resources.awanturnik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Berserk", Properties.Resources.berserk.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Nekromanta", Properties.Resources.nekromanta.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Czarownik", Properties.Resources.czarownik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("WSZYSTKIE", Properties.Resources.empty.ToBitmap()));
                    break;
                default:
                    chosenClass.Items.Add(new ImageCBox("Ranger", Properties.Resources.lowca.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Wizard", Properties.Resources.mag.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Bard", Properties.Resources.najebus.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Guardian", Properties.Resources.straznik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Fighter", Properties.Resources.wojownik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Thief", Properties.Resources.zlodziej.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Druid", Properties.Resources.druid.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Warrior", Properties.Resources.awanturnik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Berserker", Properties.Resources.berserk.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Necromancer", Properties.Resources.nekromanta.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("Sorcerer", Properties.Resources.czarownik.ToBitmap()));
                    chosenClass.Items.Add(new ImageCBox("ALL", Properties.Resources.empty.ToBitmap()));
                    break;
            }
            chosenClass.SelectedIndex = currentClassIndex;

            foreach (var item in chosenClass.Items) { chosenSecondClass.Items.Add(item); }
            chosenSecondClass.SelectedIndex = currentSecondClassIndex;
        }
        #endregion
        private void chosenClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Icon = chosenClass.SelectedIndex switch
            {
                0 => Properties.Resources.lowca,
                1 => Properties.Resources.mag,
                2 => Properties.Resources.najebus,
                3 => Properties.Resources.straznik,
                4 => Properties.Resources.wojownik,
                5 => Properties.Resources.zlodziej,
                6 => Properties.Resources.druid,
                7 => Properties.Resources.awanturnik,
                8 => Properties.Resources.berserk,
                9 => Properties.Resources.nekromanta,
                10 => Properties.Resources.czarownik,
                11 => Properties.Resources.empty,
                _ => Properties.Resources.LEADER
            };
            renderPreview(sender, e);
        }
        private void chosenSecondClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderPreview(sender, e);
        }

        private void selectImg_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "Supported Image Files (*.png;*.jpeg;*.jpg;*.gif;*.bmp;*.webp;*.pbm;*.tiff;*.tga;)|*.png;*.jpeg;*.jpg;*.gif;*.bmp;*.webp;*.pbm;*.tiff;*.tga;|All Files (*.*)|*.*"; ;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                selectImgText.Text = selectedFilePath;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://github.com/Danrejk", UseShellExecute = true }); }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://github.com/Beukot", UseShellExecute = true }); }

        private void previewImg_Click(object sender, EventArgs e)
        {
            PictureBox? pictureBox = sender as PictureBox;

            if (pictureBox != null)
            {
                string previewImgPath = pictureBox.ImageLocation;
                string? folderPath = Path.GetDirectoryName(previewImgPath);
                if (folderPath != null)
                {
                    Process.Start("explorer.exe", folderPath);
                }
            }
        }

        private void advanced_Click(object sender, EventArgs e)
        {
            PictureBox? pictureBox = sender as PictureBox ?? throw new NotImplementedException();
            FlowLayoutPanel list = pictureBox.Name switch
            {
                "advancedName" => advancedNameBox,
                "advancedDesc" => advancedDescBox,
                "advancedClass" => advancedClassBox,
                _ => throw new NotImplementedException(),
            };
            list.Visible = !list.Visible;
            pictureBox.Image = list.Visible switch
            {
                true => Properties.Resources.open,
                false => Properties.Resources.closed
            };
        }

        private void splitClass_CheckStateChanged(object sender, EventArgs e)
        {
            switch (splitClass.Checked)
            {
                case false:
                    chosenSecondClass.Visible = false;
                    labelSecondClass.Visible = false;
                    clearSecondClass.Visible = false;
                    chosenClass.Location = new Point(chosenClass.Location.X + 63, chosenClass.Location.Y);
                    labelClass.Location = new Point(labelClass.Location.X + 63, labelClass.Location.Y);
                    chosenSecondClass.SelectedIndex = -1;
                    break;
                case true:
                    chosenClass.Location = new Point(chosenClass.Location.X - 63, chosenClass.Location.Y);
                    labelClass.Location = new Point(labelClass.Location.X - 63, labelClass.Location.Y);
                    chosenSecondClass.Visible = true;
                    labelSecondClass.Visible = true;
                    clearSecondClass.Visible = true;
                    break;
            }
        }

        private void LeaderCard_Click(object? sender, EventArgs? e) // TODO: make it one method
        {
            if (LeaderCard.Checked == false)
            {
                Properties.Settings.Default.CardType = 0;
                Properties.Settings.Default.Save();
                MonsterCard.Checked = false;
                MonsterCard.BackColor = SystemColors.Control;
                LeaderCard.Checked = true;
                LeaderCard.BackColor = SystemColors.ControlDark;

                chosenClass.Visible = true;
                labelClass.Visible = true;
                advancedClass.Visible = true;
                advancedClass.Image = Properties.Resources.closed;
                splitClass.Checked = false;

                labelImg.Location = new Point(115, 329);
                selectImgText.Location = new Point(119, 349);
                selectImg.Location = new Point(270, 349);

                heroReq1.Visible = false;
                heroReq2.Visible = false;
                heroReq3.Visible = false;
                heroReq4.Visible = false;
                heroReq5.Visible = false;

                labelBad.Visible = false;
                badOutputText.Visible = false;
                badOutputNum.Visible = false;
                badOutputSym.Visible = false;

                labelGood.Visible = false;
                goodOutputText.Visible = false;
                goodOutputNum.Visible = false;
                goodOutputSym.Visible = false;
            }
        }
        private void MonsterCard_Click(object? sender, EventArgs? e)
        {
            if (MonsterCard.Checked == false)
            {
                Properties.Settings.Default.CardType = 1;
                Properties.Settings.Default.Save();
                LeaderCard.Checked = false;
                LeaderCard.BackColor = SystemColors.Control;
                MonsterCard.Checked = true;
                MonsterCard.BackColor = SystemColors.ControlDark;

                chosenClass.Visible = false;
                labelClass.Visible = false;
                chosenSecondClass.Visible = false;
                labelSecondClass.Visible = false;
                advancedClass.Visible = false;
                advancedClassBox.Visible = false;

                labelImg.Location = new Point(115, 229);
                selectImgText.Location = new Point(119, 249);
                selectImg.Location = new Point(270, 249);

                heroReq1.Visible = true;
                heroReq2.Visible = true;
                heroReq3.Visible = true;
                heroReq4.Visible = true;
                heroReq5.Visible = true;

                labelBad.Visible = true;
                badOutputText.Visible = true;
                badOutputNum.Visible = true;
                badOutputSym.Visible = true;

                labelGood.Visible = true;
                goodOutputText.Visible = true;
                goodOutputNum.Visible = true;
                goodOutputSym.Visible = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chosenSecondClass.SelectedIndex = -1;
        }

        private void OutputSym_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                comboBox.BackColor = comboBox.SelectedIndex switch
                {
                    0 => Color.FromArgb(109, 166, 88),
                    1 => Color.FromArgb(230, 44, 47),
                    _ => throw new NotImplementedException(),
                };
            }
        }
    }
    class FontLoader
    {
        private static readonly PrivateFontCollection FontCollection = new();

        public static Font GetFont(byte[] fontData, float size)
        {
            new PrivateFontCollection();

            IntPtr fontBuffer = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontBuffer, fontData.Length);
            FontCollection.AddMemoryFont(fontBuffer, fontData.Length);

            return new Font(FontCollection.Families[0], size);
        }

        public static void ChangeFontForAllControls(Control control, Font fontUI)
        {
            foreach (Control c in control.Controls)
            {
                if (!c.Name.Contains("clear")) // don't change the font for the X boxes
                {
                    c.Font = fontUI;
                    if (c.Controls.Count > 0)
                    {
                        ChangeFontForAllControls(c, fontUI);
                    }
                }
            }
        }

        public static void ChangeFontForAllLabels(Control control, Font fontUI)
        {
            foreach (Control c in control.Controls)
            {
                if (c is Label label)
                {
                    label.Font = fontUI;
                }
                if (c.Controls.Count > 0)
                {
                    ChangeFontForAllLabels(c, fontUI);
                }
            }
        }
    }
    class ImageCBox
    {
        public string Text { get; set; }
        public Image Image { get; set; }

        public ImageCBox(string text, Image image)
        {
            Text = text;
            Image = image;
        }

        public static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || sender == null) return;

            e.DrawBackground();

            if (sender is ComboBox comboBox && comboBox.Items.Count > 0 && comboBox.Items[e.Index] is ImageCBox item)
            {
                if (e.Font != null)
                {
                    e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top, e.Bounds.Height, e.Bounds.Height);
                    e.Graphics.DrawString(item.Text, e.Font, Brushes.Black, e.Bounds.Left + e.Bounds.Height, e.Bounds.Top);
                }
            }

            e.DrawFocusRectangle();
        }
    }

    class CustomComboBox
    {
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }

        public CustomComboBox(string text, Color backgroundColor)
        {
            Text = text;
            BackgroundColor = backgroundColor;
        }

        public static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || sender == null) return;

            e.DrawBackground();

            if (sender is ComboBox comboBox && comboBox.Items.Count > 0 && comboBox.Items[e.Index] is CustomComboBox item)
            {
                if (e.Font != null)
                {
                    Brush backgroundColorBrush = new SolidBrush(item.BackgroundColor);
                    e.Graphics.FillRectangle(backgroundColorBrush, e.Bounds);

                    StringFormat stringFormat = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    };

                    Font customFont = FontLoader.GetFont(Properties.Resources.PatuaOne_polish, 14);
                    Brush textColorBrush = Brushes.White;
                    e.Graphics.DrawString(item.Text, customFont, textColorBrush, e.Bounds, stringFormat);
                }
            }

            e.DrawFocusRectangle();
        }
    }
}