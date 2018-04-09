using System;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character
    {
        private string Status => IsAlive ? "Alive" : "Dead";

        private string name;

        private double baseHealth;
        private double health;

        private double baseArmor;
        private double armor;

        private double abilityPoints;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

            this.Faction = faction;
        }

        public bool IsAlive { get; set; } = true;

        public Bag Bag { get; }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth
        {
            get
            {
                return this.baseHealth;
            }
            private set
            {
                this.baseHealth = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = Math.Min(value, this.BaseHealth);
            }
        }

        public double BaseArmor
        {
            get
            {
                return this.baseArmor;
            }
            private set
            {
                this.baseArmor = value;
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                this.armor = Math.Min(value, this.BaseArmor);
            }
        }

        public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            private set
            {
                this.abilityPoints = value;
            }
        }

        public Faction Faction { get; }

        protected virtual double RestHealMultiplier => 0.2;

        public void TakeDamage(double hitPoints)
        {
            IsCharacterAlive(this);

            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            IsCharacterAlive(this);

            this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        protected void IsCharacterAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            return $"{this.name} - HP: {this.health}/{this.BaseHealth}, AP: {this.armor}/{this.BaseArmor}, Status: {Status}";
        }
    }
}
