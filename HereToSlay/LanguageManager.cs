//using System;
//using System.Collections.Generic;
//using System.Xml;

//namespace HereToSlay
//{
//    public class LanguageManager
//    {
//        private Dictionary<string, Dictionary<string, string>> languageStrings;

//        public LanguageManager(string languageFilePath)
//        {
//            languageStrings = new();
//            LoadLanguageFile(languageFilePath);
//        }

//        private void LoadLanguageFile(string languageFilePath)
//        {
//            try
//            {
//                XmlDocument doc = new();
//                doc.Load(languageFilePath);

//                XmlNodeList? implementedLanguages = doc.SelectNodes("/languages/language") ?? throw new Exception("No languages found in language file");

//                foreach (XmlNode language in implementedLanguages)
//                {
//                    if (language.Attributes == null) throw new Exception("Language node has no attributes");

//                    string languageId = language.Attributes?["id"]?.Value ?? throw new Exception("Language has no set id");

//                    var strings = new Dictionary<string, string>();
//                    foreach (XmlNode stringNode in language.ChildNodes)
//                    {
//                        string key = stringNode.Attributes?["key"]?.Value ?? throw new Exception("A Node has no set key");
//                        string value = stringNode.InnerText;

//                        strings[key] = value;
//                    }
                    
//                    languageStrings[languageId] = strings;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading language file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        public string GetLocalizedString(string languageId, string key)
//        {
//            if (languageStrings.ContainsKey(languageId) && languageStrings[languageId].ContainsKey(key))
//            {
//                return languageStrings[languageId][key];
//            }
//            return "String not found";
//        }
//    }

//}
