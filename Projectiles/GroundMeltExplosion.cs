using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace BorderEscapeMod.Projectiles
{
	public class GroundMeltExplosion : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Subterranean Sun");
		}

		public override void SetDefaults() {
			projectile.width = 0;
			drawOffsetX = -45;
			projectile.height = 0;
			drawOriginOffsetY = -45;
			projectile.scale = 0;
			projectile.alpha = 150;
			projectile.timeLeft = 90;
			projectile.penetrate = -1;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.magic = true;
			projectile.aiStyle = 0;
		}
        public override void AI()
        {
			if (projectile.ai[0] > 30f)
			{
				projectile.friendly = true;
				if (projectile.ai[0] < 80f)
                {
					int factor = Convert.ToInt32(projectile.ai[0]) - 30;
					projectile.width = factor;
					projectile.height = factor;
					projectile.scale = factor * 0.02f;
					Lighting.AddLight(projectile.Center, (factor + 10) / 60f, (factor + 10) / 60f, (factor + 10) / 120f);
				}
			}
            else 
			{
				Lighting.AddLight(projectile.Center, 10 / 60f, 10 / 60f, 10 / 120f);
			}
			projectile.ai[0] += 1f;
			projectile.velocity.X = 0; //no moving
			projectile.velocity.Y = 0; //no gravity
		}
    }
}