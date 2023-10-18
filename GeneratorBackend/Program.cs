using System;
using System.Numerics;
using System.Resources;
using System.Text;
using System.Runtime.InteropServices;
using Raylib_cs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Xml.Linq;

namespace GeneratorBackend
{
    public class AssetManager
    {
        private static AssetManager? instance;
        public Raylib_cs.Image frame = Raylib.LoadImage("template/frame.png");
        public Raylib_cs.Image frameMonster = Raylib.LoadImage("template/frame_monster.png");
        public Raylib_cs.Image bottom = Raylib.LoadImage("template/bottom.png");
        public Raylib_cs.Image gradient = Raylib.LoadImage("template/gradient.png");

        public const int NAME_SIZE = 60; // 60
        public const int TITLE_SIZE = 49; // 49
        public const int DESC_SIZE = 38; // 38
        public Font nameFont { get; private set; }
        public Font titleFont { get; private set; }
        public Font descFont { get; private set; }

        public Raylib_cs.Image Ranger = Raylib.LoadImage("classes/ranger.png");
        public Raylib_cs.Image Wizard = Raylib.LoadImage("classes/wizard.png");
        public Raylib_cs.Image Bard = Raylib.LoadImage("classes/bard.png");
        public Raylib_cs.Image Guardian = Raylib.LoadImage("classes/guardian.png");
        public Raylib_cs.Image Fighter = Raylib.LoadImage("classes/fighter.png");
        public Raylib_cs.Image Thief = Raylib.LoadImage("classes/thief.png");
        public Raylib_cs.Image Druid = Raylib.LoadImage("classes/druid.png");
        public Raylib_cs.Image Warrior = Raylib.LoadImage("classes/warrior.png");
        public Raylib_cs.Image Berserker = Raylib.LoadImage("classes/berserker.png");
        public Raylib_cs.Image Necromancer = Raylib.LoadImage("classes/necromancer.png");
        public Raylib_cs.Image Sorcerer = Raylib.LoadImage("classes/sorcerer.png");
        public Raylib_cs.Image None = Raylib.LoadImage("classes/none.png");

        private AssetManager()
        {
            Raylib.InitWindow(1, 1, "Font Loader");
            Raylib.SetWindowPosition(-2000, -2000);

            nameFont = Raylib.LoadFontEx("fonts/PatuaOne-polish.ttf", NAME_SIZE, null, 382); // this font has limited language support (NOT only Polish and English btw)
            titleFont = Raylib.LoadFontEx("fonts/SourceSansPro.ttf", TITLE_SIZE, null, 1415);
            descFont = Raylib.LoadFontEx("fonts/SourceSansPro.ttf", DESC_SIZE, null, 1415);

            Raylib.CloseWindow();
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
            GenerateLeader("TestRender.png", 0,"Test Leader", new int[]{11, -1}, "", "Test description", false, false); // if you want to test the generator, change the parameters here
                                                               //"-1" here means that there is only one class.
        }

        // all of the font spacings work, but are simply not used as it turned out we don't need them, but YOU might. I dunno.
        const int NAME_FONT_SPACING = 0;
        const int TITLE_FONT_SPACING = 0;
        const int DESC_FONT_SPACING = 0;
        const int DESC_LINE_SPACING = 0;
        const int DESC_MARGIN = 100;

        // changing this, WON'T properly change the size of the card.
        const int CARD_WIDTH = 827;
        const int CARD_HEIGHT = 1417;

        private static readonly AssetManager inst = AssetManager.Instance;

        public static void GenerateLeader(string? renderLocation, int language, string name, int[] desiredClass, string leaderImg, string description, bool addGradient, bool nameWhite)
        {
            ChangeLeaderImage(leaderImg);

            // This has to be loaded each time, to clear the image from the previous render
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
                    classSymbol = inst.Ranger;
                    desiredColor = new(35, 94, 57, 255);
                    break;
                case 1:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: mag",
                        _ => "Party Leader: Wizard"};
                    classSymbol = inst.Wizard;
                    desiredColor = new(116, 46, 137, 255);
                    break;
                case 2:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: bard",
                        _ => "Party Leader: Bard"};
                    classSymbol = inst.Bard;
                    desiredColor = new(194, 81, 47, 255);
                    break;
                case 3:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: strażnik",
                        _ => "Party Leader: Guardian"};
                    classSymbol = inst.Guardian;
                    desiredColor = new(235, 171, 33, 255);
                    break;
                case 4:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: wojownik",
                        _ => "Party Leader: Fighter"};
                    classSymbol = inst.Fighter;
                    desiredColor = new(151, 40, 44, 255);
                    break;
                case 5:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: złodziej",
                        _ => "Party Leader: Thief"};
                    classSymbol = inst.Thief;
                    desiredColor = new(0, 78, 125, 255);
                    break;
                case 6:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: druid",
                        _ => "Party Leader: Druid"};
                    classSymbol = inst.Druid;
                    desiredColor = new(0, 171, 143, 255);
                    break;
                case 7:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: awanturnik",
                        _ => "Party Leader: Warrior"};
                    classSymbol =inst.Warrior;
                    desiredColor = new(94, 109, 180, 255);
                    break;
                case 8:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: berserk",
                        _ => "Party Leader: Berserker"};
                    classSymbol = inst.Berserker;
                    desiredColor = new(225, 131, 51, 255);
                    break;
                case 9:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: nekromanta",
                        _ => "Party Leader: Necromancer"};
                    classSymbol = inst.Necromancer;
                    desiredColor = new(213, 28, 106, 255);
                    break;
                case 10:
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny: czarownik",
                        _ => "Party Leader: Sorcerer"};
                    classSymbol = inst.Sorcerer;
                    desiredColor = new(29, 31, 29, 255);
                    break;
                default: // when no desired class is given it deafults to an empty class
                    leaderTitle = language switch{
                        1 => "Przywódca drużyny",
                        _ => "Party Leader"};
                    classSymbol = inst.None;
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
                        secondClassSymbol = Raylib.ImageCopy(inst.Ranger);
                        desiredSecondColor = new(35, 94, 57, 255);
                        break;
                    case 1:
                        leaderTitle += language switch
                        {
                            1 => "/mag",
                            _ => "/Wizard"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Wizard);
                        desiredSecondColor = new(116, 46, 137, 255);
                        break;
                    case 2:
                        leaderTitle += language switch
                        {
                            1 => "/bard",
                            _ => "/Bard"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Bard);
                        desiredSecondColor = new(194, 81, 47, 255);
                        break;
                    case 3:
                        leaderTitle += language switch
                        {
                            1 => "/strażnik",
                            _ => "/Guardian"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Guardian);
                        desiredSecondColor = new(235, 171, 33, 255);
                        break;
                    case 4:
                        leaderTitle += language switch
                        {
                            1 => "/wojownik",
                            _ => "/Fighter"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Fighter);
                        desiredSecondColor = new(151, 40, 44, 255);
                        break;
                    case 5:
                        leaderTitle += language switch
                        {
                            1 => "/złodziej",
                            _ => "/Thief"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Thief);
                        desiredSecondColor = new(0, 78, 125, 255);
                        break;
                    case 6:
                        leaderTitle += language switch
                        {
                            1 => "/druid",
                            _ => "/Druid"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Druid);
                        desiredSecondColor = new(0, 171, 143, 255);
                        break;
                    case 7:
                        leaderTitle += language switch
                        {
                            1 => "/awanturnik",
                            _ => "/Warrior"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Warrior);
                        desiredSecondColor = new(94, 109, 180, 255);
                        break;
                    case 8:
                        leaderTitle += language switch
                        {
                            1 => "/berserk",
                            _ => "/Berserker"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Berserker);
                        desiredSecondColor = new(225, 131, 51, 255);
                        break;
                    case 9:
                        leaderTitle += language switch
                        {
                            1 => "/nekromanta",
                            _ => "/Necromancer"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Necromancer);
                        desiredSecondColor = new(213, 28, 106, 255);
                        break;
                    case 10:
                        leaderTitle += language switch
                        {
                            1 => "/czarownik",
                            _ => "/Sorcerer"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.Sorcerer);
                        desiredSecondColor = new(29, 31, 29, 255);
                        break;
                    default:
                        leaderTitle += language switch
                        {
                            1 => "/przywódca",
                            _ => "/Leader"
                        };
                        secondClassSymbol = Raylib.ImageCopy(inst.None);
                        desiredSecondColor = new (91, 93, 92, 255);
                        break;
                }
                Raylib.ImageCrop(ref secondClassSymbol, new Raylib_cs.Rectangle(0, 0, 51, 102));
            }
            #endregion

            Raylib_cs.Rectangle imageRec = new(0, 0, 827, 1417);

            Raylib.ImageDraw(ref card, leader, imageRec, new(41, 41, 745, 1176), Raylib_cs.Color.WHITE);
            Raylib.ImageDraw(ref card, inst.bottom, imageRec, imageRec, Raylib_cs.Color.WHITE);

            if (addGradient){ Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Raylib_cs.Color.WHITE); }

            // Draw Class Symbol(s) and Colored Frame(s)
            Raylib_cs.Image frameTinted = Raylib.ImageCopy(inst.frame); // create a copy of the frame asset, so that the original is not modified
            Raylib.ImageDraw(ref card, classSymbol, imageRec, new(363, 1167, 102, 102), Raylib_cs.Color.WHITE);
            if (desiredClass[1] != -1) // check if there is a second class
            { 
                Raylib.ImageDraw(ref card, secondClassSymbol, imageRec, new(363, 1167, 51, 102), Raylib_cs.Color.WHITE);

                Raylib.ImageCrop(ref frameTinted, new Raylib_cs.Rectangle(0, 0, 414, 1417));
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(0, 0, 414, 1417), Raylib_cs.Color.WHITE);

                frameTinted = Raylib.ImageCopy(inst.frame); // clear the tinted frame for the second class

                Raylib.ImageCrop(ref frameTinted, new Raylib_cs.Rectangle(413, 0, 414, 1417)); // while the sizes might look irregular. It's all because the image is 827px wide, so I have to compensate the 0,5px offset.
                Raylib.ImageColorTint(ref frameTinted, desiredSecondColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(414, 0, 413, 1417), Raylib_cs.Color.WHITE);
            }
            else 
            {
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, imageRec, Raylib_cs.Color.WHITE);
            }

            Raylib.UnloadImage(frameTinted);
            Raylib.UnloadImage(secondClassSymbol);

            // Name and Title
            DrawNameAndTitle(name, leaderTitle, card, nameWhite);

            // Description
            DrawDescription(description, card);

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
        public static void GenerateMonster(string? renderLocation, int language, string name, int[] desiredClass, string monsterImg, string description, bool addGradient, bool nameWhite)
        {
            ChangeMonsterImage(monsterImg);

            // This has to be loaded each time, to clear the image from the previous render
            Raylib_cs.Image card = Raylib.LoadImage("template/background.png");
            Raylib_cs.Rectangle imageRec = new(0, 0, 827, 1417);

            Raylib.ImageDraw(ref card, monster, imageRec, new(41, 41, 745, 824), Raylib_cs.Color.WHITE);
            Raylib.ImageDraw(ref card, inst.bottom, imageRec, imageRec, Raylib_cs.Color.WHITE);

            if (addGradient) { Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Raylib_cs.Color.WHITE); }

            Raylib.ImageDraw(ref card, inst.frameMonster, imageRec, imageRec, Raylib_cs.Color.BLACK); // TODO: ensure correct color


            // Name and Title
            string titleText = language switch{
                1 => "Potwór",
                _ => "Monster"
            };
            DrawNameAndTitle(name, titleText, card, nameWhite);

            // Description
            DrawDescription(description, card);

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
        static void DrawNameAndTitle(string nameText, string titleText, Raylib_cs.Image card, bool nameWhite)
        {
            Raylib_cs.Color leaderColor = nameWhite switch
            {
                true => Raylib_cs.Color.WHITE,
                false => Raylib_cs.Color.BLACK
            };
            Raylib_cs.Color leaderShadowColor = nameWhite switch
            {
                true => new(0, 0, 0, 127),
                false => new(255, 255, 255, 127)
            };

            Vector2 nameSize = Raylib.MeasureTextEx(inst.nameFont, nameText, AssetManager.NAME_SIZE, NAME_FONT_SPACING);
            Vector2 titleSize = Raylib.MeasureTextEx(inst.titleFont, titleText, AssetManager.TITLE_SIZE, TITLE_FONT_SPACING);

            // Name
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH / 2) - (nameSize.X / 2) + 3, 70 + 3), AssetManager.NAME_SIZE, NAME_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH / 2) - (nameSize.X / 2), 70), AssetManager.NAME_SIZE, NAME_FONT_SPACING, leaderColor);

            // Title
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH / 2) - (titleSize.X / 2) + 2, 123 + 2), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH / 2) - (titleSize.X / 2), 123), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, leaderColor);
        }
        static void DrawDescription(string text, Raylib_cs.Image card)
        {
            Raylib_cs.Color descTextColor = new(78, 78, 78, 255); // 78 78 78 is the color of the description text

            Vector2 textSize = Raylib.MeasureTextEx(inst.descFont, text, AssetManager.DESC_SIZE, DESC_FONT_SPACING);

            int len = text.Length;
            int targetLen = CARD_WIDTH - (DESC_MARGIN * 2);
            int targetLines = 1;
            int currentLine = 0;

            StringBuilder output = new(len);
            StringBuilder word = new(len);

            Vector2 wordLen = Raylib.MeasureTextEx(inst.descFont, word.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING);
            Vector2 currentLen;

            // this is just to calculate the ammount of lines the text will take
            for (int i = 0; i < len; i++)
            {
                currentLen = Raylib.MeasureTextEx(inst.descFont, output.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING);

                if (text[i] != ' ')
                {
                    word.Append(text[i]);
                    wordLen = Raylib.MeasureTextEx(inst.descFont, word.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING);
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
            float textBlockCenter = ((offset - (targetLines * (AssetManager.DESC_SIZE + DESC_LINE_SPACING))) / 2) + DESC_LINE_SPACING;

            // Draw the text
            for (int i = 0; i < len; i++)
            {
                currentLen = Raylib.MeasureTextEx(inst.descFont, output.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING);

                if (text[i] != ' ')
                {
                    word.Append(text[i]);
                    wordLen = Raylib.MeasureTextEx(inst.descFont, word.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING);
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
                    Raylib.ImageDrawTextEx(ref card, inst.descFont, output.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - offset) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), AssetManager.DESC_SIZE, DESC_FONT_SPACING, descTextColor);

                    output.Clear();
                    currentLine++; // move to the next line
                }
            }
            Raylib.ImageDrawTextEx(ref card, inst.descFont, output.ToString() + word.ToString(), new Vector2(DESC_MARGIN, (CARD_HEIGHT - offset) + textBlockCenter + ((textSize.Y - 5 + DESC_LINE_SPACING) * currentLine)), AssetManager.DESC_SIZE, DESC_FONT_SPACING, descTextColor);
        }

        static Raylib_cs.Image leader = new();
        static Raylib_cs.Image monster = new();
        static Image<Rgba32>? image;
        static string lastPathLeader = "";
        static string lastPathMonster = "";
        static void ChangeLeaderImage(string path)
        {
            if (path == lastPathLeader) { return; }
            lastPathLeader = path;

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
        static void ChangeMonsterImage(string path)
        {
            if (path == lastPathMonster) { return; }
            lastPathMonster = path;

            if (File.Exists(path))
            {
                Raylib.UnloadImage(monster);
                using var file = File.OpenRead(path);
                image = SixLabors.ImageSharp.Image.Load<Rgba32>(file);

                using var memoryStream = new MemoryStream();
                image.SaveAsPng(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                monster = Raylib.LoadImageFromMemory(".png", memoryStream.ToArray());

                #region Image Crop
                float targetAspectRatio = 745.0f / 824.0f;
                int targetWidth, targetHeight;
                if (monster.width / (float)monster.height > targetAspectRatio)
                {
                    targetWidth = (int)(monster.height * targetAspectRatio);
                    targetHeight = monster.height;
                }
                else
                {
                    targetWidth = monster.width;
                    targetHeight = (int)(monster.width / targetAspectRatio);
                }

                int cropX = (monster.width - targetWidth) / 2;
                int cropY = (monster.height - targetHeight) / 2;

                Raylib.ImageCrop(ref monster, new Raylib_cs.Rectangle(cropX, cropY, targetWidth, targetHeight));
                Raylib.ImageResize(ref monster, 745, 824);
                #endregion
            }
        }
    }
}
