using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CA1416 // It onlyworks on Windows

namespace HereToSlay
{
    internal class FontLoader
    {
        private static readonly PrivateFontCollection FontCollection = new PrivateFontCollection();

        public static Font GetFont(string fontFileName, float size)
        {
            string executableLocation = AppDomain.CurrentDomain.BaseDirectory;
            string fontPath = Path.Combine(executableLocation, "Assets\\Fonts", fontFileName);
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
                if (!c.Name.Contains("clear") && c is not NumericUpDown) // don't change the font for the X boxes or the Numeric boxes
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
}
