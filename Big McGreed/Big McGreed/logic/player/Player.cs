﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Big_McGreed.utility;
using Microsoft.Xna.Framework;
using Big_McGreed.logic.map;
using Microsoft.Xna.Framework.Input;

namespace Big_McGreed.logic.player
{
    public class Player : Entity, Destroyable
    {

        public PlayerDefinition definition { get; set; }

        //Stelt een speler voor.

        public Player()
        {
            visible = true;
        }

        /*
         * 'Verwoest' de speler.
         */
        public void destroy()
        {
        }

        /*
         * Specifieke update.
         */
        protected override void run2()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (PrimitivePathFinder.collision(this, Mouse.GetState().X, Mouse.GetState().Y, true))
                {
                    visible = false;
                }
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                visible = true;
            }
            setLocation(PrimitivePathFinder.getPosition(Mouse.GetState().X, Mouse.GetState().Y, definition.mainTexture.Width, definition.mainTexture.Height, 2));
        }

        public override void Draw()
        {
            Program.INSTANCE.spriteBatch.Begin();
            Program.INSTANCE.spriteBatch.Draw(definition.mainTexture, getLocation(), Color.Black);
            Program.INSTANCE.spriteBatch.End();
        }
    }
}
