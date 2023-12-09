using Raylib_cs;
using System.IO;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using Color = Raylib_cs.Color;
using Image = Raylib_cs.Image;
using Rectangle = Raylib_cs.Rectangle;

namespace GeneratorBackend
{
    public class ClassListObject
    {
        public string NameEN { get; set; }
        public Image Image { get; set; }
        public Color Color { get; set; }
        public string NamePL { get; set; }
    }

    public class AssetManager
    {
        private static AssetManager? instance;
        public string cardTarrot = "Assets/GeneratorAssets/card_tarrot.png";
        public string cardPoker = "Assets/GeneratorAssets/card_poker.png";
        public Image frameLeader = Raylib.LoadImage("Assets/GeneratorAssets/frame_leader.png");
        public Image frameMonster = Raylib.LoadImage("Assets/GeneratorAssets/frame_monster.png");
        public Image frameHero = Raylib.LoadImage("Assets/GeneratorAssets/frame_hero.png");
        public Image frameItem = Raylib.LoadImage("Assets/GeneratorAssets/frame_item.png");
        public Image gradient = Raylib.LoadImage("Assets/GeneratorAssets/gradient.png");
        public Image red = Raylib.LoadImage("Assets/GeneratorAssets/red.png");
        public Image green = Raylib.LoadImage("Assets/GeneratorAssets/green.png");
        public Image noItem = Raylib.LoadImage("Assets/GeneratorAssets/no_item_hero.png");
        public Image itemHero = Raylib.LoadImage("Assets/GeneratorAssets/item_hero.png");
        public Image itemItem = Raylib.LoadImage("Assets/GeneratorAssets/item_item.png");
        public Image cursed = Raylib.LoadImage("Assets/GeneratorAssets/cursed_item.png");

        public const int NAME_SIZE = 60; // 60
        public const int TITLE_SIZE = 47; // 49
        public const int REQ_SIZE = 49; // 49
        public const int ROLL_SIZE = 43; // 49
        public const int DESC_SIZE = 36; // 38

        public Font nameFont { get; private set; }
        public Font titleFont { get; private set; }
        public Font descFont { get; private set; }
        public Font reqFont { get; private set; }
        public Font rollFont { get; private set; }

        public Color bottomColor = new(245, 241, 231, 255);

        public List<ClassListObject> ClassList { get; private set; }
        public Image Hero = Raylib.LoadImage("Classes/hero.png");
        public Image Bohater = Raylib.LoadImage("Classes/bohater.png");

        private AssetManager()
        {
            Raylib.InitWindow(1, 1, "Font Loader");
            Raylib.SetWindowPosition(-2000, -2000);

            // Get The Fonts
            nameFont = Raylib.LoadFontEx("Assets/Fonts/PatuaOne_Polish.ttf", NAME_SIZE, null, 382); // this font has limited language support (NOT only Polish and English btw)
            titleFont = Raylib.LoadFontEx("Assets/Fonts/SourceSansPro.ttf", TITLE_SIZE, null, 1415);
            reqFont = Raylib.LoadFontEx("Assets/Fonts/SourceSansPro_Bold.ttf", REQ_SIZE, null, 1415);
            rollFont = Raylib.LoadFontEx("Assets/Fonts/PatuaOne_Polish.ttf", ROLL_SIZE, null, 1415);
            descFont = Raylib.LoadFontEx("Assets/Fonts/SourceSansPro.ttf", DESC_SIZE, null, 1415);

            // Load the Class List
            try
            {
                ClassList = new();
                foreach (string line in File.ReadLines("Classes/ClassList.txt"))
                {
                    string[] prop = line.Split('\t');

                    string polishName = prop.Length > 3 ? prop[3] : prop[0]; // if there is no polish name, use the english one

                    Image image = new();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Classes", prop[1]);
                    if (File.Exists(path))
                    {
                        Image<Rgba32>? imageSharp;

                        using var file = File.OpenRead(path);
                        imageSharp = SixLabors.ImageSharp.Image.Load<Rgba32>(file);

                        using var memoryStream = new MemoryStream();
                        imageSharp.SaveAsPng(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        image = Raylib.LoadImageFromMemory(".png", memoryStream.ToArray());
                    }

                    if (image.Width == 0) { 
                        // TODO: It would be good to comunicate to the user that their image didn't load for example, but I tried and it just couldn't get it to work because of Raylib stuff.
                    }

                    int classRed = Convert.ToInt32(prop[2].Split(',')[0]);
                    int classGreen = Convert.ToInt32(prop[2].Split(',')[1]);
                    int classBlue = Convert.ToInt32(prop[2].Split(',')[2]);
                    Color colorCombined = new(classRed, classGreen, classBlue, 255);

                    // Add the class to the list
                    ClassList.Add(new ClassListObject { NameEN = prop[0], Image = image, Color = colorCombined, NamePL = polishName });
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error reading ClassList.txt: {e.Message}");
            }

            Console.WriteLine(Console.ReadLine());

            Raylib.CloseWindow();
        }

        public static AssetManager Instance
        {
            get
            {
                instance ??= new();
                return instance;
            }
        }
    }

    public class Program
    {
        // all of the font spacings work, but are simply not used as it turned out we don't need most of them, but YOU might. I dunno.

        const int NAME_FONT_SPACING = 0;
        const int TITLE_FONT_SPACING = 1;
        const int REQ_FONT_SPACING = 0;
        const int ROLL_FONT_SPACING = 0;

        const int DESC_FONT_SPACING = 1;
        const float DESC_LINE_SPACING = 4.5f; // the greater the value, the closer the lines are to each other, I know it's weird, but it's how it works.
        const int DESC_BIG_LINE_SPACING = 13; // this is used when a line break (ENTER) is typed.

        const int DESC_MARGIN_TARROT = 87;
        const int DESC_MARGIN_POKER = 200;
        const int DESC_MARGIN_RIGHT = 100; // the margin on the right is the same for both card sizes

        // changing these, won't PROPERLY change the size of the card.
        // Tall cards
        const int CARD_WIDTH_TARROT = 827;
        const int CARD_HEIGHT_TARROT = 1417;
        // Normal cards
        const int CARD_WIDTH_POKER = 745;
        const int CARD_HEIGHT_POKER = 1040;

        private static readonly AssetManager inst = AssetManager.Instance;

        #region Generation
        public static void GenerateLeader(string? renderLocation, int language, string name, int[] desiredClass, string leaderImg, string description, bool addGradient, bool nameWhite)
        {
            // This has to be loaded each time, to clear the image from the previous render
            Image card = Raylib.LoadImage(inst.cardTarrot);
            Rectangle imageRec = new(0, 0, CARD_WIDTH_TARROT, CARD_HEIGHT_TARROT);

            // Draw Leader Image
            ChangeLeaderImage(leaderImg);

            Raylib.ImageDraw(ref card, leader, imageRec, new(41, 41, 745, 1176), Color.WHITE);

            #region Classes
            string leaderTitle;

            // Primary Class
            if (desiredClass[0] == -1) desiredClass[0] = 0;

            Image classSymbol = inst.ClassList[desiredClass[0]].Image;
            Color desiredColor = inst.ClassList[desiredClass[0]].Color;

            leaderTitle = language switch
            {
                1 => $"Przywódca drużyny: {inst.ClassList[desiredClass[0]].NamePL}",
                _ => $"Party Leader: {inst.ClassList[desiredClass[0]].NameEN}"
            };
            if (inst.ClassList[desiredClass[0]].NameEN == "") leaderTitle = leaderTitle.Replace(": ", "");

            // Secondary Class
            Image secondClassSymbol = new();
            Color desiredSecondColor = new();

            if (desiredClass[1] != -1)
            {
                if (desiredClass[1] == -1) desiredClass[1] = 0;

                secondClassSymbol = Raylib.ImageCopy(inst.ClassList[desiredClass[1]].Image); // It has to be copied, because otherwise it will modify the original image
                desiredSecondColor = inst.ClassList[desiredClass[1]].Color;

                leaderTitle += language switch
                {
                    1 => $"/{inst.ClassList[desiredClass[1]].NamePL}",
                    _ => $"/{inst.ClassList[desiredClass[1]].NameEN}"
                };
                if (inst.ClassList[desiredClass[1]].NameEN == "") leaderTitle += language switch
                {
                    1 => "przywódca",
                    _ => "Leader"
                };
                Raylib.ImageCrop(ref secondClassSymbol, new Rectangle(0, 0, 51, 102));
            }
            #endregion
           
            if (addGradient) { Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Color.WHITE); }

            // Draw Class Symbol(s)
            Raylib.ImageDraw(ref card, classSymbol, imageRec, new(363, 1167, 102, 102), Color.WHITE);

            // Draw Colored Frame(s)
            Image frameTinted = Raylib.ImageCopy(inst.frameLeader); // create a copy of the frame asset, so that the original is not modified
            if (desiredClass[1] != -1) // check if there is a second class
            {
                Raylib.ImageDraw(ref card, secondClassSymbol, imageRec, new(363, 1167, 51, 102), Color.WHITE);

                Raylib.ImageCrop(ref frameTinted, new Rectangle(0, 0, 414, 1417));
                Raylib.ImageColorTint(ref frameTinted, desiredColor);
                Raylib.ImageDraw(ref card, frameTinted, imageRec, new(0, 0, 414, 1417), Color.WHITE);

                frameTinted = Raylib.ImageCopy(inst.frameLeader); // clear the tinted frame for the second class

                Raylib.ImageCrop(ref frameTinted, new Rectangle(414, 0, 413, 1417)); // while the sizes might look irregular. It's all because the image is 827px wide, so I have to compensate the 0,5px offset. One side is wider by 1px
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
            DrawDescription(description, card, DESC_MARGIN_TARROT, DESC_MARGIN_RIGHT, 0);

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

        public static void GenerateMonster(string? renderLocation, int language, string name, int[] desiredRequirements, RollOutput good, RollOutput bad, string monsterImg, string description, bool addGradient, bool nameWhite, bool alternativeColor)
        {
            // This has to be loaded each time, to clear the image from the previous render
            Image card = Raylib.LoadImage(inst.cardTarrot);
            Rectangle imageRec = new(0, 0, CARD_WIDTH_TARROT, CARD_HEIGHT_TARROT);

            // Draw Monster Image
            ChangeMonsterImage(monsterImg);
            
            Raylib.ImageDraw(ref card, monster, imageRec, new(41, 41, 745, 824), Color.WHITE);
            
            // Draw Colored Frame
            if (addGradient) { Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Color.WHITE); }
            Color frameColor = alternativeColor switch
            {
                true => new(0, 0, 0, 255),
                false => new(23, 26, 30, 255)
            };

            Raylib.ImageDraw(ref card, inst.frameMonster, imageRec, imageRec, frameColor);

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

                Image classSymbol;
                if (req == 0)
                {
                    classSymbol = language switch
                    {
                        1 => inst.Bohater,
                        _ => inst.Hero
                    };
                }
                else
                {
                    classSymbol = inst.ClassList[req - 1].Image;
                }

                // change the distance between icons, if there are 5, so that it better fits onto the card
                float iconsMargin = 83 + 13;
                if (reqCount > 4)
                {
                    iconsMargin -= language switch
                    {
                        1 => 0, // polish doesn't need margin reduction, because the "REQUIREMENT" text is shorter
                        _ => 8 // YOU CAN MODIFY THIS. It might look better for your preferences, but for me I think this is the best option.
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
            DrawDescription(description, card, DESC_MARGIN_TARROT, DESC_MARGIN_RIGHT, 1);

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

        public static void GenerateHero(string? renderLocation, int language, string name, int desiredClass, string heroImg, RollOutput description, int maxItems)
        {
            // This has to be loaded each time, to clear the image from the previous render
            Image card = Raylib.LoadImage(inst.cardPoker);
            Rectangle imageRec = new(0, 0, CARD_WIDTH_POKER, CARD_HEIGHT_POKER);

            // Draw Hero Image
            ChangeHeroImage(heroImg);
            Raylib.ImageDraw(ref card, hero, imageRec, new(100, 232, 545, 545), Color.WHITE);
            
            // Max Items
            if (maxItems == 0)
            {
                Raylib.ImageDraw(ref card, inst.noItem, imageRec, new(637, 935, 47, 47), Color.WHITE);
            }
            else if (maxItems != 1)
            {
                for (int i = 0; i < maxItems; i++)
                {
                    Raylib.ImageDraw(ref card, inst.itemHero, imageRec, new(637 - i * (50 + 10), 935, 47, 47), Color.WHITE);
                }
            }

            // Classes
            string heroTitle;
            if (desiredClass == -1) desiredClass = 0; 

            Image classSymbol = inst.ClassList[desiredClass].Image;
            Color desiredColor = inst.ClassList[desiredClass].Color;
         
            heroTitle = language switch
            {
                1 => $"Bohater: {inst.ClassList[desiredClass].NamePL}",
                _ => $"Hero: {inst.ClassList[desiredClass].NameEN}"
            };
            if (inst.ClassList[desiredClass].NameEN == "") heroTitle = heroTitle.Replace(": ", "");

            // Draw Class Symbol
            Raylib.ImageDraw(ref card, classSymbol, imageRec, new(322, 722, 102, 102), Color.WHITE);

            // Draw Colored Frame
            Image frameTinted = Raylib.ImageCopy(inst.frameHero); // create a copy of the frame asset, so that the original is not 
            Raylib.ImageColorTint(ref frameTinted, desiredColor);
            Raylib.ImageDraw(ref card, frameTinted, imageRec, imageRec, Color.WHITE);

            Raylib.UnloadImage(frameTinted);


            // Name and Title
            DrawNameAndTitleHero(name, heroTitle, card, desiredColor);

            // Roll Output Symbol and Value
            char descSymbol = ' ';

            switch (description.Symbol)
            {
                case 0:
                    Raylib.ImageDraw(ref card, inst.green, imageRec, new(94, 852, 78, 78), Color.WHITE);
                    descSymbol = '+';
                    break;
                case 1:
                    Raylib.ImageDraw(ref card, inst.red, imageRec, new(94, 852, 78, 78), Color.WHITE);
                    descSymbol = '-';
                    break;
            }

            Vector2 descNumSize = Raylib.MeasureTextEx(inst.rollFont, description.Value.ToString() + descSymbol, AssetManager.ROLL_SIZE, ROLL_FONT_SPACING);
            Raylib.ImageDrawTextEx(ref card, inst.rollFont, description.Value.ToString() + descSymbol, new(94 + 78 / 2 - descNumSize.X / 2, 852 + 78 / 2 - descNumSize.Y / 2), AssetManager.ROLL_SIZE, ROLL_FONT_SPACING, inst.bottomColor);

            // Description
            DrawDescription(description.Outcome, card, DESC_MARGIN_POKER, DESC_MARGIN_RIGHT, 2);

            // Final Render
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
        
        public static void GenerateItem(string? renderLocation, int language, string name, int desiredClass, string heroImg, string description)
        {
            // This has to be loaded each time, to clear the image from the previous render
            Image card = Raylib.LoadImage(inst.cardPoker);
            Rectangle imageRec = new(0, 0, CARD_WIDTH_POKER, CARD_HEIGHT_POKER);

            // Draw Hero Image
            ChangeHeroImage(heroImg);
            Raylib.ImageDraw(ref card, hero, imageRec, new(100, 232, 545, 545), Color.WHITE);

            // Classes
            string itemTitle;
            if (desiredClass == -1) desiredClass = 0;

            Image classSymbol = desiredClass switch
            {
                0 => inst.itemItem,
                1 => inst.cursed,
                _ => inst.ClassList[desiredClass-2].Image
            };
            Color frameColor = new(68, 64, 61, 255);
            Color titleColor;
            if (desiredClass == 1)
            {
                titleColor = new(160, 59, 139, 255);
                itemTitle = language switch
                {
                    1 => "Przeklęty przedmiot",
                    _ => "Cursed Item"
                };
            }
            else
            {
                titleColor = new(0, 163, 172, 255);
                itemTitle = language switch
                {
                    1 => "Przedmiot",
                    _ => "Item"
                };
            }
            
            // Draw Colored Frame
            Image frameTinted = Raylib.ImageCopy(inst.frameItem); // create a copy of the frame asset, so that the original is not 
            Raylib.ImageColorTint(ref frameTinted, frameColor);
            Raylib.ImageDraw(ref card, frameTinted, imageRec, imageRec, Color.WHITE);

            Raylib.UnloadImage(frameTinted);

            // Draw Class Symbol
            Raylib.ImageDraw(ref card, classSymbol, imageRec, new(94, 887, 102, 102), Color.WHITE);

            // Name and Title
            DrawNameAndTitleHero(name, itemTitle, card, titleColor);

            // Description
            DrawDescription(description, card, DESC_MARGIN_POKER, DESC_MARGIN_RIGHT, 2);

            // Final Render
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
        #endregion

        #region Common Draw Text
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
                false => new(255, 255, 255, 100)
            };

            Vector2 nameSize = Raylib.MeasureTextEx(inst.nameFont, nameText, AssetManager.NAME_SIZE, NAME_FONT_SPACING);
            Vector2 titleSize = Raylib.MeasureTextEx(inst.titleFont, titleText, AssetManager.TITLE_SIZE, TITLE_FONT_SPACING);

            int nameY = 67;
            int titleY = 118;

            // Name
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH_TARROT / 2) - (nameSize.X / 2) + 3, nameY + 3), AssetManager.NAME_SIZE, NAME_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH_TARROT / 2) - (nameSize.X / 2), nameY), AssetManager.NAME_SIZE, NAME_FONT_SPACING, leaderColor);

            // Title
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH_TARROT / 2) - (titleSize.X / 2) + 2, titleY + 2), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, leaderShadowColor);
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH_TARROT / 2) - (titleSize.X / 2), titleY), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, leaderColor);
        }

        static void DrawNameAndTitleHero(string nameText, string titleText, Image card, Color titleColor)
        {
            Vector2 nameSize = Raylib.MeasureTextEx(inst.nameFont, nameText, AssetManager.NAME_SIZE, NAME_FONT_SPACING);
            Vector2 titleSize = Raylib.MeasureTextEx(inst.titleFont, titleText, AssetManager.TITLE_SIZE, TITLE_FONT_SPACING);

            int nameY = 80;
            int titleY = 134;

            // Name
            Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH_POKER / 2) - (nameSize.X / 2), nameY), AssetManager.NAME_SIZE, NAME_FONT_SPACING, Color.BLACK);

            // Title
            Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH_POKER / 2) - (titleSize.X / 2), titleY), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, titleColor);
        }

        static void DrawDescription(string text, Image card, int padding_left, int padding_right, int card_type) // card_type - which set of card size to use; 0 - tarrot (leader); 1 - tarrot (monster); 2 - poker (hero);
        {
            Vector2 card_size;
            int desc_space; // how much Y space there is for description

            switch(card_type)
            {
                case 0:
                    card_size.X = CARD_WIDTH_TARROT;
                    card_size.Y = CARD_HEIGHT_TARROT;

                    desc_space = 200;
                    break;
                case 1:
                    card_size.X = CARD_WIDTH_TARROT;
                    card_size.Y = CARD_HEIGHT_TARROT;

                    desc_space = 200;
                    break;
                case 2:
                    card_size.X = CARD_WIDTH_POKER;
                    card_size.Y = CARD_HEIGHT_POKER;

                    desc_space = 215; // this one is for some reason smaller than the actual desc space on the card on real cards
                    break;
                default:
                    throw new Exception("Invalid size_set value");
            }

            int targetLen = (int)card_size.X - padding_left - padding_right;

            List<string> lineList = new();
            StringBuilder outputLine = new();
            StringBuilder word = new();

            float wordLen = 0;
            float currentLen;

            int additionalLineSpace = 0;

            // Divide the text into lines
            for (int i = 0; i < text.Length; i++)
            {
                currentLen = Raylib.MeasureTextEx(inst.descFont, outputLine.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING).X;

                if (text[i] != ' ' && text[i] != '\r' && text[i] != '\n')
                {
                    word.Append(text[i]);
                    wordLen = Raylib.MeasureTextEx(inst.descFont, word.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING).X;
                }
                else if (((text[i] == ' ' || text[i] == '\r') && text[i] != '\n') && currentLen + wordLen < targetLen)
                {
                    outputLine.Append(word);
                    word.Clear();
                    if (text[i] == ' ') outputLine.Append(' ');
                }

                if ((currentLen + wordLen >= targetLen) || text[i] == '\r')
                {
                    if (text[i] == '\r')
                    {
                        additionalLineSpace += DESC_BIG_LINE_SPACING;
                        outputLine.Append('\r');
                    }

                    lineList.Add(outputLine.ToString());
                    outputLine.Clear();
                }
            }
            lineList.Add(outputLine.ToString() + word.ToString()); // Add the last line.

            outputLine.Clear();
            word.Clear();

            Vector2 textSize = Raylib.MeasureTextEx(inst.descFont, text.Replace("\n", ""), AssetManager.DESC_SIZE, DESC_FONT_SPACING);
          
            int targetLines = lineList.Count;
            float lineSpacing = (targetLines-1)*DESC_LINE_SPACING; // We subtract one because for example between 3 lines there are 2 spaces.

            float textBlockCenter = (desc_space - targetLines * (textSize.Y) - additionalLineSpace + lineSpacing) / 2;

            if (targetLines >= 4 && card_type != 2) textBlockCenter += 16; // real cards have a set offset for >=4 lines of text so they don't colide with the Leader Icon
            if (targetLines == 3 && additionalLineSpace > 0 && card_type != 2) textBlockCenter += 12; // real cards have this offset for 3 lines WITH a big line spacing. All other cases seem to be without changes so it's kinda weird.
            if (card_type == 2) textBlockCenter -= 41; // hero cards have a frame that takes up 41px of space, so we need to offset the text by that much
            if (card_type == 2 && targetLines >= 5) textBlockCenter += 12;

            lineSpacing = 0; // We have to reset the lineSpacing and increase it as we are drawing the lines

            Color descTextColor = new(78, 78, 78, 255);

            // Draw the lines
            for (int currentLine = 0; currentLine < lineList.Count; currentLine++)
            {
                bool bigSpace = false;
                if (lineList[currentLine].Contains('\r'))
                {
                    lineList[currentLine] = lineList[currentLine].Replace('\r', ' ');
                    bigSpace = true;
                }

                Raylib.ImageDrawTextEx(ref card, inst.descFont, lineList[currentLine], new Vector2(padding_left, card_size.Y - desc_space + textBlockCenter + (textSize.Y * currentLine) - lineSpacing + additionalLineSpace), AssetManager.DESC_SIZE, DESC_FONT_SPACING, descTextColor);
                
                lineSpacing += DESC_LINE_SPACING;
                if (bigSpace) additionalLineSpace += DESC_BIG_LINE_SPACING;
            }
        }
        #endregion

        #region Change Image
        static Image leader = new();
        static Image monster = new();
        static Image hero = new();

        static string lastPathLeader = "";
        static string lastPathMonster = "";
        static string lastPathHero = "";

        static void ChangeLeaderImage(string path)
        {
            if (path == lastPathLeader) { return; }
            lastPathLeader = path;

            LoadImage(ref leader, path);
            CropImage(ref leader, 745, 1176);
        }

        static void ChangeMonsterImage(string path)
        {
            if (path == lastPathMonster) { return; }
            lastPathMonster = path;

            LoadImage(ref monster, path);
            CropImage(ref monster, 745, 824);
        }

        static void ChangeHeroImage(string path)
        {
            if (path == lastPathHero) { return; }
            lastPathHero = path;

            LoadImage(ref hero, path);
            CropImage(ref hero, 545, 545);
        }

        static void LoadImage(ref Image image, string path)
        {
            if (File.Exists(path))
            {
                Image<Rgba32>? imageSharp;

                Raylib.UnloadImage(image);
                using var file = File.OpenRead(path);
                imageSharp = SixLabors.ImageSharp.Image.Load<Rgba32>(file);

                using var memoryStream = new MemoryStream();
                imageSharp.SaveAsPng(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                image = Raylib.LoadImageFromMemory(".png", memoryStream.ToArray());
            }
        }

        static void CropImage(ref Image image, int width, int height)
        {
            float targetAspectRatio = (float)width / (float)height;
            int targetWidth, targetHeight;
            if (image.Width / (float)image.Height > targetAspectRatio)
            {
                targetWidth = (int)(image.Height * targetAspectRatio);
                targetHeight = image.Height;
            }
            else
            {
                targetWidth = image.Width;
                targetHeight = (int)(image.Width / targetAspectRatio);
            }

            int cropX = (image.Width - targetWidth) / 2;
            int cropY = (image.Height - targetHeight) / 2;

            Raylib.ImageCrop(ref image, new Rectangle(cropX, cropY, targetWidth, targetHeight));
            Raylib.ImageResize(ref image, width, height);
        }
        #endregion
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
