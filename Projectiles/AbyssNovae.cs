using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace BorderEscapeMod.Projectiles
{
	public class AbyssNovae : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Abyss Nova");
		}

		public override void SetDefaults() {
			projectile.width = 4;
			drawOffsetX = -50;
			projectile.height = 4;
			drawOriginOffsetY = -50;
			projectile.alpha = 150;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.magic = true;
			projectile.aiStyle = 0;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10; //10 i-frames
		}
        public override void AI()
        {
			if (projectile.ai[0] == 0)
            {
				if (projectile.velocity.Y != 0)
				{
					projectile.ai[1] = .1f;
				}
				else
				{
					projectile.ai[1] = -.1f;
				}
				//projectile.ai[2] = projectile.position.X;
				//projectile.ai[3] = projectile.position.Y;
			}
			projectile.velocity.X = 0; //no moving
			projectile.velocity.Y = 0; //no gravity
			projectile.width += 2;
            drawOffsetX += 1;
            projectile.position.X -= 1;
			projectile.height += 2;
			drawOriginOffsetY += 1;
			projectile.position.Y -= 1;
			projectile.scale = projectile.width / 100f;
            projectile.rotation = projectile.ai[0] * projectile.ai[1];
            Lighting.AddLight(projectile.Center, 1f, 1f, .5f);
			projectile.ai[0] += 1f;
		}
    }
}