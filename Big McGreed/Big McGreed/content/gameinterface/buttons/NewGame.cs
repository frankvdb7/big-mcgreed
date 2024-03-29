﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Big_McGreed.content.video;

namespace Big_McGreed.content.gameinterface.buttons
{
    public class NewGame : InterfaceComponent
    {
        public NewGame()
        {
            normal = Program.INSTANCE.loadTexture("ButtonNormal");
            pressed = Program.INSTANCE.loadTexture("ButtonPressed");
            hover = Program.INSTANCE.loadTexture("ButtonHighlight");
            current = normal;

            text = "NEW GAME";
        }

        public override void action()
        {
            if (Program.INSTANCE.CurrentGameState == GameWorld.GameState.Menu)
            {
                Program.INSTANCE.CurrentGameState = GameWorld.GameState.Begin;
            }
            else if (Program.INSTANCE.CurrentGameState == GameWorld.GameState.Paused)
            {
                Program.INSTANCE.buttonClickedState = "newGame";
                Program.INSTANCE.CurrentGameState = GameWorld.GameState.Select;
            }
        }
    }
}
