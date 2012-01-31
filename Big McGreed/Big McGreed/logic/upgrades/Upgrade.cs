﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Big_McGreed.logic.player;
using Big_McGreed.logic;
using Microsoft.Xna.Framework;

namespace Big_McGreed.content.upgrades
{
    /// <summary>
    /// This represents an upgrade.
    /// </summary>
    public class Upgrade : Locatable
    {
        private Player player;

        private string fullName;

        private string name;

        private int level = 0; 

        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrade"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="name">The name.</param>
        public Upgrade(Player player, Vector2 location, string name)
        {
            this.player = player;
            setLocation(location);
            Name = name;
        }

        /// <summary>
        /// Returns the name of the upgrade.
        /// 
        /// Sets the name of the upgrade. Definition will get loaded if not present in the cache.
        /// </summary>
        /// <returns></returns>
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
                this.fullName = name + level;
            }        
        }

        /// <summary>
        /// Levels up.
        /// </summary>
        /// <returns></returns>
        public bool LevelUp()
        {
            if (level >= 2)  //Already achieved highest level.
                return false;
            if (player.gold < definition.cost) //Player does not have enough valuta.
                return false;
            level++;
            fullName = name + level;
            return true;
        }

        /// <summary>
        /// Sets the level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        public bool setLevel(int level)
        {
            this.level = level;
            fullName = name + level;
            return true;
        }

        /// <summary>
        /// Gets the previous upgrades.
        /// </summary>
        /// <returns></returns>
        public string[] getPreviousUpgrades()
        {
            if (level <= 0)
                return null;
            string[] upgrades = new string[level];
            for (int i = 1; i <= level; i++)
            {
                upgrades[i] = name + i;
            }
            return upgrades;
        }

        /// <summary>
        /// Gets the definition.
        /// </summary>
        public UpgradeDefinition definition { get { return UpgradeDefinition.forName(fullName); } }
    }
}
