using BorderEscapeMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.SkillCards
{
	public class GroundMelt : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ground Melt");
			Tooltip.SetDefault("Sears the ground, causing explosions. The actual heat wave has no hitbox, but the ground explodes in this attack.");
		}

		public override void SetDefaults() {
			item.damage = 30;
			item.noMelee = true;
			item.magic = true;
			item.channel = true; //Channel so that you can hold the weapon [Important]
			item.rare = ItemRarityID.Pink;
			item.width = 28;
			item.height = 30;
			item.useTime = 25;
			item.mana = 10;
			item.UseSound = SoundID.Item79;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shootSpeed = 14f;
			item.useAnimation = 60;
			item.shoot = ModContent.ProjectileType<GroundMeltOrigin>();
			item.value = Item.sellPrice(silver: 3);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Flamelash);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}