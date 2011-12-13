﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Big_McGreed.content.menu.buttons
{
    public class NewGame : Button
    {
        public NewGame()
        {
            normal = Program.INSTANCE.Content.Load<Texture2D>("NewGameNormal");
            pressed = Program.INSTANCE.Content.Load<Texture2D>("NewGamePressed");
            hover = Program.INSTANCE.Content.Load<Texture2D>("NewGameHighlight");
            current = normal;
        }

        public override void action()
        {
            if (Program.INSTANCE.CurrentGameState == GameWorld.GameState.Menu)
            {
                Program.INSTANCE.CurrentGameState = GameWorld.GameState.InGame;
                Program.INSTANCE.newGame();
            }
            else if (Program.INSTANCE.CurrentGameState == GameWorld.GameState.Paused)
            {
                Program.INSTANCE.CurrentGameState = GameWorld.GameState.Select;
                Program.INSTANCE.yesKnopGedrukt = "newGame";
            }
        }
    }
}
