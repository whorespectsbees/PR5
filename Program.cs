using System;
using System.Collections.Generic;
using System.Text;

// Задача 1: Животные и метод PetAnimal
interface IAnimal
{
    void Voice();
}

class Elephant : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Слон издает звук: Труууу!");
    }
}

class Tiger : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Тигр рычит: Грррр!");
    }
}

class Monkey : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Обезьяна кричит: Угу!");
    }
}

class Penguin : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Пингвин издает звук: Кря!");
    }
}

class Giraffe : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Жираф говорит: Мее!");
    }
}

interface IHello
{
    void SayHello();
}

class EnglishHello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Hello");
    }
}

class FrenchHello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Bonjour");
    }
}

class SpanishHello : IHello
{
    public void SayHello()
    {
        Console.WriteLine("Hola");
    }
}

interface IFilter
{
    string Execute(string textLine);
}

class DigitFilter : IFilter
{
    public string Execute(string textLine)
    {
        return new string(textLine.Where(c => !char.IsDigit(c)).ToArray());
    }
}

class LetterFilter : IFilter
{
    public string Execute(string textLine)
    {
        return new string(textLine.Where(c => !char.IsLetter(c)).ToArray());
    }
}

interface IShape
{
    void Draw(int size);
}

class Circle : IShape
{
    public void Draw(int size)
    {
        Console.WriteLine("Это круг!");
    }
}

class Triangle : IShape
{
    public void Draw(int size)
    {
        Console.WriteLine("Это треугольник!");
    }
}

class Rectangle : IShape
{
    public void Draw(int size)
    {
        Console.WriteLine("Это прямоугольник!");
    }
}

interface ISpellcaster
{
    void CastSpell(string spellName);
}

class Witch : ISpellcaster
{
    private int mana = 12;

    public void CastSpell(string spellName)
    {
        if (mana >= 6)
        {
            Console.WriteLine($"Ведьма колдует! Эффект от заклинания '{spellName}'");
            mana -= 6;
        }
        else
        {
            Console.WriteLine($"Для использования '{spellName}' не хватает {6 - mana} единиц маны. Пейте зелья!");
        }
    }
}

class Necromancer : ISpellcaster
{
    private int mana = 18;

    public void CastSpell(string spellName)
    {
        if (mana >= 9)
        {
            Console.WriteLine($"Некромант колдует! Эффект от заклинания '{spellName}'");
            mana -= 9;
        }
        else
        {
            Console.WriteLine($"Для использования '{spellName}' не хватает {9 - mana} единиц маны. Пейте зелья!");
        }
    }
}

class Program
{
    static void PetAnimal(IAnimal animal)
    {
        Console.Write("Мы гладим зверюшку, а она нам говорит: ");
        animal.Voice();
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<IAnimal> animals = new List<IAnimal>
        {
            new Elephant(),
            new Tiger(),
            new Monkey(),
            new Penguin(),
            new Giraffe()
        };

        foreach (IAnimal animal in animals)
        {
            PetAnimal(animal);
        }

        List<IHello> greetings = new List<IHello>
        {
            new EnglishHello(),
            new FrenchHello(),
            new SpanishHello()
        };
        foreach (IHello greeting in greetings)
        {
            greeting.SayHello();
        }

        IFilter digitFilter = new DigitFilter();
        IFilter letterFilter = new LetterFilter();

        string text = "Hello123World";
        Console.WriteLine($"Original Text: {text}");
        Console.WriteLine($"After Digit Filter: {digitFilter.Execute(text)}");
        Console.WriteLine($"After Letter Filter: {letterFilter.Execute(text)}");

        List<IShape> shapes = new List<IShape>
        {
            new Circle(),
            new Triangle(),
            new Rectangle()
        };

        foreach (IShape shape in shapes)
        {
            shape.Draw(5);
        }

        ISpellcaster witch = new Witch();
        ISpellcaster necromancer = new Necromancer();

        witch.CastSpell("Fireball");
        necromancer.CastSpell("Raise Dead");
        witch.CastSpell("Teleport");
    }
}
