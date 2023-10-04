using HereToSlayGen;
using HereToSlayGUI.Properties;
using System.Drawing.Text;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace HereToSlayGUI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            language.Items.Add("English");
            language.Items.Add("Polish");

            language.SelectedIndex = Properties.Settings.Default.Language;
            initialLang = true;

            logo.SizeMode = PictureBoxSizeMode.Zoom;

            Font fontUI = GetFont(Properties.Resources.SourceSansPro, 9);
            ChangeFontForAllControls(this, fontUI);
            Font fontLeader = GetFont(Properties.Resources.PatuaOne_polish, 10);
            leaderNameText.Font = fontLeader;
            //labelLeader.Font = fontLeader;
            RENDER.Font = fontLeader;
            this.Icon = Properties.Resources.LEADER;
            //this.ClientSize = new Size(828, 709);
            //previewImg.Image = Image.FromFile("test.png");
        }

        private void Button_Press(object sender, EventArgs e)
        {
            HereToSlayGen.Program.Generate(false, language.SelectedIndex, leaderNameText.Text, chosenClass.SelectedIndex, selectImgText.Text, descriptionText.Text, gradient.Checked, leaderWhite.Checked);
        }

        int currentIndex;
        private void language_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = language.SelectedIndex;
            Properties.Settings.Default.Save();

            string[] classes;

            currentIndex = chosenClass.SelectedIndex;
            chosenClass.Items.Clear();
            switch (language.SelectedIndex)
            {
                case 1:
                    logo.Image = Properties.Resources.Logo1;
                    classes = new string[] { "£owca", "Mag", "Bard", "Stra¿nik", "Wojownik", "Z³odziej" };
                    labelLeader.Text = "Nazwa lidera";
                    labelClass.Text = "Klasa lidera";
                    labelImg.Text = "Obrazek lidera";
                    labelDescription.Text = "Opis mocy";
                    break;
                default:
                    logo.Image = Properties.Resources.Logo0;
                    classes = new string[] { "Ranger", "Wizard", "Bard", "Guardian", "Fighter", "Thief" };
                    labelLeader.Text = "Leader name";
                    labelClass.Text = "Leader class";
                    labelImg.Text = "Leader image";
                    labelDescription.Text = "Description";
                    break;
            }
            chosenClass.Items.AddRange(classes);
            chosenClass.SelectedIndex = currentIndex;
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
            switch (chosenClass.SelectedIndex)
            {
                case 0:
                    this.Icon = Properties.Resources.lowca;
                    break;
                case 1:
                    this.Icon = Properties.Resources.mag;
                    break;
                case 2:
                    this.Icon = Properties.Resources.najebus;
                    break;
                case 3:
                    this.Icon = Properties.Resources.straznik;
                    break;
                case 4:
                    this.Icon = Properties.Resources.wojownik;
                    break;
                case 5:
                    this.Icon = Properties.Resources.zlodziej;
                    break;
            }
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
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";

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
                    int timer = 1;
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
    }
}