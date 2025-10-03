// Tree.cs
using System;

public enum TreeType { Неизвестный, Дуб, Ель, Берёза, Клён } // sort

public struct Height
{
    private int meters;

    public int Meters
    {
        get => meters;
        private set => meters = (value < 1 || value > 15) ? 1 : value;
    }

    public Height(int meters)
    {
        this.meters = 1;
        Meters = meters;
    }

    public override string ToString() => $"{Meters} м";
}

public class Tree : Plant
{
    public TreeType sort { get; private set; }
    public new Height height { get; private set; }

    public int Age => age;

    public Tree() : base("Plant", 1, 0, 0)
    {
        sort = TreeType.Неизвестный;
        height = new Height(1);
    }

    public Tree(string kind, TreeType sort, int height, int age, int water) : base(kind, age, water, 1)
    {
        this.sort = (sort == TreeType.Дуб || sort == TreeType.Берёза || sort == TreeType.Клён || sort == TreeType.Ель) ? sort : TreeType.Неизвестный;
        this.height = new Height(height);
    }

    public void harvest()
    {

        if (sort == TreeType.Дуб)
        {
            if (Age >= 40 && Age <= 50)
            {
                Console.WriteLine("Можно собрать жёлуди");
                Console.WriteLine("Сбор\n");
                Console.WriteLine("Урожай собран");
            }
            else Console.WriteLine("Дуб не готов к сбору урожая\n");
        }

        if (sort == TreeType.Берёза)
        {
            if (Age >= 25 && Age <= 50)
            {
                Console.WriteLine("Можно собрать сок");
                Console.WriteLine("Сбор\n");
                Console.WriteLine("Урожай собран");
            }
            else Console.WriteLine("Берёза не готова к сбору урожая\n");
        }

        if (sort == TreeType.Ель)
        {
            if (Age >= 30 && Age <= 50)
            {
                Console.WriteLine("Можно собрать шишки");
                Console.WriteLine("Сбор\n");
                Console.WriteLine("Урожай собран");
            }
            else Console.WriteLine("Ель не готова к сбору урожая\n");
        }

        if (sort == TreeType.Клён)
        {
            if (Age >= 30 && Age <= 60)
            {
                Console.WriteLine("Можно собрать сок");
                Console.WriteLine("Сбор");
                Console.WriteLine("Урожай собран\n");
            }
            else Console.WriteLine("Клён не готов к сбору урожая\n");
        }
    }

    public void cut(Garden garden, int index)
    {
        if (garden == null)
        {
            Console.WriteLine("Сад не передан.");
            return;
        }

        if (index < 1 || index > garden.GetTrees().Count)
        {
            Console.WriteLine("Неверный номер дерева");
            return;
        }

        var removed = garden.GetTrees()[index - 1];
        garden.GetTrees().RemoveAt(index - 1);

        garden.RemovePlant(removed);

        Console.WriteLine($"Дерево '{removed.kind}' было срублено.");
    }

    public void care(Garden garden, int index)
    {
        if (garden == null)
        {
            Console.WriteLine("Сад не передан.");
            return;
        }

        if (index < 1 || index > garden.GetTrees().Count)
        {
            Console.WriteLine("Неверный номер дерева");
            return;
        }

        var t = garden.GetTrees()[index - 1];
        t.water = 1;
        Console.WriteLine($"Дерево '{t.kind}' было полито.");
    }

    public void touch()
    {
        string[] songs = { "DEUTSCHLAND (Rammstein)", "Touch (KATSEYE)", "Я РУССКИЙ (Шаман)" };
        var rand = new Random();
        var song = songs[rand.Next(0, 2)];
        Console.WriteLine($"Вы трогаете ваши деревья под песню \"{song}\"");
    }

    public override void Print()
    {
        Console.WriteLine($"Вид : {kind}");
        Console.WriteLine($"Возраст : {Age} г.");
        Console.WriteLine($"Рост дерева: {height}");
        Console.WriteLine($"Тип дерева: {sort}");
        Console.WriteLine($"Полито дерево? {(water == 1 ? "Да" : "Нет")}");
    }
}
