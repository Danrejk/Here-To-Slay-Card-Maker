using HereToSlayGen;
using HereToSlayGUI.Properties;
using System.Drawing.Text;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

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

            logo.SizeMode = PictureBoxSizeMode.Zoom;

            Font fontUI = GetFont(Properties.Resources.SourceSansPro, 10);
            ChangeFontForAllControls(this, fontUI);
            Font fontLeader = GetFont(Properties.Resources.PatuaOne_polish, 11);
            leaderNameText.Font = fontLeader;
            labelLeader.Font = fontLeader;
            //descriptionText.Font = fontUi;
        }

        private void Button_Press(object sender, EventArgs e)
        {
            HereToSlayGen.Program.generate(language.SelectedIndex, leaderNameText.Text, chosenClass.SelectedIndex, selectImgText.Text, descriptionText.Text, gradient.Checked, leaderWhite.Checked);
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
        }

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

        private Font GetFont(byte[] fontData, float size)
        {
            IntPtr data = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, data, fontData.Length);

            PrivateFontCollection fontCollection = new PrivateFontCollection();
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
    }
}