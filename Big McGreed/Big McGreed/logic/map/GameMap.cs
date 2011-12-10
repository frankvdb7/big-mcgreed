﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Big_McGreed.logic.map.objects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Big_McGreed.logic.projectile;

namespace Big_McGreed.logic.map
{
    public class GameMap
    {
        private Texture2D mainTexture;

        private LinkedList<GameObject> objects;
        private LinkedList<Projectile> projectiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameMap"/> class.
        /// </summary>
        public GameMap()
        {
            objects = new LinkedList<GameObject>();
            projectiles = new LinkedList<Projectile>();
            mainTexture = Program.INSTANCE.Content.Load<Texture2D>("Achtergrond");
        }

        public void AddProjectile(Projectile projectile)
        {
            projectiles.AddLast(projectile);
        }

        /// <summary>
        /// Draws the background.
        /// </summary>
        public void DrawBackground()
        {
            float scale = 1.0f;
            //Console.WriteLine(scale);
            Program.INSTANCE.spriteBatch.Draw(mainTexture, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Draws objects in this instance.
        /// </summary>
        public void DrawObjects()
        {
            lock(objects) {
                foreach (GameObject gameObject in objects)
                {
                    gameObject.Draw();
                }
            }
        }

        /// <summary>
        /// Updates the projectiles.
        /// </summary>
        public void UpdateProjectiles()
        {
            lock (projectiles)
            {
                foreach (Projectile projectile in projectiles)
                {
                    projectile.Update();
                }
            }
        }

        /// <summary>
        /// Draws projectiles in this instance.
        /// </summary>
        public void DrawProjectiles()
        {
            lock (projectiles)
            {
                foreach (Projectile projectile in projectiles)
                {
                    projectile.Draw();
                }
            }
        }
    }
}
