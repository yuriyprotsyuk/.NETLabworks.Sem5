using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ProtsyukIS63.V15
{/// <summary>
    /// Абстрактний клас тварина
    /// </summary>
    abstract class Animal
    {
        protected IHabitat habitat;
        protected INutrition nutrition;

        public string Name { get; set; }
        public IHabitat Habitat
        {
            set { habitat = value; }
        }
        public INutrition Nutrition
        {
            set { nutrition = value; }
        }

        public Animal(IHabitat hab, INutrition nut, string name)
        {
            habitat = hab;
            nutrition = nut;
            Name = name;
        }
        public virtual void TalkLifestyle()
        {
            habitat.Live();
            habitat.Breathe();
            nutrition.Eat();
        }
        public abstract void NameSelf();
    }
    /// <summary>
    /// Ссавець
    /// </summary>
    class Mammal : Animal
    {
        public Mammal(IHabitat hab, INutrition nut, string nam)
            : base(hab, nut, nam)
        { }
        public override void NameSelf()
        {
            Console.WriteLine(Name);
        }
    }
    /// <summary>
    /// Птах
    /// </summary>
    class Bird : Animal
    {
        public Bird(IHabitat hab, INutrition nut, string nam)
            : base(hab, nut, nam)
        { }
        public override void NameSelf()
        {
            Console.WriteLine(Name);
        }


    }
    /// <summary>
    /// Риба
    /// </summary>
    class Fish : Animal
    {
        public Fish(IHabitat hab, INutrition nut, string nam)
            : base(hab, nut, nam)
        { }
        public override void NameSelf()
        {
            Console.WriteLine(Name);
        }


    }
    /// <summary>
    /// Черв`як
    /// </summary>
    class Worm : Animal
    {
        public Worm(IHabitat hab, INutrition nut, string nam)
            : base(hab, nut, nam)
        { }
        public override void NameSelf()
        {
            Console.WriteLine(Name);
        }
    }
}
