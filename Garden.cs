// Garden.cs
using System;
public class Garden : IGarden
{
    private List<Plant> plants = new List<Plant>();
    private List<Tree> trees = new List<Tree>();
    
    public List<Tree> GetTrees()
    {
        return trees;
    }

    public List<Plant> GetPlants()
    {
        return plants;
    }

    public void AddPlant(Plant plant)
    {
        plants.Add(plant);
    }

    public void AddTree(Tree tree)
    {
        trees.Add(tree);
    }

    public void RemovePlant(Plant plant)
    {
        plants.Remove(plant);
    }

    public void RemoveTree(Tree tree)
    {
        trees.Remove(tree);
    }

    public void ShowTrees()
    {
        if (trees.Count == 0)
        {
            Console.WriteLine("В саду нет деревьев");
            return;
        }

        Console.WriteLine("\n=== Деревья в саду ===");
        for (int i = 0; i < trees.Count; i++)
        {
            Console.WriteLine($"\nДерево #{i + 1}:");
            trees[i].Print();
            Console.WriteLine("---------------------");
        }
    }

    public void ShowPlants()
    {
        if (plants.Count == 0)
        {
            Console.WriteLine("В саду нет растений");
            return;
        }

        Console.WriteLine("\n=== Растения в саду ===");
        for (int i = 0; i < plants.Count; i++)
        {
            Console.WriteLine($"Растение #{i + 1}:");
            plants[i].Print();
            Console.WriteLine("---------------------");
        }
    }
}
