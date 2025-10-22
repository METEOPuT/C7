
namespace AnimalLibrary
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class CommentAttribute : Attribute
    {
        public string Comment { get; }

        public CommentAttribute(string comment)
        {
            Comment = comment;
        }
    }
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }
    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }
    [Comment("Абстрактный базовый класс для всех животных")]
    public abstract class Animal
    {
        public string Country { get; set; }
        public bool HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public string WhatAnimal { get; set; }
        protected Animal(string country, bool hide, string name, string whatAnimal)
        {
            Country = country;
            HideFromOtherAnimals = hide;
            Name = name;
            WhatAnimal = whatAnimal;
        }
        public void Deconstruct(out string country, out bool hide, out string name, out string whatAnimal)
        {
            country = Country;
            hide = HideFromOtherAnimals;
            name = Name;
            whatAnimal = WhatAnimal;
        }
        public abstract eClassificationAnimal GetClassificationAnimal();
        public abstract eFavouriteFood GetFavouriteFood();
        public abstract void SayHello();
    }
    [Comment("Класс коровы - травоядное животное")]
    public class Cow : Animal
    {
        public Cow(string country, bool hide, string name)
            : base(country, hide, name, "Cow") { }
        public override eClassificationAnimal GetClassificationAnimal()
        {
            return eClassificationAnimal.Herbivores;
        }
        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Plants;
        }
        public override void SayHello()
        {
            Console.WriteLine("Приветствие: Муууу");
        }
    }
    [Comment("Класс льва - хищное животное")]
    public class Lion : Animal
    {
        public Lion(string country, bool hide, string name)
            : base(country, hide, name, "Lion") { }
        public override eClassificationAnimal GetClassificationAnimal()
        {
            return eClassificationAnimal.Carnivores;
        }
        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Meat;
        }
        public override void SayHello()
        {
            Console.WriteLine("Приветствие: Рррррр");
        }
    }
    [Comment("Класс свиньи - всеядное животное")]
    public class Pig : Animal
    {
        public Pig(string country, bool hide, string name)
            : base(country, hide, name, "Pig") { }
        public override eClassificationAnimal GetClassificationAnimal()
        {
            return eClassificationAnimal.Omnivores;
        }
        public override eFavouriteFood GetFavouriteFood()
        {
            return eFavouriteFood.Everything;
        }
        public override void SayHello()
        {
            Console.WriteLine("Приветствие: Хрю-хрю-хрю");
        }
    }
}