using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private List<Character> charactersParty;
        private List<Item> itemsPool;
        private int lastSurvivorRounds;
        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.charactersParty = new List<Character>();
            this.itemsPool = new List<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            if (characterType != "Cleric" && characterType != "Warrior")
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);
            
            charactersParty.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);
            
            itemsPool.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (this.itemsPool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            Character character = FindCharacter(characterName);
            Item item = this.itemsPool[itemsPool.Count - 1];
            this.itemsPool.Remove(item);
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = FindCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        private Character FindCharacter(string name)
        {
            var character = this.charactersParty.FirstOrDefault(e => e.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }

        public string GetStats()
        {
            List<Character> orderedCharacters = this.charactersParty.OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health).ToList();

            StringBuilder builder = new StringBuilder();

            foreach (var character in orderedCharacters)
            {
                builder.AppendLine(character.ToString());
            }

            return builder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = FindCharacter(attackerName);
            Character receiver = FindCharacter(receiverName);

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            Warrior warrior = (Warrior) attacker;
            warrior.Attack(receiver);

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                builder.AppendLine($"{receiver.Name} is dead!");
            }

            return builder.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = FindCharacter(healerName);
            Character receiver = FindCharacter(healingReceiverName);

            if (healer.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            Cleric cleric = (Cleric)healer;
            cleric.Heal(receiver);

            return
                $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var character in this.charactersParty.Where(c => c.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                builder.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (charactersParty.Count(c => c.IsAlive) <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return builder.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.charactersParty.Count(c => c.IsAlive) <= 1;
            var lastSurviverSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }
    }
}
