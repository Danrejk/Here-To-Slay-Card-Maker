using System;
using System.Numerics;
using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(400, 400, "generator");

        Color LOW = new Color(35, 94, 57, 255);
        Color MAG = new Color(116, 46, 137, 255);
        Color NAJ = new Color(194, 81, 47, 255);
        Color STR = new Color(235, 171, 33, 255);
        Color WOJ = new Color(151, 40, 44, 255);
        Color ZLO = new Color(0, 78, 125, 255);

        const int NAME_FONT_SPACING = 1;
        const int TITLE_FONT_SPACING = 1;
        const int DESC_FONT_SPACING = 1;

        Color DESC = new Color(78, 78, 78, 255);

        const int CARD_WIDTH = 827;
        const int CARD_HEIGHT = 1417;

        const int NAME_SIZE = 64; // 69
        const int TITLE_SIZE = 38; // 41
        const int DESC_SIZE = 35; // 35

        Font nameFont = Raylib.LoadFontEx("name_font.ttf", NAME_SIZE, null, 1415);
        Font titleFont = Raylib.LoadFontEx("desc_font.ttf", TITLE_SIZE, null, 1415);
        Font descFont = Raylib.LoadFontEx("desc_font.ttf", DESC_SIZE, null, 1415);

        Image frame = Raylib.LoadImage("template/frame.png");
        Image bottom = Raylib.LoadImage("template/bottom.png");
        Image gradient = Raylib.LoadImage("template/gradient.png");
        Image card = Raylib.LoadImage("template/background.png");
        Image leader = Raylib.LoadImage("leader_pic.png");
        Image classSymbol;

        Color desiredColor;
        int desiredClass = 5;
        string leaderTitle;

        string leaderName = "Pięść Roztropności";
        string leaderDescription = "To jest test C#.";

        switch (desiredClass)
        {
            case 1:
                leaderTitle = "Przywódca drużyny: łowca";
                desiredColor = LOW;
                classSymbol = Raylib.LoadImage("classes/lowca.png");
                break;
            case 2:
                leaderTitle = "Przywódca drużyny: mag";
                desiredColor = MAG;
                classSymbol = Raylib.LoadImage("classes/mag.png");
                break;
            case 3:
                leaderTitle = "Przywódca drużyny: bard";
                classSymbol = Raylib.LoadImage("classes/najebus.png");
                desiredColor = NAJ;
                break;
            case 4:
                leaderTitle = "Przywódca drużyny: strażnik";
                classSymbol = Raylib.LoadImage("classes/straznik.png");
                desiredColor = STR;
                break;
            case 5:
                leaderTitle = "Przywódca drużyny: wojownik";
                classSymbol = Raylib.LoadImage("classes/wojownik.png");
                desiredColor = WOJ;
                break;
            case 6:
                leaderTitle = "Przywódca drużyny: złodziej";
                classSymbol = Raylib.LoadImage("classes/zlodziej.png");
                desiredColor = ZLO;
                break;
            default: // when no desired class is given it deafults to thief
                leaderTitle = "Przywódca drużyny: złodziej";
                classSymbol = Raylib.LoadImage("classes/zlodziej.png");
                desiredColor = ZLO;
                break;
        }


        Vector2 leaderNameSize = Raylib.MeasureTextEx(nameFont, leaderName, NAME_SIZE, NAME_FONT_SPACING);
        Vector2 leaderTitleSize = Raylib.MeasureTextEx(titleFont, leaderTitle, TITLE_SIZE, TITLE_FONT_SPACING);
        Vector2 leaderDescriptionSize = Raylib.MeasureTextEx(descFont, leaderDescription, DESC_SIZE, DESC_FONT_SPACING);

        Rectangle imageRec = new(0, 0, 827, 1417);

        Raylib.ImageColorTint(ref frame, desiredColor);

        Raylib.ImageResize(ref leader, 827, 1417);

        Raylib.ImageDraw(ref card, leader, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, gradient, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, frame, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, bottom, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, classSymbol, imageRec, imageRec, Color.WHITE);

        Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - ((leaderNameSize.X * 0.96f) / 2) + 4, 84.0f), NAME_SIZE, NAME_FONT_SPACING, new Color(255, 255, 255, 127));
        Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - ((leaderNameSize.X * 0.96f) / 2), 80.0f), NAME_SIZE, NAME_FONT_SPACING, Color.BLACK);

        Raylib.ImageDrawTextEx(ref card, titleFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - (leaderTitleSize.X / 2), 154.0f), TITLE_SIZE, TITLE_FONT_SPACING, DESC);

        Raylib.ImageDrawTextEx(ref card, descFont, leaderDescription, new Vector2(94.0f, (CARD_HEIGHT - (199 / 2) - (leaderDescriptionSize.Y / 2))), DESC_SIZE, DESC_FONT_SPACING, DESC);

        Raylib.ExportImage(card, "test.png");

        Raylib.CloseWindow();
    }
}
