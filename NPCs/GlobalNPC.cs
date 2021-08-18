using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace BorderEscapeMod.NPCs
{
    public class TestNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool SelfTok;

        public override void ResetEffects(NPC npc)
        {
            SelfTok = false;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (SelfTok)
            {
                for (int i = 0; i < 9; i++)
                {
                    float angleOffset = Main.rand.NextFloat(0f, 40f);
                    float angle = MathHelper.ToRadians(i * 40 + 40 + angleOffset); //iterate projectiles at 40 degree increments from 80 to 360
                    float offsetX = 1;
                    float offsetY = 0;
                    float posX = (Convert.ToSingle(0.25 * Math.Cos(angle + offsetX)) * (Math.Max(npc.Size.X, npc.Size.Y) * 5)) - (npc.Size.X / 2);
                    float posY = (Convert.ToSingle(0.25 * Math.Sin(angle + offsetY)) * (Math.Max(npc.Size.X, npc.Size.Y) * 5)) - (npc.Size.Y / 2);
                    int dust = Dust.NewDust(
                        npc.position - new Vector2(posX, posY),
                        1,
                        1,
                        174, //the dust to spawn
                        npc.velocity.X,
                        npc.velocity.Y,
                        100,
                        default(Color),
                        3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale *= 0.1f;
                }
                for (int i = 0; i < 9; i++)
                {
                    float angleOffset = Main.rand.NextFloat(0f, 40f);
                    float angle = MathHelper.ToRadians(i * 40 + 40 + angleOffset); //iterate projectiles at 40 degree increments from 80 to 360
                    float offsetX = 0;
                    float offsetY = 1;
                    float posX = (Convert.ToSingle(0.25 * Math.Cos(angle + offsetX)) * (Math.Max(npc.Size.X, npc.Size.Y) * 5)) - (npc.Size.X / 2);
                    float posY = (Convert.ToSingle(0.25 * Math.Sin(angle + offsetY)) * (Math.Max(npc.Size.X, npc.Size.Y) * 5)) - (npc.Size.Y / 2);
                    int dust = Dust.NewDust(
                        npc.position - new Vector2(posX, posY),
                        1,
                        1,
                        174, //the dust to spawn
                        npc.velocity.X,
                        npc.velocity.Y,
                        100,
                        default(Color),
                        3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale *= 0.1f;
                }
                Lighting.AddLight(npc.position, 1f, 1f, 0.5f);
            }
        }
    }
}
