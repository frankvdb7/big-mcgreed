﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Big_McGreed.content.gameinterface.interfaces;
using Big_McGreed.content.upgrades;

namespace Big_McGreed.content.gameinterface.buttons
{
    public class UpgradeEcoWall : InterfaceComponent
    {
        public UpgradeEcoWall()
        {
            normal = Program.INSTANCE.loadTexture("EcoWall");
            pressed = Program.INSTANCE.loadTexture("EcoWallClicked");
            hover = Program.INSTANCE.loadTexture("EcoWallHighlight");
            current = normal;

            hoverText = "Get an electric fence which you can use UNLIMITED \n times, it has a delay of 1 min.";
            errorText = "You do not have enough money!";

            Location = new Vector2(Program.INSTANCE.IManager.upgradeAchtergrond.tekst2Location.X + Program.INSTANCE.IManager.font.MeasureString(UpgradeAchtergrond.tekst2).X / 2 - current.Width / 2, Program.INSTANCE.IManager.upgradeAchtergrond.tekst2Location.Y + Program.INSTANCE.IManager.upgradeAchtergrond.mainTexture.Height / 5);
        }

        public override void action()
        {
            if (Program.INSTANCE.player.Wall.LevelUp() == true)
            {
                Program.INSTANCE.player.good++;
                Program.INSTANCE.player.UpdateCrosshair();
            }
            else
            {
                error = true;
            }
        }
    }
}
