using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.Equipables
{
	public class HomeBrew : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Home Brew");
			Tooltip.SetDefault("A magic potion that reinvigorates the body and mind. Do not ask what is in it." +
				"\n+100 max mana " +
				"\nGenerate spirit by drinking potions." +
				"\nYou need to drink at least 3 potions for it to take effect.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var SpiritManager = player.GetModPlayer<SpiritManager>();
			player.statManaMax2 += 100;
			SpiritManager.SpiritRegenType = "Marisa";
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