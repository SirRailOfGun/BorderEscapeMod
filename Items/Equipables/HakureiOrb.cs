using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.Equipables
{
	public class HakureiOrb : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Divine Spirit");
			Tooltip.SetDefault("A blessing that grants the user magic powers." +
				"\nGenerate spirit after not using any for a while." +
				"\nIt's faster if you don't attack either.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}
        public override bool CanEquipAccessory(Player player, int slot)
        {
            return base.CanEquipAccessory(player, slot);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var SpiritManager = player.GetModPlayer<SpiritManager>();
			//player.statManaMax2 += 100;
			SpiritManager.SpiritRegenType = "Reimu";
		}

		public override void AddRecipes()
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ModContent.ItemType<EquipMaterial>(), 60);
			//recipe.AddTile(ModContent.TileType<ExampleWorkbench>());
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		}
	}
}