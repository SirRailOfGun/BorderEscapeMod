using Terraria;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items
{
	// This class handles everything for our custom resource class
	// Any class that we wish to be using our custom resource class will derive from this class, instead of ModItem
	public abstract class SpiritItem : ModItem
	{
		//public override bool CloneNewInstances => true;
		public int spiritCost = 0;

		public override bool CanUseItem(Player player) {
			var SpiritManager = player.GetModPlayer<SpiritManager>();

			if (spiritCost > 0) 
			{
				if (SpiritManager.SpiritCurrent >= spiritCost)
				{
					SpiritManager.SpiritCurrent -= spiritCost;
					SpiritManager.SpiritRegenDelay = 0;
					return true;
				}
				return false;
			}
			return true;
		}
	}
}
