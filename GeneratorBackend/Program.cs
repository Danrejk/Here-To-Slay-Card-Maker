using Raylib_cs;
using System.Numerics;
using System.Text;
using Color = Raylib_cs.Color;
using Image = Raylib_cs.Image;
using Rectangle = Raylib_cs.Rectangle;

namespace GeneratorBackend
{
    public class AssetManager
    {
        private static AssetManager? instance;
        public Image frame = Raylib.LoadImage("GeneratorAssets/template/frame.png");
        public Image frameMonster = Raylib.LoadImage("GeneratorAssets/template/frame_monster.png");
        public Image bottom = Raylib.LoadImage("GeneratorAssets/template/bottom.png");
        public Image gradient = Raylib.LoadImage("GeneratorAssets/template/gradient.png");
        public Image red = Raylib.LoadImage("GeneratorAssets/template/red.png");
        public Image green = Raylib.LoadImage("GeneratorAssets/template/green.png");

        public const int NAME_SIZE = 60; // 60
        public const int TITLE_SIZE = 52; // 49
        public const int REQ_SIZE = 49; // 49
        public const int ROLL_SIZE = 43; // 49
        public const int DESC_SIZE = 40; // 38

        public Font nameFont { get; private set; }
        public Font titleFont { get; private set; }
        public Font descFont { get; private set; }
        public Font reqFont { get; private set; }
        public Font rollFont { get; private set; }

        public Color bottomColor = new(244, 241, 229, 255);

        public Image Ranger = Raylib.LoadImage("GeneratorAssets/classes/ranger.png");
        public Image Wizard = Raylib.LoadImage("GeneratorAssets/classes/wizard.png");
        public Image Bard = Raylib.LoadImage("GeneratorAssets/classes/bard.png");
        public Image Guardian = Raylib.LoadImage("GeneratorAssets/classes/guardian.png");
        public Image Fighter = Raylib.LoadImage("GeneratorAssets/classes/fighter.png");
        public Image Thief = Raylib.LoadImage("GeneratorAssets/classes/thief.png");
        public Image Druid = Raylib.LoadImage("GeneratorAssets/classes/druid.png");
        public Image Warrior = Raylib.LoadImage("GeneratorAssets/classes/warrior.png");
        public Image Berserker = Raylib.LoadImage("GeneratorAssets/classes/berserker.png");
        public Image Necromancer = Raylib.LoadImage("GeneratorAssets/classes/necromancer.png");
        public Image Sorcerer = Raylib.LoadImage("GeneratorAssets/classes/sorcerer.png");
        public Image None = Raylib.LoadImage("GeneratorAssets/classes/none.png");
        public Image Hero = Raylib.LoadImage("GeneratorAssets/classes/hero.png");
        public Image Bohater = Raylib.LoadImage("GeneratorAssets/classes/bohater.png");

        private AssetManager()
        {
            Raylib.InitWindow(1, 1, "Font Loader");
            Raylib.SetWindowPosition(-2000, -2000);

            nameFont = Raylib.LoadFontEx("Fonts/PatuaOne_Polish.ttf", NAME_SIZE, null, 382); // this font has limited language support (NOT only Polish and English btw)
            titleFont = Raylib.LoadFontEx("Fonts/SourceSansPro.ttf", TITLE_SIZE, null, 1415);
            reqFont = Raylib.LoadFontEx("Fonts/SourceSansPro_Bold.ttf", REQ_SIZE, null, 1415);
            rollFont = Raylib.LoadFontEx("Fonts/PatuaOne_Polish.ttf", ROLL_SIZE, null, 1415);
            descFont = Raylib.LoadFontEx("Fonts/SourceSansPro.ttf", DESC_SIZE, null, 1415);

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
            GenerateLeader("TestRender.png", 0, "Test Leader", new int[] { 11, -1 }, "", "Test description", false, false); // if you want to test the generator, change the parameters here
                                                                                                                            //"-1" here means that there is only one class.

            //this might not work because I moved all of the Fonts to the "HereToSlay" or Menu project.
        }

        // all of the font spacings work, but are simply not used as it turned out we don't need them, but YOU might. I dunno.
        const int NAME_FONT_SPACING = 0;
        const int TITLE_FONT_SPACING = 1;
        const int REQ_FONT_SPACING = 0;
        const int ROLL_FONT_SPACING = 0;
        const int DESC_FONT_SPACING = 1;
        const int DESC_LINE_SPACING = 0;
        const int DESC_MARGIN = 87;

        // changing this, WON'T properly change the size of the card.
        const int CARD_WIDTH = 827;
        const int CARD_HEIGHT = 1417;

        private static readonly AssetManager inst = AssetManager.Instance;

        public static void GenerateLeader(string? renderLocation, int language, string name, int[] desiredClass, string leaderImg, string description, bool addGradient, bool nameWhite)
        {
            ChangeLeaderImage(leaderImg);

            // This has to be loaded each time, to clear the image from the previous render
            Image card = Raylib.LoadImage("GeneratorAssets/template/background.png");

            Image classSymbol;
            Color desiredColor;
            string leaderTitle;

            #region Classes
            switch (desiredClass[0])
            {
                case 0:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: łowca",
                        _ => "Party Leader: Ranger"
                    };
                    classSymbol = inst.Ranger;
                    desiredColor = new(35, 94, 57, 255);
                    break;
                case 1:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: mag",
                        _ => "Party Leader: Wizard"
                    };
                    classSymbol = inst.Wizard;
                    desiredColor = new(116, 46, 137, 255);
                    break;
                case 2:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: bard",
                        _ => "Party Leader: Bard"
                    };
                    classSymbol = inst.Bard;
                    desiredColor = new(194, 81, 47, 255);
                    break;
                case 3:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: strażnik",
                        _ => "Party Leader: Guardian"
                    };
                    classSymbol = inst.Guardian;
                    desiredColor = new(235, 171, 33, 255);
                    break;
                case 4:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: wojownik",
                        _ => "Party Leader: Fighter"
                    };
                    classSymbol = inst.Fighter;
                    desiredColor = new(151, 40, 44, 255);
                    break;
                case 5:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: złodziej",
                        _ => "Party Leader: Thief"
                    };
                    classSymbol = inst.Thief;
                    desiredColor = new(0, 78, 125, 255);
                    break;
                case 6:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: druid",
                        _ => "Party Leader: Druid"
                    };
                    classSymbol = inst.Druid;
                    desiredColor = new(0, 171, 143, 255);
                    break;
                case 7:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: awanturnik",
                        _ => "Party Leader: Warrior"
                    };
                    classSymbol = inst.Warrior;
                    desiredColor = new(94, 109, 180, 255);
                    break;
                case 8:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: berserk",
                        _ => "Party Leader: Berserker"
                    };
                    classSymbol = inst.Berserker;
                    desiredColor = new(225, 131, 51, 255);
                    break;
                case 9:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: nekromanta",
                        _ => "Party Leader: Necromancer"
                    };
                    classSymbol = inst.Necromancer;
                    desiredColor = new(213, 28, 106, 255);
                    break;
                case 10:
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny: czarownik",
                        _ => "Party Leader: Sorcerer"
                    };
                    classSymbol = inst.Sorcerer;
                    desiredColor = new(29, 31, 29, 255);
                    break;
                default: // when no desired class is given it deafults to an empty class
                    leaderTitle = language switch
                    {
                        1 => "Przywódca drużyny",
                        _ => "Party Leader"
                    };
                    classSymbol = inst.None;
                    desiredColor = new(91, 93, 92, 255);
                    break;
            }

            Image secondClassSymbol = new();
            Color desiredSecondColor = new();
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
                        desiredSecondColor = new(91, 93, 92, 255);
                        break;
                }
                Raylib.ImageCrop(ref secondClassSymbol, new Rectangle(0, 0, 51, 102));
            }
            #endregion

            Rectangle imageRec = new(0, 0, 827, 1417);

            Raylib.ImageDraw(ref card, leader, imageRec, new(41, 41, 745, 1176), Color.WHITE);
            Raylib.ImageDraw(ref card, inst.bottom, imageRec, imageRec, Color.WHITE);

            if (addGradient) { Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Color.WHITE); }

            // Draw Class Symbol(s) and Colored Frame(s)
            Image frameTinted = Raylib.ImageCopy(inst.frame); // create a copy of the frame asset, so that the original is not modified
            Raylib.ImageDraw(ref card, classSymbol, imageRec, new(363, 1167, 102, 102), Color.WHITE);
            if (desiredClass[1] != -1) // check if there is a second class
            {
                Raylib.ImageDraw(ref card, secondClassSymbol, imageRec, new(363, 1167, 51, 102), Color.WHITE);

                Raylib.ImageCrop(ref frameTinted, new Rectangle(0, 0, 414, 1417));
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(0, 0, 414, 1417), Color.WHITE);

                frameTinted = Raylib.ImageCopy(inst.frame); // clear the tinted frame for the second class

                Raylib.ImageCrop(ref frameTinted, new Rectangle(413, 0, 414, 1417)); // while the sizes might look irregular. It's all because the image is 827px wide, so I have to compensate the 0,5px offset.
                Raylib.ImageColorTint(ref frameTinted, desiredSecondColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(414, 0, 413, 1417), Color.WHITE);
            }
            else
            {
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, imageRec, Color.WHITE);
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

        public static void GenerateMonster(string? renderLocation, int language, string name, int[] desiredRequirements, RollOutput good, RollOutput bad, string monsterImg, string description, bool addGradient, bool nameWhite)
        {
            ChangeMonsterImage(monsterImg);

            // This has to be loaded each time, to clear the image from the previous render
            Image card = Raylib.LoadImage("GeneratorAssets/template/background.png");
            Rectangle imageRec = new(0, 0, 827, 1417);

            Raylib.ImageDraw(ref card, monster, imageRec, new(41, 41, 745, 824), Color.WHITE);
            Raylib.ImageDraw(ref card, inst.bottom, imageRec, imageRec, Color.WHITE);
            if (addGradient) { Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Color.WHITE); }
            Raylib.ImageDraw(ref card, inst.frameMonster, imageRec, imageRec, new(23, 26, 30, 255));

            string reqText = language switch
            {
                1 => "WYMAGANIA:",
                _ => "REQUIREMENT:"
            };

            Vector2 reqTextSize = Raylib.MeasureTextEx(inst.reqFont, reqText, AssetManager.REQ_SIZE, REQ_FONT_SPACING);
            Raylib.ImageDrawTextEx(ref card, inst.reqFont, reqText, new(87, 920), AssetManager.REQ_SIZE, REQ_FONT_SPACING, inst.bottomColor);

            #region Class Requirements
            // put the classless hero requirements at the end
            int[] orderedRequirements = desiredRequirements.OrderBy(x => x == 0).ToArray();

            // count how many class requirements there are
            int reqCount = 0;
            foreach (int req in orderedRequirements)
            {
                if (req == -1) { continue; }
                reqCount++;
            }

            // Draw the class requirements
            int reqIteration = 0;
            foreach (int req in orderedRequirements)
            {
                if (req == -1) { continue; }
                Image classSymbol = req switch
                {
                    0 => language switch
                    {
                        1 => inst.Bohater,
                        _ => inst.Hero
                    },
                    1 => inst.Ranger,
                    2 => inst.Wizard,
                    3 => inst.Bard,
                    4 => inst.Guardian,
                    5 => inst.Fighter,
                    6 => inst.Thief,
                    7 => inst.Druid,
                    8 => inst.Warrior,
                    9 => inst.Berserker,
                    10 => inst.Necromancer,
                    11 => inst.Sorcerer,
                    _ => inst.None
                };
                float iconsMargin = 83 + 13;
                // change the distance between icons, if there are 5, so that it better fits onto the card
                if (reqCount > 4)
                {
                    iconsMargin -= language switch
                    {
                        1 => 0, // polish needs less margin reduction, because the "REQUIREMENT" text is shorter
                        _ => 10 // YOU CAN MODIFY THIS. It might look better for your preferences, but for me I think this is the best option.
                    };
                }
                Raylib.ImageDraw(ref card, classSymbol, imageRec, new(93 + reqTextSize.X + 10 + reqIteration * iconsMargin, 902, 83, 83), Color.WHITE);
                reqIteration++;
            }
            #endregion

            // Draw roll requirements and their outcomes
            Raylib.ImageDraw(ref card, inst.red, imageRec, new(87, 1002, 78, 78), Color.WHITE);
            Raylib.ImageDraw(ref card, inst.green, imageRec, new(87, 1099, 78, 78), Color.WHITE);

            RollOutput red = bad;
            RollOutput green = good;
            if (bad.Symbol == 0) // check if "bad" has a positive value instead
            {
                red = good;
                green = bad;
            }
            Vector2 redNumSize = Raylib.MeasureTextEx(inst.rollFont, red.Value.ToString() + "-", AssetManager.ROLL_SIZE, ROLL_FONT_SPACING);
            Raylib.ImageDrawTextEx(ref card, inst.rollFont, red.Value.ToString() + "-", new(87 + 78 / 2 - redNumSize.X / 2, 1002 + 78 / 2 - redNumSize.Y / 2), AssetManager.ROLL_SIZE, ROLL_FONT_SPACING, inst.bottomColor);
            Vector2 greenNumSize = Raylib.MeasureTextEx(inst.rollFont, green.Value.ToString() + "+", AssetManager.ROLL_SIZE, ROLL_FONT_SPACING);
            Raylib.ImageDrawTextEx(ref card, inst.rollFont, green.Value.ToString() + "+", new(87 + 78 / 2 - greenNumSize.X / 2, 1099 + 78 / 2 - greenNumSize.Y / 2), AssetManager.ROLL_SIZE, ROLL_FONT_SPACING, inst.bottomColor);

            Raylib.ImageDrawTextEx(ref card, inst.descFont, red.Outcome, new(87 + 78 + 24, 1002 + 78 / 2 - AssetManager.DESC_SIZE / 2 + 2), AssetManager.DESC_SIZE, DESC_FONT_SPACING, inst.bottomColor);
            Raylib.ImageDrawTextEx(ref card, inst.descFont, green.Outcome, new(87 + 78 + 24, 1099 + 78 / 2 - AssetManager.DESC_SIZE / 2 + 2), AssetManager.DESC_SIZE, DESC_FONT_SPACING, inst.bottomColor);

            // Name and Title
            string titleText = language switch
            {
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

        static void DrawNameAndTitle(string nameText, string titleText, Image card, bool nameWhite)
        {
            Color leaderColor = nameWhite switch
            {
                true => Color.WHITE,
                false => Color.BLACK
            };
            Color leaderShadowColor = nameWhite switch
            {
                true => new(0, 0, 0, 127),
                false => new(255, 255, 255, 127)
            };

            Vector2 nameSize = Raylib.MeasureTextEx(inst.nameFont, nameText, AssetManager.NAME_SIZE, NAME_FONT_SPACING);
            Vector2 titleSize = Raylib.MeasureTextEx(inst.titleFont, titleText, AssetManager.TITLE_SIZE, TITLE_FONT_SPACING);

            // Name
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH / 2) - (nameSize.X / 2) + 3, 67 + 3), AssetManager.NAME_SIZE, NAME_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH / 2) - (nameSize.X / 2), 67), AssetManager.NAME_SIZE, NAME_FONT_SPACING, leaderColor);

            // Title
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH / 2) - (titleSize.X / 2) + 2, 118 + 2), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH / 2) - (titleSize.X / 2), 118), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, leaderColor);
        }

        static void DrawDescription(string text, Image card)
        {
            Color descTextColor = new(78, 78, 78, 255); // 78 78 78 is the color of the description text

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

        static Image leader = new();
        static Image monster = new();
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
                if (leader.Width / (float)leader.Height > targetAspectRatio)
                {
                    targetWidth = (int)(leader.Height * targetAspectRatio);
                    targetHeight = leader.Height;
                }
                else
                {
                    targetWidth = leader.Width;
                    targetHeight = (int)(leader.Width / targetAspectRatio);
                }

                int cropX = (leader.Width - targetWidth) / 2;
                int cropY = (leader.Height - targetHeight) / 2;

                Raylib.ImageCrop(ref leader, new Rectangle(cropX, cropY, targetWidth, targetHeight));
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
                if (monster.Width / (float)monster.Height > targetAspectRatio)
                {
                    targetWidth = (int)(monster.Height * targetAspectRatio);
                    targetHeight = monster.Height;
                }
                else
                {
                    targetWidth = monster.Width;
                    targetHeight = (int)(monster.Width / targetAspectRatio);
                }

                int cropX = (monster.Width - targetWidth) / 2;
                int cropY = (monster.Height - targetHeight) / 2;

                Raylib.ImageCrop(ref monster, new Rectangle(cropX, cropY, targetWidth, targetHeight));
                Raylib.ImageResize(ref monster, 745, 824);
                #endregion
            }
        }
    }

    public class RollOutput
    {
        public int Value { get; set; }
        public int Symbol { get; set; } // 0 = +(green), 1 = -(red)
        public string Outcome { get; set; }

        public RollOutput(int value, int symbol, string outcome)
        {
            Value = value;
            Symbol = symbol; //kotek
            Outcome = outcome;
        }
    }
}
