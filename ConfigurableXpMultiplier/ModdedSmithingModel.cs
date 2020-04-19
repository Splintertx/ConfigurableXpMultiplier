using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace ConfigurableXpMultiplier
{
    class ModdedSmithingModel : DefaultSmithingModel
    {
        public override int GetSkillXpForRefining(ref Crafting.RefiningFormula refineFormula)
        {
            int result = base.GetSkillXpForRefining(ref refineFormula);
            decimal mult = (decimal)Settings.Instance.RefiningXPMultiplier / 100m;

            if (mult != 1.0m)
                return (int)decimal.Round((decimal)result * mult);
            else
                return result;
        }

        public override int GetSkillXpForSmelting(ItemObject item)
        {
            int result = base.GetSkillXpForSmelting(item);
            decimal mult = (decimal)Settings.Instance.SmeltingXPMultiplier / 100m;

            if (mult != 1.0m)
                return (int)decimal.Round((decimal)result * mult);
            else
                return result;
        }

        public override int GetSkillXpForSmithing(ItemObject item)
        {
            int result = base.GetSkillXpForSmithing(item);
            decimal mult = (decimal)Settings.Instance.SmithingXPMultiplier / 100m;

            if (mult != 1.0m)
                return (int)decimal.Round((decimal)result * mult);
            else
                return result;
        }
    }
}
