using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items.Equipables
{
	[AutoloadEquip(EquipType.Body)]
	public class NuclearSpirit : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Nuclear Spirit");
			Tooltip.SetDefault("A powerful sun spirit whose energies empower both melee and magic."
				+ "\nImmunity to 'On Fire!'"
				+ "\n30% increased melee and magic damage"
				+ "\n+40 max mana"
				+ "\n10% reduced damage taken");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 0;
		}

		public override void UpdateEquip(Player player)
		{
			var SpiritManager = player.GetModPlayer<SpiritManager>();
			player.buffImmune[BuffID.OnFire] = true;
			player.statManaMax2 += 40;
			player.meleeDamage += 30;
			player.magicDamage += 30;
			player.endurance += 10;
			SpiritManager.SpiritRegenType = "Okku";
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