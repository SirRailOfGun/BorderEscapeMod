using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BorderEscapeMod.NPCs;
using BorderEscapeMod.Projectiles;

namespace BorderEscapeMod.Buffs
{
    public class AbyssNovaCharging : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Abyss Nova");
            Description.SetDefault("Immense energies are building up." +
                "\nYou are more vulnerable while trying to control them");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            canBeCleared = false;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<VisualsManager>().AbyssNovaCharging = 0;
            player.endurance *= 0;
            player.statDefense *= 0;
            if (player.buffTime[buffIndex] <= 1)
            {
                Projectile.NewProjectile(
                    player.position.X,
                    player.position.Y,
                    0, 0,
                    ModContent.ProjectileType<AbyssSunMain>(),
                    1000,
                    1f,
                    player.whoAmI,
                    0f,
                    0f);
                player.AddBuff(ModContent.BuffType<Buffs.AbyssNovaInvuln>(), 600);
            }
            
        }
        public override bool ReApply(Player player, int time, int buffIndex)
        {
            return false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense *= 0; //npcs have strange stats
        }
    }
}
