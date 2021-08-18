using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace BorderEscapeMod.Projectiles
{
	public class SubSunMain : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Subterranean Sun");
		}

		public override void SetDefaults() {
			projectile.width = 570;
			projectile.height = 570;
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
			projectile.localNPCHitCooldown = 20; //20 i-frames
		}
		public override void AI()
        {
			projectile.ai[0] += 1f;
			projectile.velocity.X = 0; //no moving
			projectile.velocity.Y = 0; //no gravity
			if (projectile.ai[0] >= 61f)
			{
				// stop going up and fire sub-sub-suns.
				Lighting.AddLight(projectile.Center, 1f, 1f, 0.5f); //full light
				projectile.netUpdate = true;
				if (projectile.ai[0] % 60 == 0 && projectile.owner == Main.myPlayer) //fire one wave per second
				{
					for (int i = 0; i < 36; i++)
					{
						// Calculate new speeds for other projectiles.
						// fire at a fixed angle plus an offset based on the projectile wave
						float angle = MathHelper.ToRadians(i*10-10); //iterate projectiles at 10 degree increments from 0 to 350
						float offset = projectile.ai[1];
						float speedX = Convert.ToSingle(0.25 * Math.Cos(angle + offset)) * 9f;
                        float speedY = Convert.ToSingle(0.25 * Math.Sin(angle + offset)) * 9f; // This is Vanilla code, a little more obscure.
                                                                                                                                 // Spawn the Projectile.
                        Projectile.NewProjectile(projectile.position.X + (projectile.width / 2) + speedX, projectile.position.Y + (projectile.height / 2) + speedY, speedX, speedY, ModContent.ProjectileType<SubSubSun>(), (int)(projectile.damage * 0.1), 0f, projectile.owner, 0f, 0f);
                    }
					projectile.ai[1] += 1f; //offset the angle by this scalar for spiral effect
				}
			}
			else
            {
				float growth = 0f;
				if (projectile.ai[0] < 61f)
				{
					growth = 1 - (61f / (61f - projectile.ai[0]));
				}
                else
                {
					growth = 1 - (61f / 1);

				}
				Lighting.AddLight(projectile.Center, growth, growth, growth/2); //get brighter over time
				projectile.alpha = Convert.ToInt32(255 * growth);
				projectile.position.Y -= (61f - projectile.ai[0])*.25f; //apparently, unless you directly change the projectile's coordinates, it will apply gravity.
			}
		}
    }
}