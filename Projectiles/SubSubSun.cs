using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace BorderEscapeMod.Projectiles
{
	public class SubSubSun : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Subterranean Sub-Sun");
		}

		public override void SetDefaults() {
			//projectile.name = "Mega Flare";
			projectile.width = 50;
			drawOffsetX = -45;
			projectile.height = 50;
			drawOriginOffsetY = -45;
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
            projectile.localNPCHitCooldown = -1; // 1 hit per npc max
                                                     
        }
		public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 30f)
            {
                Lighting.AddLight(projectile.Center, 1f, 1f, 0.5f); //full light
                projectile.netUpdate = true;
                // Do something here, maybe change to a new state.
                projectile.tileCollide = true;
            }
        }
    }
}