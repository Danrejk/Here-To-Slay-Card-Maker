using System;
using System.Numerics;
using Raylib_cs;
using System.Resources;
using System.Text;

namespace HereToSlayGen
{
    public class Program
    {
        static void Main(string[] args)
        {
            generate(0,"Test Leader", 5, "leader_pic.png", "Test description", false, false);
        }

        const int NAME_FONT_SPACING = 0;
        const int TITLE_FONT_SPACING = 0;
        const int DESC_FONT_SPACING = 0;
        const int DESC_LINE_SPACING = 0;
        const int DESC_MARGIN = 100;

        const int CARD_WIDTH = 827;
        const int CARD_HEIGHT = 1417;

        const int NAME_SIZE = 60; // 60
        const int TITLE_SIZE = 49; // 49
        const int DESC_SIZE = 38; // 38

        public static void generate(int language, string leaderName, int desiredClass, string leaderImg, string leaderDescription, bool addGradient, bool leaderWhite)
        {
            ResourceManager resourceManager = new ResourceManager("HereToSlay.Resources", typeof(Program).Assembly);

            Raylib.InitWindow(1, 1, "generator");

            Color LOW = new Color(35, 94, 57, 255);
            Color MAG = new Color(116, 46, 137, 255);
            Color NAJ = new Color(194, 81, 47, 255);
            Color STR = new Color(235, 171, 33, 255);
            Color WOJ = new Color(151, 40, 44, 255);
            Color ZLO = new Color(0, 78, 125, 255);

            Color descColor = new Color(78, 78, 78, 255);

            Font nameFont = Raylib.LoadFontEx("fonts/PatuaOne-polish.ttf", NAME_SIZE, null, 1415); // this font has limited language support
            Font titleFont = Raylib.LoadFontEx("fonts/SourceSansPro.ttf", TITLE_SIZE, null, 1415); 
            Font descFont = Raylib.LoadFontEx("fonts/SourceSansPro.ttf", DESC_SIZE, null, 1415);

            Image frame = Raylib.LoadImage("template/frame.png");
            Image bottom = Raylib.LoadImage("template/bottom.png");
            Image? gradient = null;
            if (addGradient) { gradient = Raylib.LoadImage("template/gradient.png"); }
            Image card = Raylib.LoadImage("template/background.png");
            Image leader = Raylib.LoadImage(leaderImg);

            Image classSymbol;

            Color desiredColor;
            string leaderTitle;

            switch (desiredClass)
            {
                case 0:
                    switch (language){
                        case 1: leaderTitle = "Przywódca drużyny: łowca"; break;
                        default: leaderTitle = "Party Leader: Ranger"; break;}
                    desiredColor = LOW;
                    classSymbol = Raylib.LoadImage("classes/lowca.png");
                    break;
                case 1:
                    switch (language){
                        case 1: leaderTitle = "Przywódca drużyny: mag"; ; break;
                        default: leaderTitle = "Party Leader: Wizard"; break;}
                    desiredColor = MAG;
                    classSymbol = Raylib.LoadImage("classes/mag.png");
                    break;
                case 2:
                    switch (language){
                        case 1: leaderTitle = "Przywódca drużyny: bard"; break;
                        default: leaderTitle = "Party Leader: Bard"; break;}
                    classSymbol = Raylib.LoadImage("classes/najebus.png");
                    desiredColor = NAJ;
                    break;
                case 3:
                    switch (language){
                        case 1: leaderTitle = "Przywódca drużyny: strażnik"; break;
                        default: leaderTitle = "Party Leader: Guardian"; break;}
                    classSymbol = Raylib.LoadImage("classes/straznik.png");
                    desiredColor = STR;
                    break;
                case 4:
                    switch (language){
                        case 1: leaderTitle = "Przywódca drużyny: wojownik"; break;
                        default: leaderTitle = "Party Leader: Fighter"; break;}
                    classSymbol = Raylib.LoadImage("classes/wojownik.png");
                    desiredColor = WOJ;
                    break;
                default: // when no desired class is given it deafults to thief
                    switch (language){
                        case 1: leaderTitle = "Przywódca drużyny: złodziej"; break;
                        default: leaderTitle = "Party Leader: Thief"; break;}
                    classSymbol = Raylib.LoadImage("classes/zlodziej.png");
                    desiredColor = ZLO;
                    break;
            }

            Vector2 leaderNameSize = Raylib.MeasureTextEx(nameFont, leaderName, NAME_SIZE, NAME_FONT_SPACING);
            Vector2 leaderTitleSize = Raylib.MeasureTextEx(titleFont, leaderTitle, TITLE_SIZE, TITLE_FONT_SPACING);
            Vector2 leaderDescriptionSize = Raylib.MeasureTextEx(descFont, leaderDescription, DESC_SIZE, DESC_FONT_SPACING);

            Rectangle imageRec = new(0, 0, 827, 1417);

            Raylib.ImageResize(ref leader, 745, 1176);
            //Raylib.ImageResize(ref leader, 827, 1417);
            Raylib.ImageDraw(ref card, leader, imageRec, new(41, 41, 745, 1176), Color.WHITE);

            if (gradient != null) { Raylib.ImageDraw(ref card, (Image)gradient, imageRec, imageRec, Color.WHITE); }
            Raylib.ImageColorTint(ref frame, desiredColor);
            Raylib.ImageDraw(ref card, frame, imageRec, imageRec, Color.WHITE);
            Raylib.ImageDraw(ref card, bottom, imageRec, imageRec, Color.WHITE);
            Raylib.ImageDraw(ref card, classSymbol, imageRec, imageRec, Color.WHITE);

            Color leaderColor;
            Color leaderShadow;
            if (leaderWhite)
            {
                leaderColor = Color.WHITE;
                leaderShadow = new(0, 0, 0, 127);
            }
            else
            {
                leaderColor = Color.BLACK;
                leaderShadow = new(255, 255, 255, 127);
            }

            // Leader Name
            Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2) + 3, 70 + 3), NAME_SIZE, NAME_FONT_SPACING, leaderShadow);
            Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2), 70), NAME_SIZE, NAME_FONT_SPACING, leaderColor);

            // Class
            Raylib.ImageDrawTextEx(ref card, titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2) + 2, 123 + 2), TITLE_SIZE, TITLE_FONT_SPACING, leaderShadow);
            Raylib.ImageDrawTextEx(ref card, titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2), 123), TITLE_SIZE, TITLE_FONT_SPACING, leaderColor);

            // Description
            //Raylib.ImageDrawTextEx(ref card, descFont, leaderDescription, new Vector2(DESC_MARGIN, (CARD_HEIGHT - (200 / 2) - (leaderDescriptionSize.Y / 2) + 5)), DESC_SIZE, DESC_FONT_SPACING, descColor);
            DescriptionDraw(descFont, leaderDescription, card, descColor);

            Raylib.ExportImage(card, "test.png");
            Raylib.CloseWindow();
        }

        static void DescriptionDraw(Font font, string text, Image card, Color descColor)
        {
            Vector2 textSize = Raylib.MeasureTextEx(font, text, DESC_SIZE, DESC_FONT_SPACING);

            int len = text.Length;
            int targetLen = CARD_WIDTH-(DESC_MARGIN*2);
            int targetLines = (int)(textSize.X / targetLen);
            int currentLine = 0;
            int outputPointer = 0;

            if (targetLines < 1) { targetLines = 2; }
            else { targetLines += 1; }

            float textBlockCenter = ((205 - (targetLines * (DESC_SIZE + DESC_LINE_SPACING))) / 2) + DESC_LINE_SPACING;

            StringBuilder output = new(len);
            string dash = "-";

            Vector2 dashLen = Raylib.MeasureTextEx(font, dash, DESC_SIZE, DESC_FONT_SPACING);
            Vector2 currentLen;

            for (int i = 0; i < len; i++)
            {
                output.Append(text[i]);
                currentLen = Raylib.MeasureTextEx(font, output.ToString(), DESC_SIZE, DESC_FONT_SPACING);
                outputPointer++;

                if (currentLen.X + dashLen.X >= targetLen)
                {
                    output.Append(dash);
                    Raylib.ImageDrawTextEx(ref card, font, output.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - 195) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), DESC_SIZE, DESC_FONT_SPACING, descColor);

                    output.Clear();
                    currentLine++;
                    outputPointer = 0;
                }
            }

            Raylib.ImageDrawTextEx(ref card, font, output.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - 195) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), DESC_SIZE, DESC_FONT_SPACING, descColor);
        }
    }
}
