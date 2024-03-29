﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Big_McGreed.content.hardware
{
    /// <summary>
    /// Main Arduino Communication Manager class. Handles all in/out communication.
    /// </summary>
    public class ArduinoManager
    {
        private ArduinoCom com;
        private Thread receiveMessagesThread;
        private MessageBuilder messageBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArduinoManager"/> class.
        /// </summary>
        public ArduinoManager()
        {
            com = new ArduinoCom();
            messageBuilder = new MessageBuilder();

            messageBuilder.bufferedCommandHandler += new BufferedCommandHandler(receiveMessage); 
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void stop()
        {
            if (com.port.IsOpen)
            {
                com.port.Close();
            }
        }

        /// <summary>
        /// Create a connection with the Arduino.
        /// </summary>
        /// <returns></returns>
        public bool connect()
        {
            try
            {
                com.port.Open();
                if (com.port.IsOpen)
                {
                    com.port.DiscardInBuffer();
                    com.port.DiscardOutBuffer();
                    Console.WriteLine("Successfully connected to the Arduino.");
                    sendMessage();
                    return true;
                }
                return false;
            } 
            catch (IOException e) 
            {
                Console.Error.WriteLine(new ArduinoException(e.Message)); //Prevent the game from crashing while connecting
                return false;
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        public void sendMessage()
        {
            if (Program.INSTANCE.sendHP == true)
            {
                sendMessage("#PLAYER_HP:" + Program.INSTANCE.player.Lifes + "%");
                Program.INSTANCE.sendHP = false;
            }
            if (Program.INSTANCE.sendOil == true)
            {
                sendMessage("#OIL_LEVEL:" + Program.INSTANCE.player.oil + "%");
                Program.INSTANCE.sendOil = false;
            }
            if (Program.INSTANCE.sendGold == true)
            {
                sendMessage("#GOLD:" + Program.INSTANCE.player.gold + "%");
                Program.INSTANCE.sendGold = false;
            }
            if (Program.INSTANCE.sendScore == true)
            {
                sendMessage("SCORE:" + Program.INSTANCE.player.Score + "%");
                Program.INSTANCE.sendScore = false;
            }
        }

        /// <summary>
        /// Receives the message.
        /// </summary>
        /// <param name="command">The message.</param>
        private void receiveMessage(String command)
        {
            command = command.Substring(1, command.Length - 1); //Haal command start en end van de string af.
            switch (command)
            {
                case ArduinoConstants.BOTTOM_LED_AAN:
                    //Doe iets...
                    break;
                default:
                    Console.Error.WriteLine(new ArduinoException("Arduino message: " + command + " is unhandled."));
                    break;
            }
        }


        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private bool sendMessage(string message)
        {
            if (com.port.IsOpen)
            {
                try
                {
                    com.port.Write(message);
                    return true;
                }
                catch (Exception exception)
                {
                    Console.Error.WriteLine(new ArduinoException(exception.Message)); //Prevent the game from crashing while writing
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// This runs every DATA_READING_INTERVAL milliseconds. 
        /// </summary>
        protected void run()
        {
            while (com.port.IsOpen)
            {
                if (com.port.BytesToRead > 0)
                {
                    try
                    {
                        string dataFromSocket = com.port.ReadExisting();
                        messageBuilder.Append(dataFromSocket);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(new ArduinoException(e.Message));
                    }
                }
                System.Threading.Thread.Sleep(ArduinoConstants.DATA_READING_INTERVAL);
            }
        }
    }
}
