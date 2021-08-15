using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace BorderEscapeMod.Projectiles
{
	public class GroundMeltOrigin : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("How did this hit you?");
		}

		public override void SetDefaults() {
			projectile.width = 4;
			projectile.height = 4;
			projectile.alpha = 1;
			projectile.timeLeft = 19;
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
			// Since we access the owner player instance so much, it's useful to create a helper local variable for this
			// Sadly, Projectile/ModProjectile does not have its own
			Player projOwner = Main.player[projectile.owner];
			// Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);

			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}

			projectile.rotation = MathHelper.ToRadians(projectile.ai[0] * (-1 * projectile.direction) * 5) + MathHelper.ToRadians(180);

			float angle = projectile.rotation;
			float offset = MathHelper.ToRadians(-90);
			float speedX = Convert.ToSingle(0.25 * Math.Cos(angle + offset));
			float speedY = Convert.ToSingle(0.25 * Math.Sin(angle + offset));
			if (projectile.owner == Main.myPlayer)
			{
				Projectile.NewProjectile(
					projectile.position.X,
					projectile.position.Y,
					speedX * 100f,
					speedY * 100f,
					ModContent.ProjectileType<GroundMeltBeam>(),
					(int)(projectile.damage),
					0f,
					projectile.owner,
					0f,
					0f);
			}
			projectile.ai[0] += 1f;
		}
    }
}