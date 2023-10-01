using HereToSlayGen;
using HereToSlayGUI.Properties;

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
        }

        private void Button_Press(object sender, EventArgs e)
        {
            HereToSlayGen.Program.generate(language.SelectedIndex, leaderNameText.Text, chosenClass.SelectedIndex, selectImgText.Text, descriptionText.Text);
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
                    labelName.Text = "Nazwa lidera";
                    labelClass.Text = "Klasa lidera";
                    labelImg.Text = "Obrazek lidera";
                    labelDescription.Text = "Opis mocy";
                    break;
                default:
                    logo.Image = Properties.Resources.Logo0;
                    classes = new string[] { "Ranger", "Wizard", "Bard", "Guardian", "Fighter", "Thief" };
                    labelName.Text = "Leader name";
                    labelClass.Text = "Leader class";
                    labelImg.Text = "Leader image";
                    labelDescription.Text = "Description";
                    break;
            }
            chosenClass.Items.AddRange(classes);
            chosenClass.SelectedIndex = currentIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    selectImgText.Text = selectedFilePath;
                }
            }
        }
    }
}