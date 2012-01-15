﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Big_McGreed.content.gameframe;

namespace Big_McGreed.content.gameinterface.buttons
{
    public class YesNoSelect : InterfaceComponent
    {
        string newGameText = " Are you sure you wish to start a new game?     \n\n NOTE: YOU WILL LOSE ALL YOUR PROGRESS!";
        string mainMenuText = " Are you sure you wish to go to the main menu? \n\n NOTE: YOU WILL LOSE ALL YOUR PROGRESS!";

        public YesNoSelect()
        {
            normal = Program.INSTANCE.loadTexture("YesNoKeuze");
            hover = normal;
            pressed = normal;
            current = normal;

            isInterface = true;

            textLocation = new Vector2(GameFrame.Width / 2 - InterfaceComponent.font.MeasureString(newGameText).X / 2, GameFrame.Height / 2.2f - InterfaceComponent.font.MeasureString(newGameText).Y / 2);
        }

        public override void action()
        {
        }

        public void YesNoSelectUpdate()
        {
            if (Program.INSTANCE.yesKnopGedrukt == "newGame")
            {
                text = newGameText;
                Location = new Vector2(GameFrame.Width / 2 - current.Width / 2, GameFrame.Height / 2 - current.Height / 2);
            }
            else if (Program.INSTANCE.yesKnopGedrukt == "mainMenu")
            {
                text = mainMenuText;
                Location = new Vector2(GameFrame.Width / 2 - current.Width / 2, GameFrame.Height / 2 - current.Height / 2);
            }
        }
    }
}