using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BorderEscapeMod.NPCs;
using BorderEscapeMod.Projectiles;

namespace BorderEscapeMod.Buffs
{
    public class AbyssNovaInvuln : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Abyss Nova");
            Description.SetDefault("Immense energies are being unleashed!" +
                "\nYou are Invincible!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            canBeCleared = false;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense *= 0; //npcs have strange stats
        }
    }
}
