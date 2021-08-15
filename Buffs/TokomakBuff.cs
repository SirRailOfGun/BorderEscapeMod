using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BorderEscapeMod.NPCs;

namespace BorderEscapeMod.Buffs
{
    public class TokomakBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Self Tokomak");
            Description.SetDefault("Grants bonus Magic and Melee Damage, but negates armor due to excessive energies.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<VisualsManager>().SelfTok = true;
            player.endurance *= 0; //armor is ignored, since that's chump DR anyways
            player.magicDamage += .15f;
            player.meleeDamage += .15f; //Grant 15% damage
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<TestNPC>().SelfTok = true;
            //npc.endurance *= 0; //armor is ignored, since that's chump DR anyways
            //npc.magicDamage += .15f;
            //npc.meleeDamage += .15f; //Grant 15% damage
        }
    }
}
