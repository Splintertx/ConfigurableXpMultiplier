using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModLib;
using ModLib.Attributes;
using System.Xml.Serialization;

namespace ConfigurableXpMultiplier
{
    public class Settings : SettingsBase
    {
        public override string ModName => "Configurable XP Multiplier";
        public override string ModuleFolderName => SubModule.ModuleFolderName;
        public const string SettingsInstanceID = "ConfigurableXpMultiplier";
        static Settings _instance = null;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FileDatabase.Get<Settings>(SettingsInstanceID);
                    if (_instance == null)
                    {
                        _instance = new Settings();
                        SettingsDatabase.SaveSettings(_instance);
                    }
                }

                return _instance;
            }
        }

        [XmlElement]
        public override string ID { get; set; } = SettingsInstanceID;

        [XmlElement]
        [SettingProperty("Smithing XP Enabled", "(Default false) Enable smithing XP multiplier")]
        [SettingPropertyGroup("Smithing", true)]
        public bool SmithingXPEnabled { get; set; } = false;

        [XmlElement]
        [SettingProperty("Refining XP Multiplier", 1, 100000, "(Default 1x) Multiply refining XP by this value in percent (e.g. 133 = 133%)")]
        [SettingPropertyGroup("Smithing")]
        public int RefiningXPMultiplier { get; set; } = 100;

        [XmlElement]
        [SettingProperty("Smelting XP Multiplier", 1, 100000, "(Default 1x) Multiply smelting XP by this value in percent (e.g. 133 = 133%)")]
        [SettingPropertyGroup("Smithing")]
        public int SmeltingXPMultiplier { get; set; } = 100;

        [XmlElement]
        [SettingProperty("Smithing XP Multiplier", 1, 100000, "(Default 1x) Multiply smithing XP by this value in percent (e.g. 133 = 133%)")]
        [SettingPropertyGroup("Smithing")]
        public int SmithingXPMultiplier { get; set; } = 100;

        [XmlElement]
        [SettingProperty("Battle XP Enabled", "(Default false) Enable combat XP multiplier")]
        [SettingPropertyGroup("Combat", true)]
        public bool CombatXPEnabled { get; set; } = false;

        [XmlElement]
        [SettingProperty("Troop Battle XP Multiplier", 1, 100000, "(Default 1x) Multiply troop battle XP by this value in percent (e.g. 133 = 133%)")]
        [SettingPropertyGroup("Combat")]
        public int CombatXPTroopMultiplier { get; set; } = 100;

        [XmlElement]
        [SettingProperty("Player Battle XP Multiplier", 1, 100000, "(Default 1x) Multiply player battle XP by this value in percent (e.g. 133 = 133%)")]
        [SettingPropertyGroup("Combat")]
        public int CombatXPPlayerMultiplier { get; set; } = 100;

        [XmlElement]
        [SettingProperty("AI Hero Battle XP Multiplier", 1, 100000, "(Default 1x) Multiply AI hero battle XP by this value in percent (e.g. 133 = 133%)")]
        [SettingPropertyGroup("Combat")]
        public int CombatXPAIHeroMultiplier { get; set; } = 100;

        [XmlElement]
        [SettingProperty("Additional Ranged Multiplier", 1, 100000, "(Default 1x) Add to ranged difficulty shot multiplier by this value in percent (e.g. 133 = \"+1.33\")")]
        [SettingPropertyGroup("Combat")]
        public int CombatXPRangedAdder { get; set; } = 100;
    }
}
