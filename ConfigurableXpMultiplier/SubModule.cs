using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

using HarmonyLib;
using ModLib;
using ModLib.Debugging;

namespace ConfigurableXpMultiplier
{
    class SubModule : MBSubModuleBase
    {
        public static readonly string ModuleFolderName = "ConfigurableXpMultiplier";

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            try
            {
                FileDatabase.Initialise(ModuleFolderName);
                SettingsDatabase.RegisterSettings(Settings.Instance);

                //var harmony = new Harmony("mod.bannerlord.splintert");
                //harmony.PatchAll();
            }
            catch (Exception ex)
            {
                ModDebug.ShowError($"Error Initializing ConfigurableXpMultiplier:\n\n{ex.ToStringFull()}");
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);
            
            if (Settings.Instance.SmithingXPEnabled)
                gameStarter.AddModel(new ModdedSmithingModel());

            if (Settings.Instance.CombatXPEnabled)
            {
                var xpModel = new ModdedCombatXpModel();
                xpModel.Setup();
                gameStarter.AddModel(xpModel);
            }
        }
    }
}
