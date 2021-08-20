using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BorderEscapeMod.NPCs;
using BorderEscapeMod.Items;

namespace BorderEscapeMod.Buffs
{
    public class TokomakBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Self Tokomak");
            //Description.SetDefault("Grants bonus Magic and Melee Damage, but negates armor due to excessive energies.");
            Description.SetDefault("Drains your spirit to power up the next attack.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<SpiritManager>().SpiritCurrent >= 0 && !player.GetModPlayer<SpiritManager>().ClearTokBuff)
            {
                player.GetModPlayer<VisualsManager>().SelfTok = true;
                player.GetModPlayer<SpiritManager>().SelfTokBuff = true;
            }
            else
            {
                player.GetModPlayer<VisualsManager>().SelfTok = false;
                player.GetModPlayer<SpiritManager>().SelfTokBuff = false;
                player.ClearBuff(buffIndex);
            }
        }
    }
}
