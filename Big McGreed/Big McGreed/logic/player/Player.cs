﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Big_McGreed.utility;
using Microsoft.Xna.Framework;
using Big_McGreed.logic.map;
using Microsoft.Xna.Framework.Input;
using Big_McGreed.logic.npc;
using Big_McGreed.logic.mask;

namespace Big_McGreed.logic.player
{
    public class Player : Entity, Destroyable
    {
        //De grootte van de 'dot' van de crosshair, stelt dotSize(width) x dotSize(height) pixels voor.
        public const int dotSize = 5;

        public PlayerDefinition definition { get; set; }

        public int currentLevel { get; set; }

        public bool leftButtonPressed = false;

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
                if (!leftButtonPressed)
                {
                    foreach (NPC npc in PrimitivePathFinder.collision(this, Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        npc.hit(new Hit(npc, this, 10));
                    }
                    leftButtonPressed = true;
                }
            }
            else
            {
                leftButtonPressed = false;
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                lock (Program.INSTANCE.npcs)
                {
                    foreach (NPC npc in Program.INSTANCE.npcs)
                    {
                        npc.visible = true;
                    }
                }
            }
            if (Mouse.GetState().X != getX() || Mouse.GetState().Y != getY())
            {
                setLocation(PrimitivePathFinder.getPosition(Mouse.GetState().X, Mouse.GetState().Y, definition.mainTexture.Width, definition.mainTexture.Height, 2));
            }
        }

        public override void Draw()
        {
            Program.INSTANCE.spriteBatch.Draw(definition.mainTexture, getLocation(), Color.Black);
        }
    }
}
