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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;

#pragma warning disable CA1416 // It onlyworks on Windows test

namespace HereToSlay
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.LEADER;

            #region Fonts
            Font fontUI = FontLoader.GetFont("SourceSans3.ttf", 10);
            FontLoader.ChangeFontForAllControls(this, fontUI);
            selectImgButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            Font fontUIsmall = FontLoader.GetFont("SourceSansPro.ttf", 9);
            gradient.Font = fontUIsmall;
            nameWhite.Font = fontUIsmall;
            splitClass.Font = fontUIsmall;
            gitLabel1.Font = fontUIsmall;
            gitLabel2.Font = fontUIsmall;

            Font fontLeader = FontLoader.GetFont("PatuaOne_Polish.ttf", 13);
            nameText.Font = fontLeader;
            RENDER.Font = fontLeader;

            Font fontLeaderSmall = FontLoader.GetFont("PatuaOne_Polish.ttf", 10);
            FontLoader.ChangeFontForAllLabels(this, fontLeaderSmall);
            LeaderCard.Font = fontLeaderSmall;
            MonsterCard.Font = fontLeaderSmall;
            HeroCard.Font = fontLeaderSmall;
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
            chosenClass.ItemHeight = 19;

            chosenSecondClass.DrawMode = DrawMode.OwnerDrawFixed;
            chosenSecondClass.DrawItem += ImageCBox.ComboBox_DrawItem;
            chosenSecondClass.ItemHeight = 19;

            heroReq1.DrawMode = DrawMode.OwnerDrawFixed;
            heroReq1.DrawItem += ImageCBox.ComboBox_DrawItem;
            heroReq1.ItemHeight = 19;
            heroReq2.DrawMode = DrawMode.OwnerDrawFixed;
            heroReq2.DrawItem += ImageCBox.ComboBox_DrawItem;
            heroReq2.ItemHeight = 19;
            heroReq3.DrawMode = DrawMode.OwnerDrawFixed;
            heroReq3.DrawItem += ImageCBox.ComboBox_DrawItem;
            heroReq3.ItemHeight = 19;
            heroReq4.DrawMode = DrawMode.OwnerDrawFixed;
            heroReq4.DrawItem += ImageCBox.ComboBox_DrawItem;
            heroReq4.ItemHeight = 19;
            heroReq5.DrawMode = DrawMode.OwnerDrawFixed;
            heroReq5.DrawItem += ImageCBox.ComboBox_DrawItem;
            heroReq5.ItemHeight = 19;

            badOutputSym.DrawMode = DrawMode.OwnerDrawFixed;
            badOutputSym.DrawItem += BackgroundCBox.ComboBox_DrawItem;
            badOutputSym.ItemHeight = 19;
            badOutputSym.Items.Add(new BackgroundCBox("+", Color.FromArgb(109, 166, 88)));
            badOutputSym.Items.Add(new BackgroundCBox("-", Color.FromArgb(230, 44, 47)));
            badOutputSym.ItemHeight = 17;

            goodOutputSym.DrawMode = DrawMode.OwnerDrawFixed;
            goodOutputSym.DrawItem += BackgroundCBox.ComboBox_DrawItem;
            goodOutputSym.ItemHeight = 19;
            goodOutputSym.Items.Add(new BackgroundCBox("+", Color.FromArgb(109, 166, 88)));
            goodOutputSym.Items.Add(new BackgroundCBox("-", Color.FromArgb(230, 44, 47)));
            goodOutputSym.ItemHeight = 17;

            badOutputSym.SelectedIndex = 1;
            goodOutputSym.SelectedIndex = 0;

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
                switch (Properties.Settings.Default.CardType)
                {
                    case 0:
                        GeneratorBackend.Program.GenerateLeader(filePath, language.SelectedIndex, nameText.Text, new int[] { chosenClass.SelectedIndex, chosenSecondClass.SelectedIndex }, selectImgText.Text, descriptionText.Text, gradient.Checked, nameWhite.Checked);
                        break;
                    case 1:
                        RollOutput good = new((int)goodOutputNum.Value, goodOutputSym.SelectedIndex, goodOutputText.Text);
                        RollOutput bad = new((int)badOutputNum.Value, badOutputSym.SelectedIndex, badOutputText.Text);
                        int[] desiredRequirements = new int[] { heroReq1.SelectedIndex, heroReq2.SelectedIndex, heroReq3.SelectedIndex, heroReq4.SelectedIndex, heroReq5.SelectedIndex };
                        GeneratorBackend.Program.GenerateMonster(filePath, language.SelectedIndex, nameText.Text, desiredRequirements, good, bad, selectImgText.Text, descriptionText.Text, gradient.Checked, nameWhite.Checked);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                previewImg.ImageLocation = filePath;
            }
        }

        private CancellationTokenSource? cancellationTokenSource;
        bool initialLang = false; //it's so that when the program opens and sets the remembered language, it doesn't render the preview automatically.
        private async void renderPreview(object? sender, EventArgs? e)
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

                        await Task.Delay(200, cancellationTokenSource.Token);
                        timer--;
                    }
                    if (timer >= 0)
                    {
                        switch (Properties.Settings.Default.CardType)
                        {
                            case 0:
                                GeneratorBackend.Program.GenerateLeader(null, language.SelectedIndex, nameText.Text, new int[] { chosenClass.SelectedIndex, chosenSecondClass.SelectedIndex }, selectImgText.Text, descriptionText.Text, gradient.Checked, nameWhite.Checked);
                                break;
                            case 1:
                                RollOutput good = new((int)goodOutputNum.Value, goodOutputSym.SelectedIndex, goodOutputText.Text);
                                RollOutput bad = new((int)badOutputNum.Value, badOutputSym.SelectedIndex, badOutputText.Text);
                                int[] desiredRequirements = new int[] { heroReq1.SelectedIndex, heroReq2.SelectedIndex, heroReq3.SelectedIndex, heroReq4.SelectedIndex, heroReq5.SelectedIndex };
                                GeneratorBackend.Program.GenerateMonster(null, language.SelectedIndex, nameText.Text, desiredRequirements, good, bad, selectImgText.Text, descriptionText.Text, gradient.Checked, nameWhite.Checked);
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        previewImg.ImageLocation = Path.Combine(Directory.GetCurrentDirectory(), "preview.png"); ;
                    }
                }
                catch (OperationCanceledException) { }
            }
        }
        #endregion

        #region Language
        private void language_SelectedIndexChanged(object? sender, EventArgs? e)
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
                    labelLeader.Text = Properties.Settings.Default.CardType switch
                    {
                        1 => "Nazwa potwora",
                        _ => "Nazwa lidera"
                    };
                    labelClass.Text = "Klasa lidera";
                    labelSecondClass.Text = "Druga klasa";
                    labelImg.Text = Properties.Settings.Default.CardType switch
                    {
                        1 => "Obrazek potwora",
                        _ => "Obrazek lidera"
                    };
                    labelDescription.Text = "Opis mocy";
                    leaderImgToolTip.ToolTipTitle = "Wymiary obazka";
                    leaderImgToolTip.SetToolTip(selectImgButton, Properties.Settings.Default.CardType switch
                    {
                        1 => "Obrazek potwora (nie ca³a karta) ma wymiary 745x817. \nProgram automatycznie przytnie i przybli¿y obraz, je¿eli bêdzie to potrzebne.\n\nWspierane rozszerzenia plików:\n.png, .jpeg, .jpg, .gif (pierwsza klatka), .bmp, .webp, .pbm, .tiff, .tga",
                        _ => "Obrazek lidera (nie ca³a karta) ma wymiary 745x1176. \nProgram automatycznie przytnie i przybli¿y obraz, je¿eli bêdzie to potrzebne.\n\nWspierane rozszerzenia plików:\n.png, .jpeg, .jpg, .gif (pierwsza klatka), .bmp, .webp, .pbm, .tiff, .tga"
                    });
                    gradient.Text = "Tylni gradient";
                    nameWhite.Text = "Bia³a nazwa";
                    splitClass.Text = "Podwójna Klasa";
                    this.Text = "To ja go tnê - Generator kart";
                    labelBad.Text = "Wymagania rzutu - Pora¿ka";
                    labelGood.Text = "Wymagania rzutu - UBIJ potwora";
                    goodOutputText.Text = "UBIJ tego potwora";
                    labelReq.Text = "Wymagania bohaterów";
                    break;
                default:
                    logo.Image = Properties.Resources.Logo0;
                    labelLeader.Text = Properties.Settings.Default.CardType switch
                    {
                        1 => "Monster name",
                        _ => "Leader name"
                    };
                    labelClass.Text = "Leader class";
                    labelSecondClass.Text = "Second class";
                    labelImg.Text = Properties.Settings.Default.CardType switch
                    {
                        1 => "Monster image",
                        _ => "Leader image"
                    };
                    labelDescription.Text = "Description";
                    leaderImgToolTip.ToolTipTitle = "Image dimentions";
                    leaderImgToolTip.SetToolTip(selectImgButton, Properties.Settings.Default.CardType switch
                    {
                        1 => "The monster image (not the whole card) dimentions are 745x817. \nThe program will automatically crop and zoom the image, if needed.\n\nSupported file extensions:\n.png, .jpeg, .jpg, .gif (first frame), .bmp, .webp, .pbm, .tiff, .tga",
                        _ => "The leader image (not the whole card) dimentions are 745x1176. \nThe program will automatically crop and zoom the image, if needed.\n\nSupported file extensions:\n.png, .jpeg, .jpg, .gif (first frame), .bmp, .webp, .pbm, .tiff, .tga"
                    });
                    gradient.Text = "Back gradient";
                    nameWhite.Text = "White name";
                    splitClass.Text = "Split Class";
                    this.Text = "Here to Slay - Card generator";
                    labelBad.Text = "Roll Requirements - Fail";
                    labelGood.Text = "Roll Requirements - SLAY monster";
                    goodOutputText.Text = "SLAY this Monster card";
                    labelReq.Text = "Hero Requirements";
                    break;

            }
            LocaliseClassOptions(language.SelectedIndex); // change class options based on selected language
            renderPreview(sender, e);
        }
        int currentClassIndex;
        int currentSecondClassIndex;
        int currentHeroReq1Index;
        int currentHeroReq2Index;
        int currentHeroReq3Index;
        int currentHeroReq4Index;
        int currentHeroReq5Index;
        private void LocaliseClassOptions(int lang)
        {
            currentClassIndex = chosenClass.SelectedIndex;
            chosenClass.Items.Clear();

            currentSecondClassIndex = chosenSecondClass.SelectedIndex;
            chosenSecondClass.Items.Clear();

            currentHeroReq1Index = heroReq1.SelectedIndex;
            heroReq1.Items.Clear();
            currentHeroReq2Index = heroReq2.SelectedIndex;
            heroReq2.Items.Clear();
            currentHeroReq3Index = heroReq3.SelectedIndex;
            heroReq3.Items.Clear();
            currentHeroReq4Index = heroReq4.SelectedIndex;
            heroReq4.Items.Clear();
            currentHeroReq5Index = heroReq5.SelectedIndex;
            heroReq5.Items.Clear();

            switch (lang)
            {
                case 1:
                    heroReq1.Items.Add(new ImageCBox("BOHATER", Properties.Resources.bohater.ToBitmap()));
                    heroReq2.Items.Add(new ImageCBox("BOHATER", Properties.Resources.bohater.ToBitmap()));
                    heroReq3.Items.Add(new ImageCBox("BOHATER", Properties.Resources.bohater.ToBitmap()));
                    heroReq4.Items.Add(new ImageCBox("BOHATER", Properties.Resources.bohater.ToBitmap()));
                    heroReq5.Items.Add(new ImageCBox("BOHATER", Properties.Resources.bohater.ToBitmap()));

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
                    chosenClass.Items.Add(new ImageCBox("BRAK KLASY", Properties.Resources.empty.ToBitmap()));
                    break;
                default:
                    heroReq1.Items.Add(new ImageCBox("HERO", Properties.Resources.hero.ToBitmap()));
                    heroReq2.Items.Add(new ImageCBox("HERO", Properties.Resources.hero.ToBitmap()));
                    heroReq3.Items.Add(new ImageCBox("HERO", Properties.Resources.hero.ToBitmap()));
                    heroReq4.Items.Add(new ImageCBox("HERO", Properties.Resources.hero.ToBitmap()));
                    heroReq5.Items.Add(new ImageCBox("HERO", Properties.Resources.hero.ToBitmap()));

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
                    chosenClass.Items.Add(new ImageCBox("NO CLASS", Properties.Resources.empty.ToBitmap()));
                    break;
            }

            foreach (var item in chosenClass.Items)
            {
                chosenSecondClass.Items.Add(item);
                heroReq1.Items.Add(item);
                heroReq2.Items.Add(item);
                heroReq3.Items.Add(item);
                heroReq4.Items.Add(item);
                heroReq5.Items.Add(item);
            }

            chosenClass.SelectedIndex = currentClassIndex;
            chosenSecondClass.SelectedIndex = currentSecondClassIndex;

            heroReq1.SelectedIndex = currentHeroReq1Index;
            heroReq2.SelectedIndex = currentHeroReq2Index;
            heroReq3.SelectedIndex = currentHeroReq3Index;
            heroReq4.SelectedIndex = currentHeroReq4Index;
            heroReq5.SelectedIndex = currentHeroReq5Index;
        }
        #endregion
        private void chosenClass_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            if (Properties.Settings.Default.CardType == 0)
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
                chosenClass_SelectedIndexChanged(null, null);
                MonsterCard.Checked = false;
                MonsterCard.BackColor = SystemColors.Control;
                LeaderCard.Checked = true;
                LeaderCard.BackColor = SystemColors.ControlDark;

                language_SelectedIndexChanged(sender, e);

                chosenClass.Visible = true;
                labelClass.Visible = true;
                advancedClass.Visible = true;
                advancedClass.Image = Properties.Resources.closed;
                splitClass.Checked = false;

                labelImg.Location = new Point(labelImg.Location.X, 329);
                selectImgText.Location = new Point(selectImgText.Location.X, 349);
                selectImgButton.Location = new Point(selectImgButton.Location.X, 349);

                labelDescription.Location = new Point(labelDescription.Location.X, 426);
                descriptionText.Location = new Point(descriptionText.Location.X, 446);
                RENDER.Location = new Point(RENDER.Location.X, 525);

                labelReq.Visible = false;
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

                foreach (Control c in this.Controls)
                {
                    if (c.Name.Contains("clear")) { c.Visible = false; };
                }

                nameWhite.Checked = false;
            }
        }
        private void MonsterCard_Click(object? sender, EventArgs? e)
        {
            if (MonsterCard.Checked == false)
            {
                Properties.Settings.Default.CardType = 1;
                Properties.Settings.Default.Save();
                this.Icon = Properties.Resources.monster;
                LeaderCard.Checked = false;
                LeaderCard.BackColor = SystemColors.Control;
                MonsterCard.Checked = true;
                MonsterCard.BackColor = SystemColors.ControlDark;

                language_SelectedIndexChanged(sender, e);

                chosenClass.Visible = false;
                labelClass.Visible = false;
                chosenSecondClass.Visible = false;
                clearSecondClass.Visible = false;
                labelSecondClass.Visible = false;
                advancedClass.Visible = false;
                advancedClassBox.Visible = false;

                labelImg.Location = new Point(labelImg.Location.X, labelImg.Location.Y - 100);
                selectImgText.Location = new Point(selectImgText.Location.X, selectImgText.Location.Y - 100);
                selectImgButton.Location = new Point(selectImgButton.Location.X, selectImgButton.Location.Y - 100);

                descriptionText.Location = new Point(descriptionText.Location.X, descriptionText.Location.Y + 66);
                labelDescription.Location = new Point(labelDescription.Location.X, labelDescription.Location.Y + 66);
                RENDER.Location = new Point(RENDER.Location.X, RENDER.Location.Y + 66);

                labelReq.Visible = true;
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

                foreach (Control c in this.Controls)
                {
                    if (c.Name.Contains("clear") && c.Name != "clearSecondClass") { c.Visible = true; };
                }

                nameWhite.Checked = true;
            }
        }

        private void clearSelectedClass(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Name)
                {
                    case "clearSecondClass":
                        chosenSecondClass.SelectedIndex = -1;
                        break;
                    case "clearHeroReq1":
                        heroReq1.SelectedIndex = -1;
                        break;
                    case "clearHeroReq2":
                        heroReq2.SelectedIndex = -1;
                        break;
                    case "clearHeroReq3":
                        heroReq3.SelectedIndex = -1;
                        break;
                    case "clearHeroReq4":
                        heroReq4.SelectedIndex = -1;
                        break;
                    case "clearHeroReq5":
                        heroReq5.SelectedIndex = -1;
                        break;
                }
            }
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

                switch (comboBox.Name)
                {
                    case "goodOutputSym":
                        badOutputSym.SelectedIndex = goodOutputSym.SelectedIndex switch
                        {
                            0 => 1,
                            _ => 0,
                        };
                        break;
                    case "badOutputSym":
                        goodOutputSym.SelectedIndex = badOutputSym.SelectedIndex switch
                        {
                            0 => 1,
                            _ => 0,
                        };
                        break;
                }
            }
            renderPreview(sender, e);
        }
    }

    class FontLoader
    {
        private static readonly PrivateFontCollection FontCollection = new PrivateFontCollection();

        public static Font GetFont(string fontFileName, float size)
        {
            string executableLocation = AppDomain.CurrentDomain.BaseDirectory;
            string fontPath = Path.Combine(executableLocation, "Fonts", fontFileName);
            if (!File.Exists(fontPath))
            {
                throw new FileNotFoundException("Font file not found.");
            }

            FontCollection.AddFontFile(fontPath);
            FontFamily fontFamily = FontCollection.Families[0];

            Font font = new(fontFamily, size);
            return font;
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
    class BackgroundCBox
    {
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }

        public BackgroundCBox(string text, Color backgroundColor)
        {
            Text = text;
            BackgroundColor = backgroundColor;
        }

        public static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || sender == null) return;

            e.DrawBackground();

            if (sender is ComboBox comboBox && comboBox.Items.Count > 0 && comboBox.Items[e.Index] is BackgroundCBox item)
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

                    Font customFont = FontLoader.GetFont("PatuaOne_Polish.ttf", 14);
                    Brush textColorBrush = Brushes.White;
                    e.Graphics.DrawString(item.Text, customFont, textColorBrush, e.Bounds, stringFormat);
                }
            }

            e.DrawFocusRectangle();
        }
    }


}