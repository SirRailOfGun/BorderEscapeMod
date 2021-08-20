using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;
using BorderEscapeMod.NPCs;

namespace BorderEscapeMod.Items
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers, additions to knockback and crit, and our custom resource that governs the usage of the weapons of this damage class.
	public class SpiritManager : ModPlayer
	{
		public static SpiritManager ModPlayer(Player player)
		{
			return player.GetModPlayer<SpiritManager>();
		}

		//// Vanilla only really has damage multipliers in code
		//// And crit and knockback is usually just added to
		//// As a modder, you could make separate variables for multipliers and simple addition bonuses
		//public float exampleDamageAdd;
		//public float exampleDamageMult = 1f;
		//public float exampleKnockback;
		//public int exampleCrit;

		// Here we include a custom resource, similar to mana or health.
		// Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
		public bool SelfTokBuff;
		public bool ClearTokBuff;
		public int SpiritCurrent;
		public const int DefaultSpiritMax = 100;
		public int SpiritMax;
		public int SpiritMax2;
		public string SpiritRegenType;  //determines how spirit is gained and lost
		public float Grazing;			//duration of graze in frames. usually 1 but can be longer
		public float GrazeFactor;		//multiply damage by this to get spirit cost. set by each source of graze
		public float AuxGrazeFactor;	//multiply damage by this to get spirit cost. only used by global graze cost modifiers
		public float GrazeCap;			//maximum spirit spent on grazing
		internal int SpiritRegenTimer = 0;
		internal int SpiritDegenTimer = 0;
		internal int SpiritRegenDelay = 0;
		internal int RegenOnHit = 0;
		internal int RegenOnKill = 0;
		internal int RegenOnDamage = 0;
		internal float damagebuff = 0;

		public static readonly Color HealSpirit = new Color(187, 91, 201); // We can use this for CombatText, if you create an item that replenishes SpiritCurrent.

		/*
		In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		Here are additional things you might need to implement if you intend to make a custom resource:
		- Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and clientClone will be necessary, as well as SyncPlayer if you allow the user to increase SpiritMax.
		- Save/Load and increased max resource: You'll need to implement Save/Load to remember increases to your SpiritMax cap.
		- Resouce replenishment item: Use GlobalNPC.NPCLoot to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.
		*/

		public override void Initialize()
		{
			SpiritMax = DefaultSpiritMax;
		}

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
            Grazing = 0;
            GrazeFactor = 0;
            AuxGrazeFactor = 0;
            RegenOnHit = 0;
			RegenOnKill = 0;
			RegenOnDamage = 0;
			//damagebuff = 0;
			SpiritMax2 = SpiritMax;
			//ClearTokBuff = false;
			SelfTokBuff = false;
			SpiritRegenType = "";
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		// Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
		private void UpdateResource()
		{
			float SpiritRegenRate = 0;		//frames betwen regen
			int SpiritRegenAmt = 0;			//amount regened on a regen frame
			float SpiritRegenDelayTime = 0;	//seconds before regen starts after using spirit
			switch (SpiritRegenType)
			{
				case "Template":	//Every regen type is named after the character to keep naming consistant.
					break;
				case "Reimu":		//need to make regen faster if not attacked at all for some time
					SpiritRegenAmt = 1;
					SpiritRegenRate = 3;
					SpiritRegenDelayTime = 10;
					break;
				case "Marisa":
					SpiritRegenAmt = -2;
					SpiritRegenRate = 120;
					SpiritRegenDelayTime = 0;
					foreach (var effect in player.buffType)
                    {
						if (effect > 0							//if effect is active
							&& !Main.debuff[effect]				//and not a debuff
							&& !Main.buffNoTimeDisplay[effect])	//and not a minion, pet, or other misc effect
                        {
							SpiritRegenAmt += 1;
						}
                    }
					break;
				case "Patchy":
					SpiritRegenAmt = 1;
					SpiritRegenRate = 120;
					SpiritRegenDelayTime = 0;
					break;
				case "Okku":
					SpiritCurrent += RegenOnDamage;
					SpiritCurrent += RegenOnHit;
					break;
				default:
					break;
			}
			if (SpiritRegenDelay > (SpiritRegenDelayTime * 60) && SpiritRegenDelayTime > 0)
			{
				// For our resource lets make it regen slowly over time to keep it simple, let's use SpiritRegenTimer to count up to whatever value we want, then increase currentResource.
				SpiritRegenTimer++; //Increase it by 60 per second, or 1 per tick.

				if (SpiritRegenTimer > SpiritRegenRate && SpiritRegenRate > 0)
				{
					SpiritCurrent += SpiritRegenAmt;
					SpiritRegenTimer = 0;
				}
			}
			if (SelfTokBuff && SpiritCurrent > 0)
            {
				SpiritDegenTimer++;
				if (SpiritDegenTimer > 10)
				{
					SpiritCurrent -= 1;
					damagebuff += .05f;
				}
            }
			else
			{
				player.GetModPlayer<SpiritManager>().ClearTokBuff = true;
				damagebuff = 0;
            }
			// Limit SpiritCurrent from going over the limit imposed by SpiritMax.
			SpiritCurrent = Utils.Clamp(SpiritCurrent, 0, SpiritMax2);
			SpiritRegenDelay++;
		}
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
			if (Grazing > 0)
            {
				player.GetModPlayer<VisualsManager>().SelfTok = true;
				float SpiritCost = damage * GrazeFactor * AuxGrazeFactor;
				SpiritCost = Utils.Clamp(SpiritCost, 0, GrazeCap);
				if (SpiritCost < SpiritCurrent)
                {
					SpiritCurrent -= Convert.ToInt32(SpiritCost);
					
					return false;
                }
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
			mult += damagebuff;
            base.ModifyWeaponDamage(item, ref add, ref mult, ref flat);
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
			switch (SpiritRegenType)
			{
				case "Okku":
					SpiritCurrent += Convert.ToInt32(damage / 10);
					break;
				default:
					break;
			}
			base.PostHurt(pvp, quiet, damage, hitDirection, crit);
        }
        public override void OnHitAnything(float x, float y, Entity victim)
		{
			switch (SpiritRegenType)
			{
				case "Okku":
					SpiritCurrent += 2;
					break;
				default:
					break;
			}
            base.OnHitAnything(x, y, victim);
}
	}
}
