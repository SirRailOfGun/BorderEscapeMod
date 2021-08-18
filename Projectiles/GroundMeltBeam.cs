using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace BorderEscapeMod.Projectiles
{
	public class GroundMeltBeam : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ground Melt");
		}

		public override void SetDefaults() {
			projectile.width = 4;
			projectile.height = 4;
			projectile.alpha = 1;
			projectile.timeLeft = 100;
			projectile.extraUpdates = 100;
			projectile.penetrate = -1;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.magic = true;
			projectile.aiStyle = 48;
		}
        public override void AI()
        {
			projectile.ai[0] += 1f;
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 9f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 projectilePosition = projectile.position;
					projectilePosition -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					// Important, changed 173 to 178!
					int dust = Dust.NewDust(projectilePosition, 1, 1, 174, 0f, 0f, 0, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].position = projectilePosition;
					Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.013f;
					Main.dust[dust].velocity *= 0.2f;
				}
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(projectile.owner == Main.myPlayer)
            {
				Projectile.NewProjectile(
				projectile.position.X,
				projectile.position.Y,
				0,
				0,
				ModContent.ProjectileType<GroundMeltExplosion>(),
				(int)(projectile.damage),
				0f,
				projectile.owner,
				0f,
				0f);
				projectile.Kill();
			}
			return base.OnTileCollide(oldVelocity);
		}
	}
}