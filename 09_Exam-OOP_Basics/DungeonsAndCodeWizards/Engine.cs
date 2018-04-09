using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class Engine
    {
        private bool isRunning;
        private DungeonMaster dungeonMaster;

        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        internal void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string input = Console.ReadLine();

                try
                {
                    this.ReadCommand(input);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Parameter Error: " + e.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation: " + ioe.Message);
                }

                if (this.dungeonMaster.IsGameOver() || this.isRunning == false)
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(dungeonMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                this.isRunning = false;
                return;
            }

            string[] tokens = input.Split(' ').ToArray();
            string command = tokens[0];
            string[] arguments = tokens.Skip(1).ToArray();

            var output = string.Empty;

            switch (command)
            {
                case "JoinParty":
                    output = this.dungeonMaster.JoinParty(arguments);
                    break;
                case "AddItemToPool":
                    output = this.dungeonMaster.AddItemToPool(arguments);
                    break;
                case "PickUpItem":
                    output = this.dungeonMaster.PickUpItem(arguments);
                    break;
                case "UseItem":
                    output = this.dungeonMaster.UseItem(arguments);
                    break;
                case "GiveCharacterItem":
                    output = this.dungeonMaster.GiveCharacterItem(arguments);
                    break;
                case "UseItemOn":
                    output = this.dungeonMaster.UseItemOn(arguments);
                    break;
                case "GetStats":
                    output = this.dungeonMaster.GetStats();
                    break;
                case "Attack":
                    output = this.dungeonMaster.Attack(arguments);
                    break;
                case "Heal":
                    output = this.dungeonMaster.Heal(arguments);
                    break;
                case "EndTurn":
                    output = this.dungeonMaster.EndTurn(arguments);
                    break;
            }

            if (output != string.Empty)
            {
                Console.WriteLine(output);
            }
        }
    }
}
