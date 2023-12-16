using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CA1416 // It onlyworks on Windows

namespace HereToSlay
{
    internal class ImageCBox
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

            if (sender is ComboBox comboBox &&
                comboBox.Items.Count > 0 &&
                comboBox.Items[e.Index] is ImageCBox item &&
                e.Font != null)
            {
                int imageWidth = e.Bounds.Height;
                int textStart = e.Bounds.Left + imageWidth;

                e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top, imageWidth, e.Bounds.Height);
                e.Graphics.DrawString(item.Text, e.Font, Brushes.Black, textStart, e.Bounds.Top);

                // Set the drop-down width to fit the widest item
                comboBox.DropDownWidth = Math.Max(comboBox.DropDownWidth, textStart + (int)e.Graphics.MeasureString(item.Text, e.Font).Width);
            }

            e.DrawFocusRectangle();
        }
    }

    internal class BackgroundColorCBox
    {
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }

        public BackgroundColorCBox(string text, Color backgroundColor)
        {
            Text = text;
            BackgroundColor = backgroundColor;
        }

        public static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || sender == null) return;

            e.DrawBackground();

            if (sender is ComboBox comboBox && comboBox.Items.Count > 0 && comboBox.Items[e.Index] is BackgroundColorCBox item)
            {
                if (e.Font != null)
                {
                    Brush backgroundColorBrush = new SolidBrush(item.BackgroundColor);
                    e.Graphics.FillRectangle(backgroundColorBrush, e.Bounds);

                    StringFormat stringFormat = new()
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
