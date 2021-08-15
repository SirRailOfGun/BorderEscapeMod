using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;

namespace BorderEscapeMod.NPCs
{
    public class VisualsManager : ModPlayer
    {
        //public override bool InstancePerEntity => true;

        public bool SelfTok;
        public int AbyssNovaCharging;

        public override void ResetEffects()
        {
            SelfTok = false;
            AbyssNovaCharging = 0;
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (SelfTok)
            {
                for (int i = 0; i < 9; i++)
                {
                    float angleOffset = Main.rand.NextFloat(0f, 40f);
                    float angle = MathHelper.ToRadians(i*40+40+angleOffset); //iterate projectiles at 40 degree increments from 80 to 360
                    float offsetX = 1;
                    float offsetY = 0;
                    float posX = (Convert.ToSingle(0.25 * Math.Cos(angle + offsetX)) * (Math.Max(player.Size.X, player.Size.Y) * 5)) - (player.Size.X / 2);
                    float posY = (Convert.ToSingle(0.25 * Math.Sin(angle + offsetY)) * (Math.Max(player.Size.X, player.Size.Y) * 5)) - (player.Size.Y / 2);
                    int dust = Dust.NewDust(
                        drawInfo.position - new Vector2(posX, posY),
                        1,
                        1,
                        DustID.InfernoFork, //the dust to spawn
                        player.velocity.X,
                        player.velocity.Y,
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
                    float posX = (Convert.ToSingle(0.25 * Math.Cos(angle + offsetX)) * (Math.Max(player.Size.X, player.Size.Y) * 5)) - (player.Size.X / 2);
                    float posY = (Convert.ToSingle(0.25 * Math.Sin(angle + offsetY)) * (Math.Max(player.Size.X, player.Size.Y) * 5)) - (player.Size.Y / 2);
                    int dust = Dust.NewDust(
                        drawInfo.position - new Vector2(posX, posY),
                        1,
                        1,
                        DustID.InfernoFork, //the dust to spawn
                        player.velocity.X,
                        player.velocity.Y,
                        100,
                        default(Color),
                        3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale *= 0.1f;
                }
                r *= 1f;
                g *= 1f;
                b *= 0.5f;
                fullBright = true;
                //Lighting.AddLight(player.position, 1f, 1f, 0.5f);
            }

            if (AbyssNovaCharging != 0)
            {
                drawInfo.bodyGlowMask = 0;
            }
        }
    }
}
