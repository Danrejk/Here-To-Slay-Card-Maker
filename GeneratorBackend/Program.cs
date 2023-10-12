using System;
using System.Numerics;
using Raylib_cs;
using System.Resources;
using System.Text;
using System.Runtime.InteropServices;

namespace GeneratorBackend
{
    public class AssetManager
    {
        private static AssetManager instance;
        public Image frame { get; private set; }
        public Image bottom { get; private set; }
        public Font nameFont { get; private set; }
        public Font titleFont { get; private set; }
        public Font descFont { get; private set; }

        private AssetManager()
        {
            const int NAME_SIZE = 60; // 60
            const int TITLE_SIZE = 49; // 49
            const int DESC_SIZE = 38; // 38
            
            Raylib.InitWindow(1, 1, "Font Loader");
            Raylib.SetWindowPosition(-2000, -2000);
            nameFont = Raylib.LoadFontEx("fonts/PatuaOne-polish.ttf", NAME_SIZE, null, 382); // this font has limited language support
            titleFont = Raylib.LoadFontEx("fonts/SourceSansPro.ttf", TITLE_SIZE, null, 1415);
            descFont = Raylib.LoadFontEx("fonts/SourceSansPro.ttf", DESC_SIZE, null, 1415);
            Raylib.CloseWindow();

            frame = Raylib.LoadImage("template/frame.png");
            bottom = Raylib.LoadImage("template/bottom.png");
        }

        public static AssetManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssetManager();
                }
                return instance;
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            Generate("render.png", 0,"Test Leader", 11, -1, "", "Test description", false, false); // if you want to test the generator, change the parameters here
            //"-1" here means that there is only one class.
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

        public static void ChangeLeaderImage(string path)
        {
            //leader = Raylib.LoadImage(path); #TODO
        }

        public static void Generate(string? renderLocation, int language, string leaderName, int desiredClass, int desiredSecondClass, string leaderImg, string leaderDescription, bool addGradient, bool leaderWhite)
        {
            Image leader = Raylib.LoadImage(leaderImg);
            Image card = Raylib.LoadImage("template/background.png");
            Image? gradient = null;
            if (addGradient) { gradient = Raylib.LoadImage("template/gradient.png"); }

            AssetManager inst = AssetManager.Instance;

            Image classSymbol;
            Color desiredColor;
            string leaderTitle;

            switch (desiredClass)
            {
                case 0:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: łowca",
                        _ => "Party Leader: Ranger"};
                    classSymbol = Raylib.LoadImage("classes/lowca.png");
                    desiredColor = new(35, 94, 57, 255);
                    break;
                case 1:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: mag",
                        _ => "Party Leader: Wizard"};
                    classSymbol = Raylib.LoadImage("classes/mag.png");
                    desiredColor = new(116, 46, 137, 255);
                    break;
                case 2:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: bard",
                        _ => "Party Leader: Bard"};
                    classSymbol = Raylib.LoadImage("classes/najebus.png");
                    desiredColor = new(194, 81, 47, 255);
                    break;
                case 3:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: strażnik",
                        _ => "Party Leader: Guardian"};
                    classSymbol = Raylib.LoadImage("classes/straznik.png");
                    desiredColor = new(235, 171, 33, 255);
                    break;
                case 4:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: wojownik",
                        _ => "Party Leader: Fighter"};
                    classSymbol = Raylib.LoadImage("classes/wojownik.png");
                    desiredColor = new(0, 78, 125, 255);
                    break;
                case 5:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: zlodziej",
                        _ => "Party Leader: Thief"};
                    classSymbol = Raylib.LoadImage("classes/zlodziej.png");
                    desiredColor = new(0, 78, 125, 255);
                    break;
                case 6:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: druid",
                        _ => "Party Leader: Druid"};
                    classSymbol = Raylib.LoadImage("classes/druid.png");
                    desiredColor = new(0, 171, 143, 255);
                    break;
                case 7:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: awanturnik",
                        _ => "Party Leader: Warrior"};
                    classSymbol = Raylib.LoadImage("classes/awanturnik.png");
                    desiredColor = new(94, 109, 180, 255);
                    break;
                case 8:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: berserk",
                        _ => "Party Leader: Berserker"};
                    classSymbol = Raylib.LoadImage("classes/berserk.png");
                    desiredColor = new(225, 131, 51, 255);
                    break;
                case 9:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: nekromanta",
                        _ => "Party Leader: Necromancer"};
                    classSymbol = Raylib.LoadImage("classes/nekromanta.png");
                    desiredColor = new(213, 28, 106, 255);
                    break;
                case 10:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: czarownik",
                        _ => "Party Leader: Sorcerer"};
                    classSymbol = Raylib.LoadImage("classes/czarownik.png");
                    desiredColor = new(29, 31, 29, 255);
                    break;
                default: // when no desired class is given it deafults to an empty class
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny",
                        _ => "Party Leader"};
                    classSymbol = Raylib.LoadImage("classes/empty.png");
                    desiredColor = new(91, 93, 92, 255);
                    break;
            }

            Image secondClassSymbol = new();
            Color desiredSecondColor = new();
            if (desiredSecondClass != -1)
            {
                switch (desiredSecondClass)
                {
                    case 0:
                        leaderTitle += language switch
                        {
                            1 => "/łowca",
                            _ => "/Ranger"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/lowca.png");
                        desiredSecondColor = new(35, 94, 57, 255);
                        break;
                    case 1:
                        leaderTitle += language switch
                        {
                            1 => "/mag",
                            _ => "/Wizard"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/mag.png");
                        desiredSecondColor = new(116, 46, 137, 255);
                        break;
                    case 2:
                        leaderTitle += language switch
                        {
                            1 => "/bard",
                            _ => "/Bard"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/najebus.png");
                        desiredSecondColor = new(194, 81, 47, 255);
                        break;
                    case 3:
                        leaderTitle += language switch
                        {
                            1 => "/strażnik",
                            _ => "/Guardian"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/straznik.png");
                        desiredSecondColor = new(235, 171, 33, 255);
                        break;
                    case 4:
                        leaderTitle += language switch
                        {
                            1 => "/wojownik",
                            _ => "/Fighter"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/wojownik.png");
                        desiredSecondColor = new(0, 78, 125, 255);
                        break;
                    case 5:
                        leaderTitle += language switch
                        {
                            1 => "/zlodziej",
                            _ => "/Thief"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/zlodziej.png");
                        desiredSecondColor = new(0, 78, 125, 255);
                        break;
                    case 6:
                        leaderTitle += language switch
                        {
                            1 => "/druid",
                            _ => "/Druid"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/druid.png");
                        desiredSecondColor = new(0, 171, 143, 255);
                        break;
                    case 7:
                        leaderTitle += language switch
                        {
                            1 => "/awanturnik",
                            _ => "/Warrior"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/awanturnik.png");
                        desiredSecondColor = new(94, 109, 180, 255);
                        break;
                    case 8:
                        leaderTitle += language switch
                        {
                            1 => "/berserk",
                            _ => "/Berserker"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/berserk.png");
                        desiredSecondColor = new(225, 131, 51, 255);
                        break;
                    case 9:
                        leaderTitle += language switch
                        {
                            1 => "/nekromanta",
                            _ => "/Necromancer"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/nekromanta.png");
                        desiredSecondColor = new(213, 28, 106, 255);
                        break;
                    case 10:
                        leaderTitle += language switch
                        {
                            1 => "/czarownik",
                            _ => "/Sorcerer"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/czarownik.png");
                        desiredSecondColor = new(29, 31, 29, 255);
                        break;
                    default:
                        leaderTitle += language switch
                        {
                            1 => "/przywódca",
                            _ => "/Leader"
                        };
                        secondClassSymbol = Raylib.LoadImage("classes/empty.png");
                        desiredSecondColor = new(91, 93, 92, 255);
                        break;
                }
                Raylib.ImageCrop(ref secondClassSymbol, new Rectangle(0, 0, 413, 1417));
            }
            
            Vector2 leaderNameSize = Raylib.MeasureTextEx(inst.nameFont, leaderName, NAME_SIZE, NAME_FONT_SPACING);
            Vector2 leaderTitleSize = Raylib.MeasureTextEx(inst.titleFont, leaderTitle, TITLE_SIZE, TITLE_FONT_SPACING);

            Rectangle imageRec = new(0, 0, 827, 1417);

            #region Image Crop
            float targetAspectRatio = 745.0f / 1176.0f;
            int targetWidth, targetHeight;
            if (leader.width / (float)leader.height > targetAspectRatio)
            {
                targetWidth = (int)(leader.height * targetAspectRatio);
                targetHeight = leader.height;
            }
            else
            {
                targetWidth = leader.width;
                targetHeight = (int)(leader.width / targetAspectRatio);
            }

            int cropX = (leader.width - targetWidth) / 2;
            int cropY = (leader.height - targetHeight) / 2;

            Raylib.ImageCrop(ref leader, new Rectangle(cropX, cropY, targetWidth, targetHeight));
            Raylib.ImageResize(ref leader, 745, 1176);
            #endregion
            Raylib.ImageDraw(ref card, leader, imageRec, new(41, 41, 745, 1176), Color.WHITE);
            Raylib.UnloadImage(leader);

            Image frameTinted = Raylib.ImageCopy(inst.frame);
            if (desiredSecondClass != -1) {
                Raylib.ImageCrop(ref frameTinted, new Rectangle(0, 0, 414, 1417));
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(0, 0, 414, 1417), Color.WHITE);

                frameTinted = Raylib.ImageCopy(inst.frame);
                Raylib.ImageCrop(ref frameTinted, new Rectangle(413, 0, 414, 1417)); // while the sizes might look irregular. It's all because the image is 827px wide, so I have to compensate the 0,5px offset
                Raylib.ImageColorTint(ref frameTinted, desiredSecondColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(414, 0, 413, 1417), Color.WHITE);
            }
            else {
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, imageRec, Color.WHITE);
            }

            if (gradient != null) { Raylib.ImageDraw(ref card, (Image)gradient, imageRec, imageRec, Color.WHITE); }
            Raylib.ImageDraw(ref card, inst.bottom, imageRec, imageRec, Color.WHITE);

            Raylib.ImageDraw(ref card, classSymbol, imageRec, imageRec, Color.WHITE);
            if (desiredSecondClass != -1){ Raylib.ImageDraw(ref card, secondClassSymbol, imageRec, new(0, 0, 413, 1417), Color.WHITE); }

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
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2) + 3, 70 + 3), NAME_SIZE, NAME_FONT_SPACING, leaderShadow);
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2), 70), NAME_SIZE, NAME_FONT_SPACING, leaderColor);

            // Class
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2) + 2, 123 + 2), TITLE_SIZE, TITLE_FONT_SPACING, leaderShadow);
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2), 123), TITLE_SIZE, TITLE_FONT_SPACING, leaderColor);

            // Description
            //Raylib.ImageDrawTextEx(ref card, descFont, leaderDescription, new Vector2(DESC_MARGIN, (CARD_HEIGHT - (200 / 2) - (leaderDescriptionSize.Y / 2) + 5)), DESC_SIZE, DESC_FONT_SPACING, descColor);
            DescriptionDraw(inst.descFont, leaderDescription, card, new(78, 78, 78, 255)); // 78 78 78 is the color of the background of the card description

            if (renderLocation == null)
            {
                Raylib.ExportImage(card, "preview.png");
            }
            else
            {
                Raylib.ExportImage(card, renderLocation);
            }
        }

        static void DescriptionDraw(Font font, string text, Image card, Color descColor)
        {
            Vector2 textSize = Raylib.MeasureTextEx(font, text, DESC_SIZE, DESC_FONT_SPACING);

            int len = text.Length;
            int targetLen = CARD_WIDTH - (DESC_MARGIN * 2);
            int targetLines = (int)(textSize.X / targetLen);
            int currentLine = 0;
            int outputPointer = 0;
            //int lastSpace;

            if (targetLines < 1) { targetLines = 1; }
            else { targetLines++; }

            int offset = 210 - (targetLines * 15); // I'm not sure why it's like this, but this does match the apperance on the real cards. maybe some other code is goofy, but if it works it works.
            float textBlockCenter = ((offset - (targetLines * (DESC_SIZE + DESC_LINE_SPACING))) / 2) + DESC_LINE_SPACING;

            StringBuilder output = new(len);
            StringBuilder word = new(len);
            //string word = "";
            string dash = "-";
            //string space = " ";

            Vector2 dashLen = Raylib.MeasureTextEx(font, dash, DESC_SIZE, DESC_FONT_SPACING);
            //Vector2 spaceLen = Raylib.MeasureTextEx(font, space, DESC_SIZE, DESC_FONT_SPACING);
            Vector2 wordLen = Raylib.MeasureTextEx(font, word.ToString(), DESC_SIZE, DESC_FONT_SPACING);
            Vector2 currentLen = Raylib.MeasureTextEx(font, output.ToString(), DESC_SIZE, DESC_FONT_SPACING);

            for (int i = 0; i < len; i++)
            {
                //if (text[i] == ' ') { lastSpace = i; }
                if (text[i] != ' ')
                {
                    word.Append(text[i]);
                    //output.Append(text[i]);
                    wordLen = Raylib.MeasureTextEx(font, word.ToString(), DESC_SIZE, DESC_FONT_SPACING);
                }
                else if (text[i] == ' ' && currentLen.X + wordLen.X <= targetLen) 
                { 
                    output.Append(word);
                    output.Append(" ");
                    word.Clear();
                }
                
                currentLen = Raylib.MeasureTextEx(font, output.ToString(), DESC_SIZE, DESC_FONT_SPACING);
                outputPointer++;

                //if (currentLen.X + dashLen.X >= targetLen)
                if (currentLen.X + wordLen.X >= targetLen)
                {
                    //output.Append(dash);
                    Raylib.ImageDrawTextEx(ref card, font, output.ToString() + word.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - offset) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), DESC_SIZE, DESC_FONT_SPACING, descColor);

                    output.Clear();
                    currentLine++;
                    outputPointer = 0;
                }
            }

            Raylib.ImageDrawTextEx(ref card, font, output.ToString() + word.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - offset) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), DESC_SIZE, DESC_FONT_SPACING, descColor);
        }
    }
}
