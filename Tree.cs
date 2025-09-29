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
    public Height height { get; private set; }

    public int Age => age;

    public Tree() : base("Plant", 1, 0)
    {
        sort = TreeType.Неизвестный;
        height = new Height(1);
    }

    public Tree(string kind, TreeType sort, int height, int age, int water) : base(kind, age, water)
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
            }
            else Console.WriteLine("Дерево не готово к сбору урожая\n");
        }

        if (sort == TreeType.Берёза)
        {
            if (Age >= 25 && Age <= 50)
            {
                Console.WriteLine("Можно собрать сок");
                Console.WriteLine("Сбор\n");
            }
            else Console.WriteLine("Дерево не готово к сбору урожая\n");
        }

        if (sort == TreeType.Ель)
        {
            if (Age >= 30 && Age <= 50)
            {
                Console.WriteLine("Можно собрать шишки");
                Console.WriteLine("Сбор\n");
            }
            else Console.WriteLine("Дерево не готово к сбору урожая\n");
        }

        if (sort == TreeType.Клён)
        {
            if (Age >= 30 && Age <= 60)
            {
                Console.WriteLine("Можно собрать сок");
                Console.WriteLine("Сбор\n");
            }
            else Console.WriteLine("Дерево не готово к сбору урожая\n");
        }
    }

    public void cut(Garden garden, int index)
    {
        if (garden == null)
        {
            Console.WriteLine("Сад не передан.");
            return;
        }

        if (index < 1 || index > garden.trees.Count)
        {
            Console.WriteLine("Неверный номер дерева");
            return;
        }

        var removed = garden.trees[index - 1];
        garden.trees.RemoveAt(index - 1);

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

        if (index < 1 || index > garden.trees.Count)
        {
            Console.WriteLine("Неверный номер дерева");
            return;
        }

        var t = garden.trees[index - 1];
        t.water = 1;
        Console.WriteLine($"Дерево '{t.kind}' было полито.");
    }

    public void touch()
    {
        string[] songs = new string[] { "DEUTSCHLAND (Rammstein)", "Touch (KATSEYE)", "Я РУССКИЙ (Шаман)" };
        var rand = new Random();
        var song = songs[rand.Next(0, 2)];
        Console.WriteLine($"Вы трогаете ваши деревья под песню \"{song}\"");
    }

    public override void Print()
    {
        Console.WriteLine("Дерево");
        base.Print();
        Console.WriteLine($"Тип дерева: {sort}");
        Console.WriteLine($"Рост дерева: {height}");
        if (water == 1) Console.WriteLine($"Полито дерево? Да");
        else Console.WriteLine($"Полито дерево? Нет");
    }
}
