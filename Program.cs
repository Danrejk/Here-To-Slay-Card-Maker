using System;
using System.Numerics;
using Raylib_cs;
using System.Resources;

namespace HereToSlayGen
{
    public class Program
    {
        static void Main(string[] args)
        {
            generate(0,"Test Leader", 5, "leader_pic.png", "Test description");
        }
        public static void generate(int language, string leaderName, int desiredClass, string leaderImg, string leaderDescription)
        {
            ResourceManager resourceManager = new ResourceManager("HereToSlay.Resources", typeof(Program).Assembly);

            Raylib.InitWindow(1, 1, "generator");

            Color LOW = new Color(35, 94, 57, 255);
            Color MAG = new Color(116, 46, 137, 255);
            Color NAJ = new Color(194, 81, 47, 255);
            Color STR = new Color(235, 171, 33, 255);
            Color WOJ = new Color(151, 40, 44, 255);
            Color ZLO = new Color(0, 78, 125, 255);

            const int NAME_FONT_SPACING = 0;
            const int TITLE_FONT_SPACING = 1;
            const int DESC_FONT_SPACING = 0;

            Color descColor = new Color(78, 78, 78, 255);

            const int CARD_WIDTH = 827;
            const int CARD_HEIGHT = 1417;

            const int NAME_SIZE = 60; // 60
            const int TITLE_SIZE = 35; // 35
            const int DESC_SIZE = 28; // 28

            Font nameFont = Raylib.LoadFontEx("fonts/PatuaOne-polish.ttf", NAME_SIZE, null, 1415); // this font has limited language support
            Font titleFont = Raylib.LoadFontEx("fonts/Helvetica.ttf", TITLE_SIZE, null, 1415); 
            Font descFont = Raylib.LoadFontEx("fonts/Helvetica.ttf", DESC_SIZE, null, 1415);

            bool gradientSetting = false;
            Image frame = Raylib.LoadImage("template/frame.png");
            Image bottom = Raylib.LoadImage("template/bottom.png");
            Image gradient = Raylib.LoadImage("template/gradient.png");
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

            if (gradientSetting) { Raylib.ImageDraw(ref card, gradient, imageRec, imageRec, Color.WHITE); }
            Raylib.ImageColorTint(ref frame, desiredColor);
            Raylib.ImageDraw(ref card, frame, imageRec, imageRec, Color.WHITE);
            Raylib.ImageDraw(ref card, bottom, imageRec, imageRec, Color.WHITE);
            Raylib.ImageDraw(ref card, classSymbol, imageRec, imageRec, Color.WHITE);

            // Leader Name
            Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2) + 3, 70 + 3), NAME_SIZE, NAME_FONT_SPACING, new Color(255, 255, 255, 127));
            Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2), 70), NAME_SIZE, NAME_FONT_SPACING, Color.BLACK);

            // Class
            Raylib.ImageDrawTextEx(ref card, titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2) + 2, 133 + 2), TITLE_SIZE, TITLE_FONT_SPACING, new Color(255, 255, 255, 127));
            Raylib.ImageDrawTextEx(ref card, titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2), 133), TITLE_SIZE, TITLE_FONT_SPACING, Color.BLACK);

            // Description
            Raylib.ImageDrawTextEx(ref card, descFont, leaderDescription, new Vector2(100, (CARD_HEIGHT - (200 / 2) - (leaderDescriptionSize.Y / 2) + 5)), DESC_SIZE, DESC_FONT_SPACING, descColor);
            //to do - fix line spacing

            Raylib.ExportImage(card, "test.png");
            Raylib.CloseWindow();
        }
    }
}
