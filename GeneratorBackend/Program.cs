﻿using Raylib_cs;
using LanguageManager;
using System;
using System.IO;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using Color = Raylib_cs.Color;
using Image = Raylib_cs.Image;
using Rectangle = Raylib_cs.Rectangle;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Png;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace GeneratorBackend
{
    public partial class Backend // oh yeah this wasn't a thing but i added it so i could load languages only once rather than in every other class
    {
        private static List<LanguageManager.Manager.Language> tounges = LanguageManager.Manager.LoadJson(); // load languages

        public class ClassListObject
        {
            public string Name { get; set; } = "";  // this is actually not necessary, but who cares
            public Image Image { get; set; }
            public string ImagePath { get; set; } = "";
            public Color Color { get; set; }
        }

        public class AssetManager
        {
            private static AssetManager? instance;
            public string cardTarrot = "Assets/GeneratorAssets/card_tarrot.png";
            public string cardPoker = "Assets/GeneratorAssets/card_poker.png";
            public string cardBlank = "Assets/GeneratorAssets/card_blank.png";
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
            public const int BLANK_CARD_NAME_SIZE = 97;
            public const int MODIFIER_SIZE = 97;
            public const int TITLE_SIZE = 47; // 47
            public const int REQ_SIZE = 49; // 49
            public const int ADDITIONAL_REQ_SIZE = 36; // 37 (god knows what this commented values here are)
            public const int ROLL_SIZE = 43; // 43
            public const int DESC_SIZE = 36; // 36
            public const int HERO_SYMBOL = 75; //75.8823529411764705

            public Font nameFont { get; private set; }
            public Font titleFont { get; private set; }
            public Font descFont { get; private set; }
            public Font reqFont { get; private set; }
            public Font rollFont { get; private set; }

            public Color bottomColor = new(245, 241, 231, 255);
            public Color bottomColorDark = new(78, 78, 78, 255);
            public Color magicColor = new(127, 117, 116, 255);
            public Color modifierGoodColor = new(100, 171, 66, 255);
            public Color modifierBadColor = new(224, 33, 37, 255);

            public List<ClassListObject> ClassList { get; private set; }
            public Image HeroSample = Raylib.LoadImage("Classes/hero_sample.png"); // its just empty icon used for those two previous (without a letter)

            private AssetManager()
            {
                Raylib.InitWindow(1, 1, "Font Loader");
                Raylib.SetWindowPosition(-2000, -2000);

                // Get The Fonts
                nameFont = Raylib.LoadFontEx("Assets/Fonts/PatuaOne_Polish.ttf", NAME_SIZE, null, 382); // this font has limited language support (Mostly Western European Languages)
                titleFont = Raylib.LoadFontEx("Assets/Fonts/SourceSansPro.ttf", TITLE_SIZE, null, 1415);
                reqFont = Raylib.LoadFontEx("Assets/Fonts/SourceSansPro_Bold.ttf", REQ_SIZE, null, 1415);
                rollFont = Raylib.LoadFontEx("Assets/Fonts/PatuaOne_Polish.ttf", ROLL_SIZE, null, 1415);
                descFont = Raylib.LoadFontEx("Assets/Fonts/SourceSansPro.ttf", DESC_SIZE, null, 1415);

                // these are just hardcoded classes                     as said before, name is just to point which line is which class
                ClassList = new();
                ClassList.Add(new ClassListObject { Name = "no_class", Image = Raylib.LoadImage("Classes/none.png"), Color = new(91, 93, 92, 255) });
                ClassList.Add(new ClassListObject { Name = "ranger", Image = Raylib.LoadImage("Classes/ranger.png"), Color = new(35, 94, 57, 255) });
                ClassList.Add(new ClassListObject { Name = "wizard", Image = Raylib.LoadImage("Classes/wizard.png"), Color = new(116, 46, 137, 255) });
                ClassList.Add(new ClassListObject { Name = "bard", Image = Raylib.LoadImage("Classes/bard.png"), Color = new(194, 81, 47, 255) });
                ClassList.Add(new ClassListObject { Name = "guardian", Image = Raylib.LoadImage("Classes/guardian.png"), Color = new(235, 171, 33, 255) });
                ClassList.Add(new ClassListObject { Name = "fighter", Image = Raylib.LoadImage("Classes/fighter.png"), Color = new(151, 40, 44, 255) });
                ClassList.Add(new ClassListObject { Name = "thief", Image = Raylib.LoadImage("Classes/thief.png"), Color = new(0, 78, 125, 255) });
                ClassList.Add(new ClassListObject { Name = "druid", Image = Raylib.LoadImage("Classes/druid.png"), Color = new(0, 171, 143, 255) });
                ClassList.Add(new ClassListObject { Name = "warrior", Image = Raylib.LoadImage("Classes/warrior.png"), Color = new(94, 109, 180, 255) });
                ClassList.Add(new ClassListObject { Name = "berserker", Image = Raylib.LoadImage("Classes/berserker.png"), Color = new(225, 131, 51, 255) });
                ClassList.Add(new ClassListObject { Name = "necromancer", Image = Raylib.LoadImage("Classes/necromancer.png"), Color = new(213, 28, 106, 255) });
                ClassList.Add(new ClassListObject { Name = "sorcerer", Image = Raylib.LoadImage("Classes/sorcerer.png"), Color = new(29, 31, 29, 255) });

                // Load the Class List
                try
                {
                    foreach (string line in File.ReadLines("Classes/ClassList.txt"))
                    {
                        string[] prop = line.Split('\t');

                        Image image = new();
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Classes", prop[1]);
                        if (File.Exists(path))
                        {
                            SixLabors.ImageSharp.Image<Rgba32>? imageSharp;

                            using var file = File.OpenRead(path);
                            imageSharp = SixLabors.ImageSharp.Image.Load<Rgba32>(file);

                            using var memoryStream = new MemoryStream();
                            imageSharp.Save(memoryStream, new PngEncoder());
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            image = Raylib.LoadImageFromMemory(".png", memoryStream.ToArray());
                        }

                        if (image.Width == 0)
                        {
                            // TODO: It would be good to comunicate to the user that their image didn't load for example, but I tried and it just couldn't get it to work because of Raylib stuff.
                        }

                        int classRed = Convert.ToInt32(prop[2].Split(',')[0]);
                        int classGreen = Convert.ToInt32(prop[2].Split(',')[1]);
                        int classBlue = Convert.ToInt32(prop[2].Split(',')[2]);
                        Color colorCombined = new(classRed, classGreen, classBlue, 255);

                        // Add the class to the list
                        ClassList.Add(new ClassListObject { Name = prop[0], Image = image, ImagePath = path, Color = colorCombined});
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
            const int ADDITIONAL_REQ_FONT_SPACING = 2;

            const int DESC_FONT_SPACING = 1;
            const float DESC_LINE_SPACING = 4.5f; // the greater the value, the closer the lines are to each other, I know it's weird, but it's how it works.
            const int DESC_BIG_LINE_SPACING = 13; // this is used when a line break (ENTER) is typed.

            const int DESC_MARGIN_TARROT = 87;
            const int DESC_MARGIN_HERO = 200;
            const int DESC_MARGIN_ITEM = 225;
            const int DESC_MARGIN_MAGIC = 100;
            const int DESC_MARGIN_RIGHT = 90; // the margin on the right is the same for both card sizes

            // changing these, won't PROPERLY change the size of the card.
            // Tall cards
            const int CARD_WIDTH_TARROT = 827;
            const int CARD_HEIGHT_TARROT = 1417;
            // Normal cards
            const int CARD_WIDTH_POKER = 745;
            const int CARD_HEIGHT_POKER = 1040;

            const int CLASS_SYMBOL_HERO = 102;

            private static readonly AssetManager inst = AssetManager.Instance;

            #region Generation

            public static Image GenerateHeroSymbol(int language)
            {
                Image heroSymbol = Raylib.LoadImage("Classes/hero_sample.png");
                string letter;

                if (tounges[language].hero_symbol_letter.Length != 1)
                {
                    letter = tounges[language].card_hero_label.Substring(0, 1).ToUpper();
                }
                else
                {
                    letter = tounges[language].hero_symbol_letter;
                }

                Vector2 letterSize = Raylib.MeasureTextEx(inst.nameFont, letter, AssetManager.HERO_SYMBOL, 0);

                Raylib.ImageDrawTextEx(ref heroSymbol, inst.nameFont, letter, new Vector2((CLASS_SYMBOL_HERO - letterSize.X) / 2, (CLASS_SYMBOL_HERO - letterSize.Y) / 2), AssetManager.HERO_SYMBOL, 0, new Color(255, 255, 255, 255));

                return heroSymbol;
            }

            public static void GenerateLeader(string? renderLocation, int language, string name, int[] desiredClass, string leaderImg, string description, bool addGradient, bool nameWhite)
            {
                // This has to be loaded each time, to clear the image from the previous render
                Image card = Raylib.LoadImage(inst.cardTarrot);
                Rectangle imageRec = new(0, 0, CARD_WIDTH_TARROT, CARD_HEIGHT_TARROT);

                // Draw Leader Image
                ChangeLeaderImage(leaderImg);
                Raylib.ImageDraw(ref card, leader, imageRec, new Rectangle(41, 41, 745, 1176), Color.White);

                // Add Gradient
                if (addGradient) { Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Color.White); }

                #region Classes
                string leaderTitle;
                string className;

                if (desiredClass[0] < 12)
                {
                    className = tounges[language].class_name[desiredClass[0]];
                }
                else
                {
                    className = inst.ClassList[desiredClass[0]].Name;
                }

                leaderTitle = $"{tounges[language].card_leader_label}: {className}";

                // Primary Class
                Image classSymbol = inst.ClassList[desiredClass[0]].Image;
                Color desiredColor = inst.ClassList[desiredClass[0]].Color;

                // Draw Class Symbol
                Raylib.ImageDraw(ref card, classSymbol, imageRec, new Rectangle(363, 1167, 102, 102), Color.White);

                if (desiredClass[1] != -1) // check if there is a second class
                {
                    if (desiredClass[1] == -1) desiredClass[1] = 0;

                    Image secondClassSymbol = Raylib.ImageCopy(inst.ClassList[desiredClass[1]].Image); // It has to be copied, because otherwise it will modify the original image

                    if (desiredClass[1] < 12)
                    {
                        leaderTitle += $"/{tounges[language].class_name[desiredClass[1]]}";
                    }
                    else
                    {
                        leaderTitle += $"/{inst.ClassList[desiredClass[1]].Name}";
                    }
                    
                    Raylib.ImageCrop(ref secondClassSymbol, new Rectangle(0, 0, 51, 102));

                    // Draw the second class symbol
                    Raylib.ImageDraw(ref card, secondClassSymbol, imageRec, new Rectangle(363, 1167, 51, 102), Color.White);
                }
                #endregion

                // Draw Colored Frame(s)
                if (desiredClass[1] != -1) // check if there is a second class
                {
                    // Draw the first class frame
                    Image frameSecond = Raylib.ImageCopy(inst.frameLeader); // create a copy of the frame asset, so that the original is not modified

                    Raylib.ImageCrop(ref frameSecond, new Rectangle(0, 0, 414, 1417));
                    Raylib.ImageColorTint(ref frameSecond, desiredColor);
                    Raylib.ImageDraw(ref card, frameSecond, imageRec, new Rectangle(0, 0, 414, 1417), Color.White);

                    // Draw the second class frame
                    frameSecond = Raylib.ImageCopy(inst.frameLeader); // clear the tinted frame for the second class
                    Color desiredSecondColor = inst.ClassList[desiredClass[1]].Color;

                    Raylib.ImageCrop(ref frameSecond, new Rectangle(414, 0, 413, 1417)); // while the sizes might look irregular. It's all because the image is 827px wide, so I have to compensate the 0,5px offset. One side is wider by 1px
                    Raylib.ImageColorTint(ref frameSecond, desiredSecondColor);
                    Raylib.ImageDraw(ref card, frameSecond, imageRec, new Rectangle(414, 0, 413, 1417), Color.White);
                }
                else
                {
                    Raylib.ImageDraw(ref card, inst.frameLeader, imageRec, imageRec, desiredColor);
                }

                // Name and Title
                DrawNameAndTitleTarrot(name, leaderTitle, card, nameWhite);

                // Description
                DrawDescription(description, card, DESC_MARGIN_TARROT, DESC_MARGIN_RIGHT, 0, inst.bottomColorDark);

                // Save the image
                renderLocation ??= "preview.png";
                Raylib.ExportImage(card, renderLocation);
                Raylib.UnloadImage(card);
            }

            public static void GenerateMonster(string? renderLocation, int language, string name, int[] desiredRequirements, string monsterImg, RollOutput good, RollOutput bad, string description, string aditionalReq, string heroBonus, bool addGradient, bool nameWhite, bool alternativeColor)
            {
                // This has to be loaded each time, to clear the image from the previous render
                Image card = Raylib.LoadImage(inst.cardTarrot);
                Rectangle imageRec = new(0, 0, CARD_WIDTH_TARROT, CARD_HEIGHT_TARROT);

                // Draw Monster Image
                ChangeMonsterImage(monsterImg);
                Raylib.ImageDraw(ref card, monster, imageRec, new Rectangle(41, 41, 745, 824), Color.White);

                // Add Gradient
                if (addGradient) { Raylib.ImageDraw(ref card, inst.gradient, imageRec, imageRec, Color.White); }

                // Draw Colored Frame
                Color frameColor = alternativeColor switch
                {
                    true => new(0, 0, 0, 255),
                    false => new(23, 26, 30, 255)
                };

                Raylib.ImageDraw(ref card, inst.frameMonster, imageRec, imageRec, frameColor);

                // Requirements text
                string reqText = tounges[language].card_monster_requirements;
                Raylib.ImageDrawTextEx(ref card, inst.reqFont, reqText, new(88, 920), AssetManager.REQ_SIZE, REQ_FONT_SPACING, inst.bottomColor);
                float reqTextWidth = Raylib.MeasureTextEx(inst.reqFont, reqText, AssetManager.REQ_SIZE, REQ_FONT_SPACING).X; // get width of the "REQUIREMENT:" text to align the icons properly

                #region Requirements
                // put the classless hero requirements at the end
                int[] orderedRequirements = desiredRequirements.Where(x => x != -1).OrderBy(x => x == 0).ToArray(); // ignore -1, because it's the unassigned value

                // count how many class requirements there are
                int reqCount = orderedRequirements.Count();

                float iconsMargin = 83 + 13; // distance between icons (13), 83 is the width of the icon

                if (reqCount > 4) // if there are more than 4 icons, we need to reduce the margin between them
                {
                    iconsMargin -= tounges[language].card_monster_margin;
                }

                // Draw the class requirements
                foreach ((int req, int index) in orderedRequirements.Select((value, index) => (value, index)))
                {
                    Image classSymbol;
                    if (req == 0) 
                    {
                        classSymbol = GenerateHeroSymbol(language);
                    } 
                    
                    else classSymbol = inst.ClassList[req - 1].Image; // -1 because HERO is put in front, so the indexes are shifted

                    Raylib.ImageDraw(ref card, classSymbol, imageRec, new Rectangle(93 + reqTextWidth + 10 + index * iconsMargin, 902, 83, 83), Color.White);
                }

                // Additional Requirements
                if (aditionalReq != "")
                {
                    int fullXstart = 93 + (int)reqTextWidth + 10 + orderedRequirements.Length * (int)iconsMargin;
                    Raylib.ImageDrawTextEx(ref card, inst.reqFont, "+", new(fullXstart, 911), 63, REQ_FONT_SPACING, inst.bottomColor);
                    float plusWidth = Raylib.MeasureTextEx(inst.reqFont, "+", AssetManager.REQ_SIZE, REQ_FONT_SPACING).X;

                    int maxWidth = reqCount > 2 ? CARD_WIDTH_TARROT - fullXstart - (int)plusWidth - 40 : 207;
                    DrawAdditionalReq(aditionalReq, card, new(fullXstart + plusWidth + 16, 945), maxWidth, inst.bottomColor);
                }
                #endregion

                // Draw roll requirements and their outcomes
                Raylib.ImageDraw(ref card, inst.red, imageRec, new Rectangle(87, 1002, 78, 78), Color.White);
                Raylib.ImageDraw(ref card, inst.green, imageRec, new Rectangle(87, 1099, 78, 78), Color.White);

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

                int rollTextWidth = heroBonus == "" ? 600 : 300; // reduce the width of the roll text if there is a additional hero bonus
                DrawMonsterRollOutcome(red.Outcome, card, new(187, 1002 + 78 / 2), rollTextWidth, inst.bottomColor);
                DrawMonsterRollOutcome(green.Outcome, card, new(187, 1099 + 78 / 2), rollTextWidth, inst.bottomColor);

                // Additional Hero Bonus
                if (heroBonus != "")
                {
                    Raylib.ImageDrawRectangle(ref card, 490, 1000, 252, 175, new(59, 59, 59, 255));
                    DrawHeroBonus(heroBonus, card, new(490 + 252 / 2, 1000 + 175 / 2), 230, inst.bottomColor);
                }

                // Name and Title
                string titleText = tounges[language].card_monster_label;
                DrawNameAndTitleTarrot(name, titleText, card, nameWhite);

                // Description
                DrawDescription(description, card, DESC_MARGIN_TARROT, DESC_MARGIN_RIGHT, 1, inst.bottomColorDark);

                // Save the image
                renderLocation ??= "preview.png";
                Raylib.ExportImage(card, renderLocation);
                Raylib.UnloadImage(card);
            }

            public static void GenerateHero(string? renderLocation, int language, string name, int desiredClass, string heroImg, RollOutput description, int maxItems)
            {
                // This has to be loaded each time, to clear the image from the previous render
                Image card = Raylib.LoadImage(inst.cardPoker);
                Rectangle imageRec = new(0, 0, CARD_WIDTH_POKER, CARD_HEIGHT_POKER);

                // Draw Hero Image
                ChangeHeroItemMagicImage(heroImg);
                Raylib.ImageDraw(ref card, heroItemMagic, imageRec, new Rectangle(100, 232, 545, 545), Color.White);

                // Max Items
                if (maxItems == 0)
                {
                    Raylib.ImageDraw(ref card, inst.noItem, imageRec, new Rectangle(637, 935, 47, 47), Color.White);
                }
                else if (maxItems != 1)
                {
                    for (int i = 0; i < maxItems; i++)
                    {
                        Raylib.ImageDraw(ref card, inst.itemHero, imageRec, new Rectangle(637 - i * (50 + 10), 935, 47, 47), Color.White);
                    }
                }

                // Classes
                string heroTitle;
                if (desiredClass == -1) desiredClass = 0;

                Image classSymbol = inst.ClassList[desiredClass].Image;
                Color desiredColor = inst.ClassList[desiredClass].Color;

                if (desiredClass < 12)
                {
                    heroTitle = $"{tounges[language].card_hero_label}: {tounges[language].class_name[desiredClass]}";
                }
                else
                {
                    heroTitle = $"{tounges[language].card_hero_label}: {inst.ClassList[desiredClass].Name}";
                }

                // Draw Class Symbol
                Raylib.ImageDraw(ref card, classSymbol, imageRec, new Rectangle(322, 722, 102, 102), Color.White);

                // Draw Colored Frame
                Raylib.ImageDraw(ref card, inst.frameHero, imageRec, imageRec, desiredColor);

                // Name and Title
                DrawNameAndTitlePoker(name, heroTitle, card, desiredColor);

                // Roll Output Symbol and Value
                char descSymbol = ' ';

                switch (description.Symbol)
                {
                    case 0:
                        Raylib.ImageDraw(ref card, inst.green, imageRec, new Rectangle(94, 852, 78, 78), Color.White);
                        descSymbol = '+';
                        break;
                    case 1:
                        Raylib.ImageDraw(ref card, inst.red, imageRec, new Rectangle(94, 852, 78, 78), Color.White);
                        descSymbol = '-';
                        break;
                }

                Vector2 descNumSize = Raylib.MeasureTextEx(inst.rollFont, description.Value.ToString() + descSymbol, AssetManager.ROLL_SIZE, ROLL_FONT_SPACING);
                Raylib.ImageDrawTextEx(ref card, inst.rollFont, description.Value.ToString() + descSymbol, new(94 + 78 / 2 - descNumSize.X / 2, 852 + 78 / 2 - descNumSize.Y / 2), AssetManager.ROLL_SIZE, ROLL_FONT_SPACING, inst.bottomColor);

                // Description
                DrawDescription(description.Outcome, card, DESC_MARGIN_HERO, DESC_MARGIN_RIGHT, 2, inst.bottomColorDark);

                // Save the image
                renderLocation ??= "preview.png";
                Raylib.ExportImage(card, renderLocation);
                Raylib.UnloadImage(card);
            }

            public static void GenerateItem(string? renderLocation, int language, string name, int desiredClass, string itemImg, string description)
            {
                // This has to be loaded each time, to clear the image from the previous render
                Image card = Raylib.LoadImage(inst.cardPoker);
                Rectangle imageRec = new(0, 0, CARD_WIDTH_POKER, CARD_HEIGHT_POKER);

                // Draw Item Image
                ChangeHeroItemMagicImage(itemImg);
                Raylib.ImageDraw(ref card, heroItemMagic, imageRec, new Rectangle(100, 232, 545, 545), Color.White);

                // Classes
                string itemTitle;
                if (desiredClass == -1) desiredClass = 0;

                Image classSymbol = desiredClass switch
                {
                    0 => inst.itemItem,
                    1 => inst.cursed,
                    _ => inst.ClassList[desiredClass - 2].Image
                };
                Color frameColor = new(68, 64, 61, 255);
                Color titleColor;

                if (desiredClass == 1) // check if it's a cursed item
                {
                    titleColor = new(160, 59, 139, 255);
                    itemTitle = tounges[language].card_item_cursed;
                }
                else // if it's not a cursed item, then it's a normal item
                {
                    titleColor = new(0, 163, 172, 255);
                    itemTitle = tounges[language].card_item_label;
                }

                // Draw Colored Frame
                Raylib.ImageDraw(ref card, inst.frameItem, imageRec, imageRec, frameColor);

                // Draw Class Symbol
                Raylib.ImageDraw(ref card, classSymbol, imageRec, new Rectangle(99, 886, 102, 102), Color.White);

                // Name and Title
                DrawNameAndTitlePoker(name, itemTitle, card, titleColor);

                // Description
                DrawDescription(description, card, DESC_MARGIN_ITEM, DESC_MARGIN_RIGHT, 3, inst.bottomColor);

                // Save the image
                renderLocation ??= "preview.png";
                Raylib.ExportImage(card, renderLocation);
                Raylib.UnloadImage(card);
            }

            public static void GenerateMagic(string? renderLocation, int language, string name, string magicImg, string description)
            {
                // This has to be loaded each time, to clear the image from the previous render
                Image card = Raylib.LoadImage(inst.cardPoker);
                Rectangle imageRec = new(0, 0, CARD_WIDTH_POKER, CARD_HEIGHT_POKER);

                // Draw Magic Image
                ChangeHeroItemMagicImage(magicImg);
                Raylib.ImageDraw(ref card, heroItemMagic, imageRec, new Rectangle(100, 232, 545, 545), Color.White);

                // Localise the 'title'
                string magicTitle = tounges[language].card_magic_label;

                // Draw Colored Frame
                Raylib.ImageDraw(ref card, inst.frameHero, imageRec, imageRec, inst.magicColor);

                // Name and Title
                DrawNameAndTitlePoker(name, magicTitle, card, inst.magicColor);

                // Description
                DrawDescription(description, card, DESC_MARGIN_MAGIC, DESC_MARGIN_RIGHT, 4, inst.bottomColorDark);


                // Save the image
                renderLocation ??= "preview.png";
                Raylib.ExportImage(card, renderLocation);
                Raylib.UnloadImage(card);
            }

            public static void GenerateModifier(string? renderLocation, int language, string name, string modifierImg, RollOutput good, RollOutput bad, string description) {
                // This has to be loaded each time, to clear the image from the previous render
                Image card = Raylib.LoadImage(inst.cardBlank);
                Rectangle imageRec = new(0, 0, CARD_WIDTH_POKER, CARD_HEIGHT_POKER);

                // Draw Modifier Image
                ChangeHeroItemMagicImage(modifierImg);
                Raylib.ImageDraw(ref card, heroItemMagic, imageRec, new Rectangle(100, 182, 545, 545), Color.White);

                // Name
                DrawNameBlank(name, card);

                // Modifier Amounts
                RollOutput red = bad;
                RollOutput green = good;
                if (bad.Symbol == 0) // check if "bad" has a positive value instead
                {
                    red = good;
                    green = bad;
                }

                DrawModifierAmounts(green, red, card, new(187, 1002 + 78 / 2), 300, inst.magicColor);

                // Description
                DrawDescription(description, card, DESC_MARGIN_MAGIC, DESC_MARGIN_RIGHT, 5, inst.bottomColorDark);

                // Save the image
                renderLocation ??= "preview.png";
                Raylib.ExportImage(card, renderLocation);
                Raylib.UnloadImage(card);
            }

            public static void GenerateChallenge(string? renderLocation, int language, string name, string challengeImg, string description) {
                // This has to be loaded each time, to clear the image from the previous render
                Image card = Raylib.LoadImage(inst.cardBlank);
                Rectangle imageRec = new(0, 0, CARD_WIDTH_POKER, CARD_HEIGHT_POKER);

                // Draw Challenge Image
                ChangeChallenge(challengeImg);
                Raylib.ImageDraw(ref card, challenge, imageRec, new Rectangle(50, 215, 645, 550), Color.White);

                // Name
                DrawNameBlank(name, card);

                // Description
                DrawDescription(description, card, DESC_MARGIN_MAGIC, DESC_MARGIN_RIGHT, 5, inst.bottomColorDark);

                // Save the image
                renderLocation ??= "preview.png";
                Raylib.ExportImage(card, renderLocation);
                Raylib.UnloadImage(card);
            }
            #endregion

            #region Common Draw Text
            static void DrawNameAndTitleTarrot(string nameText, string titleText, Image card, bool nameWhite)
            {
                Color leaderColor = nameWhite switch
                {
                    true => Color.White,
                    false => Color.Black
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

            static void DrawNameAndTitlePoker(string nameText, string titleText, Image card, Color titleColor)
            {
                Vector2 nameSize = Raylib.MeasureTextEx(inst.nameFont, nameText, AssetManager.NAME_SIZE, NAME_FONT_SPACING);
                Vector2 titleSize = Raylib.MeasureTextEx(inst.titleFont, titleText, AssetManager.TITLE_SIZE, TITLE_FONT_SPACING);

                int nameY = 80;
                int titleY = 134;

                // Name
                Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH_POKER / 2) - (nameSize.X / 2), nameY), AssetManager.NAME_SIZE, NAME_FONT_SPACING, Color.Black);

                // Title
                Raylib.ImageDrawTextEx(ref card, inst.titleFont, titleText, new Vector2((CARD_WIDTH_POKER / 2) - (titleSize.X / 2), titleY), AssetManager.TITLE_SIZE, TITLE_FONT_SPACING, titleColor);
            }

            static void DrawNameBlank(string nameText, Image card) {
                Vector2 nameSize = Raylib.MeasureTextEx(inst.nameFont, nameText, AssetManager.BLANK_CARD_NAME_SIZE, NAME_FONT_SPACING);

                int nameY = 52;

                // Name
                Raylib.ImageDrawTextEx(ref card, inst.nameFont, nameText, new Vector2((CARD_WIDTH_POKER / 2) - (nameSize.X / 2), nameY), AssetManager.BLANK_CARD_NAME_SIZE, NAME_FONT_SPACING, Color.Black);
            }

            static (List<string>, int) SplitTextToLines(string text, int targetLen, bool greaterSpace)
            {
                List<string> lineList = new();
                StringBuilder outputLine = new();
                StringBuilder word = new();

                float wordLen = 0;
                float currentLen;

                int additionalLineSpace = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    currentLen = Raylib.MeasureTextEx(inst.descFont, outputLine.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING).X;

                    if (text[i] != ' ' && text[i] != '\r' && text[i] != '\n')
                    {
                        word.Append(text[i]);
                        wordLen = Raylib.MeasureTextEx(inst.descFont, word.ToString(), AssetManager.DESC_SIZE, DESC_FONT_SPACING).X;
                    }
                    else if (((text[i] == ' ' || text[i] == '\r')) && currentLen + wordLen < targetLen)
                    {
                        word.Append(text[i]);
                        outputLine.Append(word);
                        word.Clear();
                    }

                    if ((currentLen + wordLen >= targetLen) || text[i] == '\r')
                    {
                        if (text[i] == '\r')
                        {
                            if (greaterSpace) additionalLineSpace += DESC_BIG_LINE_SPACING;
                        }

                        // Handeling the case when the word spans the entire line
                        if (outputLine.Length == 0)
                        {
                            outputLine.Append(word);
                            word.Clear();

                            if (i + 1 < text.Length && text[i + 1] != ' ' && text[i + 1] != '\r')
                            {
                                word.Append(outputLine[outputLine.Length - 1]);

                                outputLine.Remove(outputLine.Length - 1, 1);
                                outputLine.Append('-');
                            }
                        }

                        lineList.Add(outputLine.ToString());
                        outputLine.Clear();
                    }
                }
                if (word.Length != 0 || outputLine.Length != 0) lineList.Add(outputLine.ToString() + word.ToString()); // Add the last line.
                if (text.Length > 0 && text[^1] == '\n') lineList.Add(""); // Add an empty line if the last line is a line break

                return (lineList, additionalLineSpace);
            }

            static void DrawDescription(string text, Image card, int padding_left, int padding_right, int card_type, Color descTextColor) // card_type - which set of card size to use; 0 - tarrot (leader); 1 - tarrot (monster); 2 - poker (hero);
            {
                Vector2 card_size;
                int desc_space; // how much Y space there is for description
                switch (card_type)
                {
                    case 0:
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
                    case 3:
                        card_size.X = CARD_WIDTH_POKER;
                        card_size.Y = CARD_HEIGHT_POKER;

                        desc_space = 205;
                        break;
                    case 4:
                        card_size.X = CARD_WIDTH_POKER;
                        card_size.Y = CARD_HEIGHT_POKER;

                        desc_space = 222; // this one is for some reason smaller than the actual desc space on the card on real cards
                        break;
                    case 5:
                        card_size.X = CARD_WIDTH_POKER;
                        card_size.Y = CARD_HEIGHT_POKER;
                        desc_space = 264; // this one is for some reason smaller than the actual desc space on the card on real cards
                        break;
                    default:
                        throw new Exception("Invalid size_set value");
                }

                int targetLen = (int)card_size.X - padding_left - padding_right;

                // Split the text into lines
                (List<string> lineList, int additionalLineSpace) = SplitTextToLines(text, targetLen, true);

                Vector2 textSize = Raylib.MeasureTextEx(inst.descFont, text.Replace("\n", ""), AssetManager.DESC_SIZE, DESC_FONT_SPACING);

                float lineSpacing = (lineList.Count - 1) * DESC_LINE_SPACING; // We subtract one because: for example between 3 lines there are 2 spaces.

                float textBlockCenter = (desc_space - lineList.Count * textSize.Y + lineSpacing - additionalLineSpace) / 2;

                if (lineList.Count >= 4 && card_type == 0) textBlockCenter += 16; // real cards have a set offset for >=4 lines of text so they don't colide with the Leader Icon
                if (lineList.Count == 3 && additionalLineSpace > 0 && card_type == 0) textBlockCenter += 11; // real cards have a set offset for >=4 lines of text so they don't colide with the Leader Icon
                if (card_type == 2 || card_type == 4) textBlockCenter -= 41; // these cards have a frame that takes up 41px of space, so we need to offset the text by that much
                if ((card_type == 2) && lineList.Count >= 5) textBlockCenter += 12;

                lineSpacing = 0; // We have to reset the lineSpacing and increase it as we are drawing the lines
                additionalLineSpace = 0;

                // Draw the lines
                for (int currentLine = 0; currentLine < lineList.Count; currentLine++)
                {
                    bool bigSpace = false;
                    if (lineList[currentLine].Contains('\r'))
                    {
                        lineList[currentLine] = lineList[currentLine].Replace("\r", "");
                        bigSpace = true;
                    }

                    Raylib.ImageDrawTextEx(ref card, inst.descFont, lineList[currentLine], new Vector2(padding_left, card_size.Y - desc_space + textBlockCenter + (textSize.Y * currentLine) - lineSpacing + additionalLineSpace), AssetManager.DESC_SIZE, DESC_FONT_SPACING, descTextColor);

                    lineSpacing += DESC_LINE_SPACING;
                    if (bigSpace) additionalLineSpace += DESC_BIG_LINE_SPACING;
                }
            }

            static void DrawMonsterRollOutcome(string text, Image card, Vector2 drawLocation, int maxWidth, Color TextColor)
            {
                (List<string> lineList, int additionalLineSpace) = SplitTextToLines(text, maxWidth, false);
                float textSize = Raylib.MeasureTextEx(inst.descFont, text.Replace("\n", ""), AssetManager.DESC_SIZE, DESC_FONT_SPACING).Y;

                float textBlockCenter = (lineList.Count * textSize) / 2;

                // Draw the lines
                for (int currentLine = 0; currentLine < lineList.Count; currentLine++)
                {
                    if (lineList[currentLine].Contains('\r'))
                    {
                        lineList[currentLine] = lineList[currentLine].Replace('\r', ' ');
                    }
                    Raylib.ImageDrawTextEx(ref card, inst.descFont, lineList[currentLine], new Vector2(drawLocation.X, drawLocation.Y - textBlockCenter + (textSize * currentLine)), AssetManager.DESC_SIZE, DESC_FONT_SPACING, TextColor);
                }
            }

            static void DrawHeroBonus(string text, Image card, Vector2 drawLocation, int maxWidth, Color TextColor)
            {
                (List<string> lineList, int additionalLineSpace) = SplitTextToLines(text, maxWidth, false);
                float textHeight = Raylib.MeasureTextEx(inst.descFont, text.Replace("\n", ""), AssetManager.DESC_SIZE, DESC_FONT_SPACING).Y;

                float lineSpacing = (lineList.Count - 1) * DESC_LINE_SPACING; // We subtract one because: for example between 3 lines there are 2 spaces
                float textBlockCenterY = (lineList.Count * textHeight - lineSpacing) / 2;

                lineSpacing = 0; // We have to reset the lineSpacing and increase it as we are drawing the lines

                // Draw the lines
                for (int currentLine = 0; currentLine < lineList.Count; currentLine++)
                {
                    if (lineList[currentLine].Contains('\r'))
                    {
                        lineList[currentLine] = lineList[currentLine].Replace('\r', ' ');
                    }
                    int textWidth = (int)Raylib.MeasureTextEx(inst.descFont, lineList[currentLine], AssetManager.DESC_SIZE, DESC_FONT_SPACING).X;
                    float textBlockCenterX = drawLocation.X - textWidth / 2;

                    Raylib.ImageDrawTextEx(ref card, inst.descFont, lineList[currentLine], new Vector2(textBlockCenterX, drawLocation.Y - textBlockCenterY + (textHeight * currentLine) - lineSpacing), AssetManager.DESC_SIZE, DESC_FONT_SPACING, TextColor);

                    lineSpacing += DESC_LINE_SPACING;
                }
            }

            static void DrawModifierAmounts(RollOutput goodText, RollOutput badText, Image card, Vector2 drawLocation, int maxWidth, Color TextColor) {
                Vector2 goodSize = Raylib.MeasureTextEx(inst.rollFont, "+" + goodText.Value.ToString(), AssetManager.MODIFIER_SIZE, NAME_FONT_SPACING);
                Vector2 badSize = Raylib.MeasureTextEx(inst.rollFont, "-" + badText.Value.ToString(), AssetManager.MODIFIER_SIZE, NAME_FONT_SPACING);

                int modifierY = 763;
                int spacing = 0;

                if (goodText.Value != 0 && badText.Value != 0) {
                    spacing = 94;

                    Vector2 dividerSize = Raylib.MeasureTextEx(inst.rollFont, "/", AssetManager.MODIFIER_SIZE, NAME_FONT_SPACING);
                    Raylib.ImageDrawTextEx(ref card, inst.rollFont, "/", new Vector2((CARD_WIDTH_POKER / 2) - (dividerSize.X / 2), modifierY), AssetManager.MODIFIER_SIZE, NAME_FONT_SPACING, Color.Black);
                }

                // Draw values
                if (goodText.Value != 0) {
                    Raylib.ImageDrawTextEx(ref card, inst.rollFont, "+" + goodText.Value.ToString(), new Vector2((CARD_WIDTH_POKER / 2) - (goodSize.X / 2) - spacing, modifierY), AssetManager.MODIFIER_SIZE, NAME_FONT_SPACING, inst.modifierGoodColor); 
                }
                if (badText.Value != 0) {
                    Raylib.ImageDrawTextEx(ref card, inst.rollFont, "-" + badText.Value.ToString(), new Vector2((CARD_WIDTH_POKER / 2) - (badSize.X / 2) + spacing, modifierY), AssetManager.MODIFIER_SIZE, NAME_FONT_SPACING, inst.modifierBadColor);
                }
            }

            static void DrawAdditionalReq(string text, Image card, Vector2 drawLocation, int maxWidth, Color TextColor)
            {
                (List<string> lineList, int additionalLineSpace) = SplitTextToLines(text, maxWidth, false);
                float textHeight = Raylib.MeasureTextEx(inst.descFont, text.Replace("\n", ""), AssetManager.DESC_SIZE, DESC_FONT_SPACING).Y;

                float lineSpacing = (lineList.Count - 1) * DESC_LINE_SPACING; // We subtract one because: for example between 3 lines there are 2 spaces
                float textBlockCenterY = (lineList.Count * textHeight - lineSpacing) / 2;

                lineSpacing = 0; // We have to reset the lineSpacing and increase it as we are drawing the lines

                // Draw the lines
                for (int currentLine = 0; currentLine < lineList.Count; currentLine++)
                {
                    if (lineList[currentLine].Contains('\r'))
                    {
                        lineList[currentLine] = lineList[currentLine].Replace('\r', ' ');
                    }

                    Raylib.ImageDrawTextEx(ref card, inst.reqFont, lineList[currentLine], new Vector2(drawLocation.X, drawLocation.Y - textBlockCenterY + (textHeight * currentLine) - lineSpacing), AssetManager.DESC_SIZE, ADDITIONAL_REQ_FONT_SPACING, TextColor);

                    lineSpacing += DESC_LINE_SPACING;
                }
            }

            #endregion

            #region Change Image
            static Image leader = new();
            static Image monster = new();
            static Image heroItemMagic = new();
            static Image challenge = new();

            static string lastPathLeader = "";
            static string lastPathMonster = "";
            static string lastPathHero = "";
            static string lastPathChallenge = "";

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

            static void ChangeHeroItemMagicImage(string path)
            {
                if (path == lastPathHero) { return; }
                lastPathHero = path;

                LoadImage(ref heroItemMagic, path);
                CropImage(ref heroItemMagic, 545, 545);
            }

            static void ChangeChallenge(string path) {
                if (path == lastPathChallenge) { return; }
                lastPathChallenge = path;

                LoadImage(ref challenge, path);
                CropImage(ref challenge, 645, 550);
            }

            static void LoadImage(ref Image image, string path)
            {
                if (File.Exists(path))
                {
                    SixLabors.ImageSharp.Image<Rgba32>? imageSharp;

                    Raylib.UnloadImage(image);
                    using var file = File.OpenRead(path);
                    imageSharp = SixLabors.ImageSharp.Image.Load<Rgba32>(file);

                    using var memoryStream = new MemoryStream();
                    imageSharp.Save(memoryStream, new PngEncoder());
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
}
