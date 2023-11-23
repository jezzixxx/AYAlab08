namespace MyLib
{
    public enum eFavoriteFood { Meat, Plants, Everything }
    public enum eClassificationAnimal { Herbivores, Carnivores, Omnivores }
    [AnimalAttribute("Неопознанное животное")]
    public abstract class Animal
    {
        public Animal(string country, string hide, string name, string whatan)
        {
            Country = country;
            HideFromOtherAnimals = hide;
            Name = name;
            WhatAnimal = whatan;
        }
        protected virtual void SayHello() { Console.WriteLine("Кто я?"); }
        public string Country { get; set; }
        public string HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public string WhatAnimal { get; set; }
        protected virtual eClassificationAnimal GetClassificationAnimal() { if (this is Cow) return eClassificationAnimal.Herbivores; else if (this is Lion) return eClassificationAnimal.Carnivores; else if (this is Pig) return eClassificationAnimal.Omnivores; else throw new ArgumentException(); }
        protected virtual eFavoriteFood GetFavoriteFood() { return this.GetFavoriteFood(); }
    }
    [AnimalAttribute("Опознанное милое в пятнышко животное")]
    public class Cow : Animal
    {
        public Cow(string country, string hide, string name, string whatan) : base(country, hide, name, whatan) { }
        protected override void SayHello() { Console.WriteLine("Mo-o-o"); }
        protected override eFavoriteFood GetFavoriteFood() { return eFavoriteFood.Plants; }
    }
    [AnimalAttribute("Опознанный царь зверей")]
    public class Lion : Animal
    {
        public Lion(string country, string hide, string name, string whatan) : base(country, hide, name, whatan) { }
        protected override void SayHello() { Console.WriteLine("Roar"); }
        protected override eFavoriteFood GetFavoriteFood() { return eFavoriteFood.Meat; }
    }
    [AnimalAttribute("Опознанное розовое смешное животное")]
    public class Pig : Animal
    {
        public Pig(string country, string hide, string name, string whatan) : base(country, hide, name, whatan) { }
        protected override void SayHello() { Console.WriteLine("Oink"); }
        protected override eFavoriteFood GetFavoriteFood() { return eFavoriteFood.Everything; }
    }
    public class AnimalAttribute : Attribute
    {
        public string Comment { get; }
        public AnimalAttribute(string comment) => Comment = comment;
    }
}