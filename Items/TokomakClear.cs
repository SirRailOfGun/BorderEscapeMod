using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BorderEscapeMod.Items
{
    class TokomakClear : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            if (item.damage > 0)
            {
                player.GetModPlayer<SpiritManager>().ClearTokBuff = true;
            }
            return base.UseItem(item, player);
        }
    }
}
