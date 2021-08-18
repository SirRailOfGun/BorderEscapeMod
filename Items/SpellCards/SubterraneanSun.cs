using BorderEscapeMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.SpellCards
{
	public class SubterraneanSun : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("\"Subterranean Sun\"");
			Tooltip.SetDefault("Draws energy from the earth and creates a sun on the spot. The sun manifests itself in a fixed place, and burns the surrounding area.");
		}

		public override void SetDefaults() {
			item.damage = 200;
			item.noMelee = true;
			item.magic = true;
			item.channel = true; //Channel so that you can hold the weapon [Important]
			item.rare = ItemRarityID.Pink;
			item.width = 28;
			item.height = 30;
			item.useTime = 60;
			item.mana = 250;
			item.UseSound = SoundID.Item79;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shootSpeed = 14f;
			item.useAnimation = 60;
			item.shoot = ModContent.ProjectileType<SubSunMain>();
			item.value = Item.sellPrice(silver: 3);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NebulaArcanum);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}