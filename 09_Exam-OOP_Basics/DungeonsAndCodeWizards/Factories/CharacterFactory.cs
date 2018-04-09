using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionStr, string characterType, string name)
        {
            if (factionStr != "CSharp" && factionStr != "Java")
            {
                string message = factionStr;
                throw new ArgumentException($"Invalid faction \"{message}\"!");
            }

            if (characterType != "Cleric" && characterType != "Warrior")
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            Faction faction = Enum.Parse<Faction>(factionStr);
            Character character = null;
            if (characterType == "Cleric")
            {
                character = new Cleric(name, faction);
            }
            else
            {
                character = new Warrior(name, faction);
            }

            return character;
        }

        //public Character CreateCharacter(string faction, string type, string name)
        //{
        //    if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
        //    {
        //        throw new ArgumentException($"Invalid faction \"{faction}\"!");
        //    }

        //    Character character;
        //    switch (type)
        //    {
        //        case "Warrior":
        //            character = new Warrior(name, parsedFaction);
        //            break;
        //        case "Cleric":
        //            character = new Cleric(name, parsedFaction);
        //            break;
        //        default:
        //            throw new ArgumentException($"Invalid character type \"{type}\"!");
        //    }

        //    return character;
        //}
    }
}
