using System;

public class Shrub : Plant
{
    public int GrowPercent { get; private set; }

    public Shrub() : base("Plant", 1, 0, 1)
    {
        GrowPercent = 10;
    }

    public Shrub(string kind, int age, int grow, int water) : base(kind, age, water, 1)
    {
        GrowPercent = (grow < 1 || grow > 1000) ? 1 : grow;
    }


    public void Grow()
    {
        GrowPercent += 10;
        Console.WriteLine($"Куст вырос ещё на 10%. Теперь рост = {GrowPercent}%.");
    }

    public static Shrub operator +(Shrub s, int value)
    {
        return new Shrub(s.kind, s.age, s.GrowPercent + value, s.water);
    }

    public static Shrub operator -(Shrub s, int value)
    {
        return new Shrub(s.kind, s.age, Math.Max(0, s.GrowPercent - value), s.water);
    }

    public static Shrub operator +(Shrub s1, Shrub s2)
    {
        return new Shrub(s1.kind, s1.age, s1.GrowPercent + s2.GrowPercent, s1.water);
    }

    public static Shrub operator -(Shrub s1, Shrub s2)
    {
        return new Shrub(s1.kind, s1.age, Math.Max(0, s1.GrowPercent - s2.GrowPercent), s1.water);
    }

    public override void Print()
    {
        Console.WriteLine("Куст");
        base.Print();
        Console.WriteLine($"Рост куста: {GrowPercent} %");
    }
}
