﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Big_McGreed.content.gameframe;

namespace Big_McGreed.content.menu.buttons
{
    public class SubmitHighscore : Button
    {
        public SubmitHighscore()
        {
            normal = Program.INSTANCE.loadTexture("TinyButtonNormal");
            pressed = Program.INSTANCE.loadTexture("TinyButtonPressed");
            hover = Program.INSTANCE.loadTexture("TinyButtonHighlight");
            current = normal;

            tinyButton = true;
            text = "SUBMIT";

            Location = new Vector2(GameFrame.Width - (current.Width + 10), GameFrame.Height - (current.Height + 10));
        }

        public override void action()
        {
            
        }
    }
}