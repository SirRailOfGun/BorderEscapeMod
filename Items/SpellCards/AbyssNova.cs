using BorderEscapeMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.SpellCards
{
	public class AbyssNova : SpiritItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Abyss Nova");
			Tooltip.SetDefault("Increases the circulation of nuclear energy in the body." +
				"\nOnce the limit is exceeded, the energies release a scorching sun which burns everything around." +
				"\nThe sun's hitbox is very large and it can't be blocked." +
				"\nAn intensely hot skill that will leave you vulnerable for a long while." +
				"\nUses 5 spirit orbs.");
		}

		public override void SetDefaults() {
			item.noMelee = true;
			item.magic = true;
			item.rare = ItemRarityID.Pink;
			item.width = 28;
			item.height = 30;
			item.useTime = 60;
			item.UseSound = SoundID.Item79;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shootSpeed = 14f;
			item.useAnimation = 60;
			item.value = Item.sellPrice(silver: 3);
			spiritCost = 100;
		}
		public override void HoldItem(Player player)
		{
			if (player.itemAnimation > 0)
			{
				player.AddBuff(ModContent.BuffType<Buffs.AbyssNovaCharging>(), 7200);
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