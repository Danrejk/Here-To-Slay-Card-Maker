using System.Reflection;
using Newtonsoft.Json;

namespace LanguageManager
{
    public class Manager
    {
        public record struct Language(
            string lang_code,
            string lang_name,

            string class_name_no_class,
            string class_name_ranger,
            string class_name_wizard,
            string class_name_bard,
            string class_name_guardian,
            string class_name_fighter,
            string class_name_thief,
            string class_name_druid,
            string class_name_warrior,
            string class_name_berserker,
            string class_name_necromancer,
            string class_name_sorcerer,

            string card_leader_label,
            string card_monster_label,
            string card_hero_label,
            string card_item_label,
            string card_magic_label,

            string card_monster_requirements,
            string card_item_cursed
        );

        public static List<Language> LoadJson()
        {
            using (StreamReader r = new StreamReader("lang.json"))
            {
                string json = r.ReadToEnd();
                #pragma warning disable CS8600 //because yes
                List<Language> languages = JsonConvert.DeserializeObject<List<Language>>(json);
                #pragma warning disable CS8603
                return languages;

            }
        }
    }
}