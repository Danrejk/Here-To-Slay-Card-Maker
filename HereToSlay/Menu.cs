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

            string[] langList = { "English", "Polski" };
            language.Items.AddRange(langList);
            language.SelectedIndex = Properties.Settings.Default.Language;
            initialLang = true;

            chosenClass.ItemHeight = 18;

            Font fontUI = FontLoader.GetFont(Properties.Resources.SourceSansPro, 10);
            FontLoader.ChangeFontForAllControls(this, fontUI);
            selectImg.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            Font fontUIsmall = FontLoader.GetFont(Properties.Resources.SourceSansPro, 9);
            gradient.Font = fontUIsmall;
            leaderWhite.Font = fontUIsmall;
            wordSplitting.Font = fontUIsmall;
            splitClass.Font = fontUIsmall;
            gitLabel1.Font = fontUIsmall;
            gitLabel2.Font = fontUIsmall;

            Font fontLeader = FontLoader.GetFont(Properties.Resources.PatuaOne_polish, 13);
            leaderNameText.Font = fontLeader;
            RENDER.Font = fontLeader;
        }

        #region The Rendering ones
        private void RenderButton_Press(object sender, EventArgs e)
        {
            using SaveFileDialog SaveRenderDialog = new();
            SaveRenderDialog.Filter = "Image Files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All Files (*.*)|*.*";
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
                    leaderImgToolTip.SetToolTip(selectImg, "Obrazek lidera (nie ca³a karta) ma wymiary 745x1176. \nProgram automatycznie przytnie i przybli¿y obraz, je¿eli bêdzie to potrzebne.\n\nWspierane rozszerzenia plików: .png, .gif (pierwsza klatka)");
                    gradient.Text = "Tylni gradient";
                    leaderWhite.Text = "Bia³a nazwa";
                    wordSplitting.Text = "Dzielenie wyrazów";
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
                    leaderImgToolTip.SetToolTip(selectImg, "The leader image (not the whole card) dimentions are 745x1176. \nThe program will automatically crop and zoom the image, if needed.\n\nSupported file extensions: .png, .gif (first frame)");
                    gradient.Text = "Back gradient";
                    leaderWhite.Text = "White name";
                    wordSplitting.Text = "Word Splitting";
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


            string[] classList = lang switch
            {
                1 => new string[] { "£owca", "Mag", "Bard", "Stra¿nik", "Wojownik", "Z³odziej", "Druid", "Awanturnik", "Berserk", "Nekromanta", "Czarownik", "BRAK" },
                _ => new string[] { "Ranger", "Wizard", "Bard", "Guardian", "Fighter", "Thief", "Druid", "Warrior", "Berserker", "Necromancer", "Sorcerer", "NONE" }
            };
            chosenClass.Items.AddRange(classList);
            chosenClass.SelectedIndex = currentClassIndex;

            chosenSecondClass.Items.AddRange(classList);
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
            openFileDialog.Filter = "Image Files|*.png;*.gif;*.jpg;*bmp;|All Files (*.*)|*.*";

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
                    chosenClass.Location = new Point(145, 239);
                    labelClass.Location = new Point(142, 219);
                    chosenSecondClass.SelectedIndex = -1;
                    break;
                case true:
                    chosenClass.Location = new Point(82, 239);
                    labelClass.Location = new Point(79, 219);
                    chosenSecondClass.Visible = true;
                    labelSecondClass.Visible = true;
                    break;
            }
        }
    }
    class FontLoader
    {
        private static readonly PrivateFontCollection FontCollection = new();

        public static Font GetFont(byte[] fontData, float size)
        {
            IntPtr fontBuffer = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontBuffer, fontData.Length);
            FontCollection.AddMemoryFont(fontBuffer, fontData.Length);

            return new Font(FontCollection.Families[0], size);
        }

        public static void ChangeFontForAllControls(Control control, Font fontUI)
        {
            foreach (Control c in control.Controls)
            {
                c.Font = fontUI;
                if (c.Controls.Count > 0)
                {
                    ChangeFontForAllControls(c, fontUI);
                }
            }
        }
    }
}