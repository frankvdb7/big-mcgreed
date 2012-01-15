﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace Big_McGreed.content.menu.buttons
{
    public class HighScoreButton : Button
    {
        public HighScoreButton()
        {
            normal = Program.INSTANCE.loadTexture("ButtonNormal");
            pressed = Program.INSTANCE.loadTexture("ButtonPressed");
            hover = Program.INSTANCE.loadTexture("ButtonHighlight");
            current = normal;

            text = "HIGHSCORE";
        }

        public override void action()
        {
            if (Program.INSTANCE.LastGameState == GameWorld.GameState.Menu)
            {
                Program.INSTANCE.highscoreMenu = "HoofdMenu";
            }
            if (Program.INSTANCE.LastGameState == GameWorld.GameState.Paused)
            {
                Program.INSTANCE.highscoreMenu = "Paused";
            }
            Program.INSTANCE.CurrentGameState = GameWorld.GameState.Highscore;
        }
    }
}