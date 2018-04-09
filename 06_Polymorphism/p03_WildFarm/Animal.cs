using System;
using System.Linq;

public abstract class Animal
{
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name { get; set; }

    public double Weight { get; set; }

    public int FoodEaten { get; set; }

    protected virtual Type[] PreferredFoods => new Type[]{typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};

    protected virtual double WeightIncreaseMultiplier => 1;

    public void TryEatFood(Food food)
    {
        if (!this.PreferredFoods.Contains(food.GetType()))
        {
            throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        this.FoodEaten += food.Quantity;
        this.Weight += food.Quantity * this.WeightIncreaseMultiplier;
    }

    public virtual void ProducingSound()
    {
        Console.WriteLine();
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, ";
    }
}