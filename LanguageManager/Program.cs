using System.Reflection;
using Newtonsoft.Json;

namespace LanguageManager
{
    public class Manager
    {
        public record struct Language(
            string lang_code,
            string lang_name,

            string[] class_name,
                  
            string card_leader_label,
            string card_monster_label,
            string card_hero_label,
            string card_item_label,
            string card_magic_label,
            string card_modifier_label,

            string card_monster_requirements,
            string hero_symbol_letter,
            string card_item_cursed,

            int card_monster_margin
        );

        public static List<Language> LoadJson() // when using somewhere else it should be used somewhere on top of everything
        {
            using (StreamReader r = new("./Languages/lang.json"))
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