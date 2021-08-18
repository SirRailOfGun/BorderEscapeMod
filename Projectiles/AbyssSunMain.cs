using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace BorderEscapeMod.Projectiles
{
	public class AbyssSunMain : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hell's Second Sun");
		}

		public override void SetDefaults() {
			projectile.width = 100;
			projectile.height = 100;
			projectile.alpha = 150;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.aiStyle = 0;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 2; //2 i-frames
		}
        public override void AI()
        {
			projectile.ai[0] += 1f;
			projectile.velocity.X = 0; //no moving
			projectile.velocity.Y = 0; //no gravity
			if (projectile.ai[0] % 20 == 0 && projectile.owner == Main.myPlayer)
			{
				float speedX = 0;
				float speedY = projectile.ai[1] % 2;

                Projectile.NewProjectile(
					projectile.position.X + (projectile.width / 2), 
					projectile.position.Y + (projectile.height / 2), 
					speedX,
					speedY,
					ModContent.ProjectileType<AbyssNovae>(),
					(int)(projectile.damage * 0.1),
					0f, 
					projectile.owner, 
					0f, 
					0f);
                    
				projectile.ai[1] += 1f; //counter of fired projectiles
			}
		}
    }
}