using BorderEscapeMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.SpellCards
{
	public class GrazeTest : SpiritItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Graze Test");
			Tooltip.SetDefault("Makes you graze for 10 seconds." +
				"\nAs of right now, this just gives the Abyss Nova Invuln buff");
		}

		public override void SetDefaults() {
			item.noMelee = true;
			item.magic = true;
			item.rare = ItemRarityID.Pink;
			item.width = 28;
			item.height = 30;
			item.useTime = 1;
			item.UseSound = SoundID.Item79;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shootSpeed = 14f;
			item.useAnimation = 1;
			item.value = Item.sellPrice(silver: 3);
			spiritCost = 1;
		}
		public override void HoldItem(Player player)
		{
			if (player.itemAnimation > 0)
			{
				player.AddBuff(ModContent.BuffType<Buffs.AbyssNovaInvuln>(), 600);
			}
			base.HoldItem(player);
		}

		//public override void AddRecipes() {
		//	ModRecipe recipe = new ModRecipe(mod);
		//	recipe.AddIngredient(ItemID.NebulaArcanum);
		//	recipe.AddIngredient(ItemID.FragmentSolar, 10);
		//	recipe.AddIngredient(ItemID.FragmentNebula, 10);
		//	recipe.AddIngredient(ItemID.FragmentStardust, 10);
		//	recipe.AddTile(TileID.LunarCraftingStation);
		//	recipe.SetResult(this);
		//	recipe.AddRecipe();
		//}
	}
}