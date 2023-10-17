﻿using System;
using System.Numerics;
using System.Resources;
using System.Text;
using System.Runtime.InteropServices;
using Raylib_cs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace GeneratorBackend
{
    public class AssetManager
    {
        private static AssetManager? instance;
        public Raylib_cs.Image frame { get; private set; }
        public Raylib_cs.Image bottom { get; private set; }
        public Raylib_cs.Image gradient { get; private set; }
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
            gradient = Raylib.LoadImage("template/gradient.png");
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
            Generate("render.png", 0,"Test Leader", new int[]{11, -1}, "C:\\Users\\SDanr\\Downloads\\uy0c1e63jusb1.jpg", "Test description", false, false); // if you want to test the generator, change the parameters here
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

        public static void Generate(string? renderLocation, int language, string leaderName, int[] desiredClass, string leaderImg, string leaderDescription, bool addGradient, bool leaderWhite)
        {
            ChangeLeaderImage(leaderImg);

            AssetManager inst = AssetManager.Instance;

            // This have to be loaded each time, to clear the image from the previous render
            Raylib_cs.Image card = Raylib.LoadImage("template/background.png");

            Raylib_cs.Image classSymbol;
            Raylib_cs.Color desiredColor;
            string leaderTitle;

            #region Classes
            switch (desiredClass[0])
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
                    desiredColor = new(151, 40, 44, 255);
                    break;
                case 5:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: złodziej",
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

            Raylib_cs.Image secondClassSymbol = new();
            Raylib_cs.Color desiredSecondColor = new();
            if (desiredClass[1] != -1)
            {
                switch (desiredClass[1])
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
                        desiredSecondColor = new(151, 40, 44, 255);
                        break;
                    case 5:
                        leaderTitle += language switch
                        {
                            1 => "/złodziej",
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
                Raylib.ImageCrop(ref secondClassSymbol, new Raylib_cs.Rectangle(0, 0, 413, 1417));
            }
            #endregion

            Vector2 leaderNameSize = Raylib.MeasureTextEx(inst.nameFont, leaderName, NAME_SIZE, NAME_FONT_SPACING);
            Vector2 leaderTitleSize = Raylib.MeasureTextEx(inst.titleFont, leaderTitle, TITLE_SIZE, TITLE_FONT_SPACING);

            Raylib_cs.Rectangle imageRec = new(0, 0, 827, 1417);

            Raylib.ImageDraw(ref card, leader, imageRec, new(41, 41, 745, 1176), Raylib_cs.Color.WHITE);
            Raylib.ImageDraw(ref card, inst.bottom, imageRec, imageRec, Raylib_cs.Color.WHITE);
            if (addGradient){ Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Raylib_cs.Color.WHITE); }

            Raylib.ImageDraw(ref card, classSymbol, imageRec, imageRec, Raylib_cs.Color.WHITE);
            Raylib_cs.Image frameTinted = Raylib.ImageCopy(inst.frame);
            if (desiredClass[1] != -1) { // check if there is a second class
                Raylib.ImageDraw(ref card, secondClassSymbol, imageRec, new(0, 0, 413, 1417), Raylib_cs.Color.WHITE);

                Raylib.ImageCrop(ref frameTinted, new Raylib_cs.Rectangle(0, 0, 414, 1417));
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(0, 0, 414, 1417), Raylib_cs.Color.WHITE);

                frameTinted = Raylib.ImageCopy(inst.frame);
                Raylib.ImageCrop(ref frameTinted, new Raylib_cs.Rectangle(413, 0, 414, 1417)); // while the sizes might look irregular. It's all because the image is 827px wide, so I have to compensate the 0,5px offset.
                Raylib.ImageColorTint(ref frameTinted, desiredSecondColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(414, 0, 413, 1417), Raylib_cs.Color.WHITE);
            }
            else {
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, imageRec, Raylib_cs.Color.WHITE);
            }

            Raylib.UnloadImage(frameTinted);
            Raylib.UnloadImage(classSymbol);
            Raylib.UnloadImage(secondClassSymbol);

            Raylib_cs.Color leaderColor = leaderWhite switch{
                true => Raylib_cs.Color.WHITE,
                false => Raylib_cs.Color.BLACK
            };
            Raylib_cs.Color leaderShadowColor = leaderWhite switch{
                true => new(0, 0, 0, 127),
                false => new(255, 255, 255, 127)
            };

            // Leader Name
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2) + 3, 70 + 3), NAME_SIZE, NAME_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - (leaderNameSize.X / 2), 70), NAME_SIZE, NAME_FONT_SPACING, leaderColor);

            // Class
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2) + 2, 123 + 2), TITLE_SIZE, TITLE_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2), 123), TITLE_SIZE, TITLE_FONT_SPACING, leaderColor);

            // Description
            DescriptionDraw(inst.descFont, leaderDescription, card, new(78, 78, 78, 255)); // 78 78 78 is the color of the background of the card description

            if (renderLocation == null)
            {
                Raylib.ExportImage(card, "preview.png");
            }
            else
            {
                Raylib.ExportImage(card, renderLocation);
            }
            Raylib.UnloadImage(card);
        }

        static Raylib_cs.Image leader = new();
        static Image<Rgba32>? image;
        static string lastpath = "";
        public static void ChangeLeaderImage(string path)
        {
            if (path == lastpath) { return; }
            lastpath = path;
            if (File.Exists(path))
            {
                Raylib.UnloadImage(leader);
                using var file = File.OpenRead(path);
                image = SixLabors.ImageSharp.Image.Load<Rgba32>(file);

                using var memoryStream = new MemoryStream();
                image.SaveAsPng(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                leader = Raylib.LoadImageFromMemory(".png", memoryStream.ToArray());

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

                Raylib.ImageCrop(ref leader, new Raylib_cs.Rectangle(cropX, cropY, targetWidth, targetHeight));
                Raylib.ImageResize(ref leader, 745, 1176);
                #endregion
            }
        }

        static void DescriptionDraw(Font font, string text, Raylib_cs.Image card, Raylib_cs.Color descColor)
        {
            Vector2 textSize = Raylib.MeasureTextEx(font, text, DESC_SIZE, DESC_FONT_SPACING);

            int len = text.Length;
            int targetLen = CARD_WIDTH - (DESC_MARGIN * 2);
            int targetLines = 1;
            int currentLine = 0;

            StringBuilder output = new(len);
            StringBuilder word = new(len);

            Vector2 wordLen = Raylib.MeasureTextEx(font, word.ToString(), DESC_SIZE, DESC_FONT_SPACING);
            Vector2 currentLen;

            // this is just to calculate the ammount of lines the text will take
            for (int i = 0; i < len; i++)
            {
                currentLen = Raylib.MeasureTextEx(font, output.ToString(), DESC_SIZE, DESC_FONT_SPACING);

                if (text[i] != ' ')
                {
                    word.Append(text[i]);
                    wordLen = Raylib.MeasureTextEx(font, word.ToString(), DESC_SIZE, DESC_FONT_SPACING);
                }
                else if (text[i] == ' ' && currentLen.X + wordLen.X <= targetLen)
                {
                    output.Append(word);
                    output.Append(' ');
                    word.Clear();
                }

                if (currentLen.X + wordLen.X >= targetLen)
                {
                    targetLines++;
                    output.Clear();
                }
            }

            output.Clear();
            word.Clear();

            int offset = 210 - (targetLines * 15); // On real cards, the offset changes with the ammount of lines, probably to better center the text visually.
            float textBlockCenter = ((offset - (targetLines * (DESC_SIZE + DESC_LINE_SPACING))) / 2) + DESC_LINE_SPACING;

            // Draw the text
            for (int i = 0; i < len; i++)
            {
                currentLen = Raylib.MeasureTextEx(font, output.ToString(), DESC_SIZE, DESC_FONT_SPACING);

                if (text[i] != ' ')
                {
                    word.Append(text[i]);
                    wordLen = Raylib.MeasureTextEx(font, word.ToString(), DESC_SIZE, DESC_FONT_SPACING);
                }
                else if (text[i] == ' ' && currentLen.X + wordLen.X <= targetLen) 
                { 
                    output.Append(word);
                    output.Append(' ');
                    word.Clear();
                }

                if (currentLen.X + wordLen.X >= targetLen)
                {
                    // Draw the whole line
                    Raylib.ImageDrawTextEx(ref card, font, output.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - offset) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), DESC_SIZE, DESC_FONT_SPACING, descColor);

                    output.Clear();
                    currentLine++; // move to the next line
                }
            }
            Raylib.ImageDrawTextEx(ref card, font, output.ToString() + word.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - offset) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), DESC_SIZE, DESC_FONT_SPACING, descColor);
        }
    }
}
