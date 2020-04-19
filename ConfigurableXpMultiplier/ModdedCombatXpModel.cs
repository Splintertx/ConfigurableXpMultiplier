using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace ConfigurableXpMultiplier
{
    class ModdedCombatXpModel : DefaultCombatXpModel
    {
        static decimal troopMult = 0m;
        static decimal playerMult = 0m;
        static decimal heroMult = 0m;
        static decimal rangedAdder = 0m;

        internal void Setup()
        {
            troopMult = (decimal)Settings.Instance.CombatXPTroopMultiplier / 100m;
            heroMult = (decimal)Settings.Instance.CombatXPAIHeroMultiplier / 100m;
            playerMult = (decimal)Settings.Instance.CombatXPPlayerMultiplier / 100m;
            rangedAdder = (decimal)Settings.Instance.CombatXPRangedAdder / 100m;
        }

        public override void GetXpFromHit(CharacterObject attackerTroop, CharacterObject attackedTroop, int damage, bool isFatal, MissionTypeEnum missionType, out int xpAmount)
        {
            base.GetXpFromHit(attackerTroop, attackedTroop, damage, isFatal, missionType, out xpAmount);

            if (missionType == MissionTypeEnum.Battle)
            {
                decimal mult = getMult(attackerTroop);

                if (mult != 1.0m)
                    xpAmount = (int)decimal.Round((decimal)xpAmount * mult);
            }
        }

        public override float GetXpMultiplierFromShotDifficulty(float shotDifficulty)
        {
            float result = base.GetXpMultiplierFromShotDifficulty(shotDifficulty);

            if (rangedAdder != 1.0m)
                return (float)((decimal)result + rangedAdder);
            else
                return result;
        }

        decimal getMult(CharacterObject attackerTroop)
        {
            if (!attackerTroop.IsHero)
                return troopMult;
            else
            {
                if (!attackerTroop.IsPlayerCharacter)
                    return heroMult;
                else
                    return playerMult;
            }
        }
    }
}
