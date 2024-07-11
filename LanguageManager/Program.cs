using System.Text.Json;

var readedData = new List<Language>();

using (StreamReader r = new StreamReader("lang.json"))
{
    string json = r.ReadToEnd();
    readedData = JsonSerializer.Deserialize<List<Language>>(json);
}

public record struct Language(
        string lang_code,
        string lang_name,

        string classname_ranger,
        string classname_wizard,
        string classname_bard,
        string classname_guardian,
        string classname_fighter,
        string classname_thief,
        string classname_druid,
        string classname_warrior,
        string classname_berserker,
        string classname_necromancer,
        string classname_sorcerer,

        string card_leader_label,
        string card_monster_label,
        string card_hero_label,
        string card_item_label,
        string card_magic_label,

        string card_monster_requirements,
        string card_item_cursed
    );