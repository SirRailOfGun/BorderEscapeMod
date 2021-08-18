using BorderEscapeMod.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using BorderEscapeMod.Items;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace BorderEscapeMod
{
	public class BorderEscapeMod : Mod
	{
		private UserInterface _SpiritBarUserInterface;

		internal SpiritBar SpiritBar;
		public override void Load()
		{
			// All code below runs only if we're not loading on a server
			if (!Main.dedServ)
			{
				// Custom Resource Bar
				SpiritBar = new SpiritBar();
				_SpiritBarUserInterface = new UserInterface();
				_SpiritBarUserInterface.SetState(SpiritBar);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_SpiritBarUserInterface?.Update(gameTime);
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"BorderEscapeMod: Spirit Bar",
					delegate {
						_SpiritBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}