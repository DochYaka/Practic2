using System;

public class Shrub : Plant
{
    public int grow { get; set; }

    public Shrub() : base("Plant", 1, 0)
    {
        grow = 10;
    }

    public Shrub(string kind, int age, int grow, int water) : base(kind, age, water)
    {
        this.grow = (grow < 1 || grow > 1000) ? 1 : grow;
    }

    public void Grow()
    {
        int delta = 10;
        grow += delta;
        Console.WriteLine($"Куст вырос ещё на {delta}%. Теперь рост = {grow}%.");
    }

    public override void Print()
    {
        Console.WriteLine("Куст");
        base.Print();
        Console.WriteLine($"Вырос на {grow} %");
    }
}
