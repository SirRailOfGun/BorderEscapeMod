using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BorderEscapeMod.Items;

namespace BorderEscapeMod.Buffs
{
    public class GrazeBuff : ModBuff
    {
        public int Graze = 0;
        public int GrazeCost = 0;
        public int GrazeMax = 0;
        public int AuxGrazeFactor = 0;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Graze Buff");
            Description.SetDefault("Inherit this class" +
                "\nYou should not be seeing this");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            canBeCleared = false;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var SpiritManager = player.GetModPlayer<SpiritManager>();
            SpiritManager.Grazing = Graze;
            SpiritManager.GrazeFactor = GrazeCost;
            SpiritManager.GrazeCap = GrazeMax;
            SpiritManager.AuxGrazeFactor = AuxGrazeFactor;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense *= 0; //npcs have strange stats
        }
    }
}
