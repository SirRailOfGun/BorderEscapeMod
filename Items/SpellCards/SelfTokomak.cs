using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.SpellCards
{
	public class SelfTokomak : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Control \"Self Tokomak\"");
			Tooltip.SetDefault("Fills the body with immense nuclear energy, spiking combat power. Defence is sacrificed due to the heat.");
		}

		public override void SetDefaults() {
			item.noMelee = true;
			item.magic = true;
			item.rare = ItemRarityID.Pink;
			item.width = 28;
			item.height = 30;
			item.useTime = 60;
			item.mana = 100;
			item.UseSound = SoundID.Item79;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shootSpeed = 14f;
			item.useAnimation = 60;
			item.value = Item.sellPrice(silver: 3);
		}

        public override void HoldItem(Player player)
        {
			if (player.itemAnimation > 0)
			{
				player.AddBuff(ModContent.BuffType<Buffs.TokomakBuff>(), 5400);
            }
			base.HoldItem(player);
        }

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.ManaCrystal, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}