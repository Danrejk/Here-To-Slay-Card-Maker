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

        Color DESC = new Color(78, 78, 78, 255);

        const int CARD_WIDTH = 827;
        const int CARD_HEIGHT = 1417;

        const int NAME_SIZE = 69; // 69 test
        const int TITLE_SIZE = 41; // 41
        const int DESC_SIZE = 35; // 35

        Font nameFont = Raylib.LoadFontEx("name_font.ttf", 1000, null, 1382);
        Font descFont = Raylib.LoadFontEx("desc_font.ttf", 1000, null, 1382);

        Color desiredColor = WOJ;
        int desiredClass = 5;

        string leaderName = "Pięść Roztropności";
        string leaderTitle;
        string leaderDescription = "To jest test C#.";

        switch (desiredClass)
        {
            case 1:
                leaderTitle = "Przywódca drużyny: łowca";
                break;
            case 2:
                leaderTitle = "Przywódca drużyny: mag";
                break;
            case 3:
                leaderTitle = "Przywódca drużyny: bard";
                break;
            case 4:
                leaderTitle = "Przywódca drużyny: strażnik";
                break;
            case 5:
                leaderTitle = "Przywódca drużyny: wojownik";
                break;
            case 6:
                leaderTitle = "Przywódca drużyny: złodziej";
                break;
            default:
                leaderTitle = "";
                break;
        }

        Vector2 leaderNameSize = Raylib.MeasureTextEx(nameFont, leaderName, NAME_SIZE, 1);
        Vector2 leaderTitleSize = Raylib.MeasureTextEx(descFont, leaderTitle, TITLE_SIZE, 1);
        Vector2 leaderDescriptionSize = Raylib.MeasureTextEx(descFont, leaderDescription, DESC_SIZE, 1);

        Image frame = Raylib.LoadImage("template/frame.png");
        Image bottom = Raylib.LoadImage("template/bottom.png");
        Image gradient = Raylib.LoadImage("template/gradient.png");
        Image card = Raylib.LoadImage("template/background.png");
        Image leader = Raylib.LoadImage("leader_pic.png");

        Rectangle imageRec = new Rectangle(0, 0, 827, 1417);

        Image[] classesSymbol =
        {
            Raylib.LoadImage("classes/lowca.png"),
            Raylib.LoadImage("classes/mag.png"),
            Raylib.LoadImage("classes/najebus.png"),
            Raylib.LoadImage("classes/straznik.png"),
            Raylib.LoadImage("classes/wojownik.png"),
            Raylib.LoadImage("classes/zlodziej.png")
        };

        Raylib.ImageColorTint(ref frame, desiredColor);

        Raylib.ImageResize(ref leader, 827, 1417);

        Raylib.ImageDraw(ref card, leader, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, gradient, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, frame, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, bottom, imageRec, imageRec, Color.WHITE);
        Raylib.ImageDraw(ref card, classesSymbol[desiredClass - 1], imageRec, imageRec, Color.WHITE);

        Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - ((leaderNameSize.X * 0.96f) / 2) + 4, 84.0f), NAME_SIZE, 1, new Color(255, 255, 255, 127));
        Raylib.ImageDrawTextEx(ref card, nameFont, leaderName, new Vector2((CARD_WIDTH / 2) - ((leaderNameSize.X * 0.96f) / 2), 80.0f), NAME_SIZE, 1, Color.BLACK);

        Raylib.ImageDrawTextEx(ref card, descFont, leaderTitle, new Vector2((CARD_WIDTH / 2) - ((leaderTitleSize.X * 0.96f) / 2), 154.0f), TITLE_SIZE, 1, DESC);

        Raylib.ImageDrawTextEx(ref card, descFont, leaderDescription, new Vector2(94.0f, (CARD_HEIGHT - (199 / 2) - (leaderDescriptionSize.Y / 2))), DESC_SIZE, 1, DESC);

        Raylib.ExportImage(card, "test.png");

        Raylib.CloseWindow();
    }
}
