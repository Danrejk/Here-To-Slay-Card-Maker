using HereToSlayGen;
using HereToSlayGUI.Properties;
using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HereToSlayGUI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            //language.Items.Add("English");
            //language.Items.Add("Polski");
            language.DrawMode = DrawMode.OwnerDrawFixed;
            language.DrawItem += LangIcons_DrawItem;

            Image[] langIconsList = new Image[]{
                Properties.Resources.uk,
                Properties.Resources.pl
            };
            language.DataSource = null;
            language.Items.Clear();
            langIcons.Images.AddRange(langIconsList);
            List<Tuple<string, int>> langList = new(){
                    new Tuple<string, int>("English", 0),
                    new Tuple<string, int>("Polski", 1),
            };
            language.DataSource = langList;

            //language.SelectedIndex = Properties.Settings.Default.Language;
            initialLang = true;

            logo.SizeMode = PictureBoxSizeMode.Zoom;

            Font fontUI = GetFont(Properties.Resources.SourceSansPro, 10);
            ChangeFontForAllControls(this, fontUI);
            Font fontLeader = GetFont(Properties.Resources.PatuaOne_polish, 12);
            leaderNameText.Font = fontLeader;
            RENDER.Font = fontLeader;
            gitLabel1.Font = GetFont(Properties.Resources.SourceSansPro, 9);
            gitLabel2.Font = GetFont(Properties.Resources.SourceSansPro, 9);
            selectImg.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.Icon = Properties.Resources.LEADER;

            chosenClass.DrawMode = DrawMode.OwnerDrawFixed;
            chosenClass.DrawItem += ClassIcons_DrawItem;
            chosenClass.ItemHeight = 18;
        }

        private void Button_Press(object sender, EventArgs e)
        {
            renderPreview(sender, e);
            HereToSlayGen.Program.Generate(false, language.SelectedIndex, leaderNameText.Text, chosenClass.SelectedIndex, selectImgText.Text, descriptionText.Text, gradient.Checked, leaderWhite.Checked);
            new Popup().ShowDialog();
        }

        int currentIndex;
        Image[] classIconsList = new Image[]{
                Properties.Resources.lowca.ToBitmap(),
                Properties.Resources.mag.ToBitmap(),
                Properties.Resources.najebus.ToBitmap(),
                Properties.Resources.straznik.ToBitmap(),
                Properties.Resources.wojownik.ToBitmap(),
                Properties.Resources.zlodziej.ToBitmap(),
                Properties.Resources.druid.ToBitmap(),
                Properties.Resources.awanturnik.ToBitmap(),
                Properties.Resources.berserk.ToBitmap(),
                Properties.Resources.nekromanta.ToBitmap(),
                Properties.Resources.czarownik.ToBitmap(),
                Properties.Resources.empty.ToBitmap()
            };

        private void AddClassOptions(int lang)
        {
            classIcons.Images.AddRange(classIconsList);
            currentIndex = chosenClass.SelectedIndex;
            chosenClass.DataSource = null;
            chosenClass.Items.Clear();

            List<Tuple<string, int>> classList = lang switch
            {
                1 => new()
                    {
                    new Tuple<string, int>("£owca", 1),
                    new Tuple<string, int>("Mag", 2),
                    new Tuple<string, int>("Bard", 3),
                    new Tuple<string, int>("Stra¿nik", 4),
                    new Tuple<string, int>("Wojownik", 5),
                    new Tuple<string, int>("Z³odziej", 6),
                    new Tuple<string, int>("Druid", 7),
                    new Tuple<string, int>("Awanturnik", 8),
                    new Tuple<string, int>("Berserk", 9),
                    new Tuple<string, int>("Nekromanta", 10),
                    new Tuple<string, int>("Czarownik", 11),
                    new Tuple<string, int>("brak", 12)
                    },
                _ => new()
                    {
                    new Tuple<string, int>("Ranger", 1),
                    new Tuple<string, int>("Wizard", 2),
                    new Tuple<string, int>("Bard", 3),
                    new Tuple<string, int>("Guardian", 4),
                    new Tuple<string, int>("Fighter", 5),
                    new Tuple<string, int>("Thief", 6),
                    new Tuple<string, int>("Druid", 7),
                    new Tuple<string, int>("Warrior", 8),
                    new Tuple<string, int>("Berserker", 9),
                    new Tuple<string, int>("Necromancer", 10),
                    new Tuple<string, int>("Sorcerer", 11),
                    new Tuple<string, int>("none", 12)
                    }
            };
            chosenClass.DataSource = classList;
            chosenClass.SelectedIndex = currentIndex;
        }

        // no idea what's going on here, this one I stole, but it works and looks nice so...
        private void ClassIcons_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Tuple<string, int> item = (Tuple<string, int>)chosenClass.Items[e.Index];
                string className = item.Item1;
                int iconIndex = item.Item2;
                Brush textBrush = SystemBrushes.WindowText;
                if (e.Index == -1)
                {
                    e.Graphics.FillRectangle(SystemBrushes.HotTrack, e.Bounds);
                    textBrush = SystemBrushes.HighlightText;
                }
                else
                {
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                        textBrush = SystemBrushes.HighlightText;
                    }
                    else
                    {
                        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                    }
                }
                if (iconIndex >= 0 && iconIndex < classIcons.Images.Count)
                {
                    Image icon = classIcons.Images[iconIndex];
                    e.Graphics.DrawImage(icon, e.Bounds.Left, e.Bounds.Top);
                }

                e.Graphics.DrawString(className, chosenClass.Font, textBrush, e.Bounds.Left + chosenClass.ItemHeight, e.Bounds.Top);
            }
        }
        private void LangIcons_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Tuple<string, int> item = (Tuple<string, int>)language.Items[e.Index];
                string langName = item.Item1;
                int iconIndex = item.Item2;
                Brush textBrush = SystemBrushes.WindowText;
                if (e.Index == -1)
                {
                    e.Graphics.FillRectangle(SystemBrushes.HotTrack, e.Bounds);
                    textBrush = SystemBrushes.HighlightText;
                }
                else
                {
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                        textBrush = SystemBrushes.HighlightText;
                    }
                    else
                    {
                        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                    }
                }
                if (iconIndex >= 0 && iconIndex < langIcons.Images.Count)
                {
                    Image icon = langIcons.Images[iconIndex];
                    e.Graphics.DrawImage(icon, e.Bounds.Left, e.Bounds.Top);
                }

                e.Graphics.DrawString(langName, language.Font, textBrush, e.Bounds.Left + language.ItemHeight, e.Bounds.Top);
            }
        } //make this into one function. for now it's a lazy fix

        private void language_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = language.SelectedIndex;
            Properties.Settings.Default.Save();

            switch (language.SelectedIndex)
            {
                case 1:
                    logo.Image = Properties.Resources.Logo1;
                    labelLeader.Text = "Nazwa lidera";
                    labelClass.Text = "Klasa lidera";
                    labelImg.Text = "Obrazek lidera";
                    labelDescription.Text = "Opis mocy";
                    break;
                default:
                    logo.Image = Properties.Resources.Logo0;
                    labelLeader.Text = "Leader name";
                    labelClass.Text = "Leader class";
                    labelImg.Text = "Leader image";
                    labelDescription.Text = "Description";
                    break;
            }
            AddClassOptions(language.SelectedIndex);
            renderPreview(sender, e);

        }

        // Font changes
        private void ChangeFontForAllControls(Control control, Font fontUI)
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
        private static Font GetFont(byte[] fontData, float size)
        {
            IntPtr data = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, data, fontData.Length);

            PrivateFontCollection fontCollection = new();
            fontCollection.AddMemoryFont(data, fontData.Length);

            if (fontCollection.Families.Length > 0)
            {
                FontFamily fontFamily = fontCollection.Families[0];
                Marshal.FreeCoTaskMem(data); // Release the allocated memory
                return new Font(fontFamily, size);
            }

            // Return a fallback font if the resource cannot be loaded
            return SystemFonts.DefaultFont;
        }

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
        private void chosenClass_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void selectImg_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "Image Files|*.png;*.gif;*.bmp|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                selectImgText.Text = selectedFilePath;
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
                    int timer = 2;
                    while (timer > 0)
                    {
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();

                        await Task.Delay(500, cancellationTokenSource.Token);
                        timer--;
                    }
                    if (timer >= 0)
                    {
                        previewImg.Image?.Dispose();
                        previewImg.Image = null;
                        HereToSlayGen.Program.Generate(true, language.SelectedIndex, leaderNameText.Text, chosenClass.SelectedIndex, selectImgText.Text, descriptionText.Text, gradient.Checked, leaderWhite.Checked);
                        previewImg.Image = Image.FromFile("preview.png");
                    }
                }
                catch (OperationCanceledException) { }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://github.com/Danrejk", UseShellExecute = true }); }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://github.com/Beukot", UseShellExecute = true }); }

        private void previewImg_Click(object sender, EventArgs e)
        {
            string? previewImgPath = Path.Combine(Directory.GetCurrentDirectory(), "preview.png");
            if (File.Exists(previewImgPath))
            {
                string? folderPath = Path.GetDirectoryName(previewImgPath);
                folderPath ??= string.Empty;
                Process.Start("explorer.exe", folderPath);
            }
        }
    }
}