// Program
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        Garden garden = new Garden();
        
        while (true)
        {
            Console.WriteLine("\nВаш выбор:");
            Console.WriteLine("1 - Ввести растение");
            Console.WriteLine("2 - Ввести дерево");
            Console.WriteLine("3 - Ввести куст");
            Console.WriteLine("4 - Информация о растениях в саду");
            Console.WriteLine("5 - Информация о деревьях в саду");
            Console.WriteLine("0 - Выход");

            int choice = InputFunc.ReadInt("Введите номер пункта: ", 0, 5);

            switch (choice)
            {
                case 1:
                    {
                        string type = InputFunc.ReadString("Введите растение: ");
                        int height = InputFunc.ReadInt("Введите рост растения (м): ", 1, 16);
                        int age = InputFunc.ReadInt("Введите возраст растения (г): ", 1, 1000);
                        int water = InputFunc.ReadInt("Полито растение? ", 0, 1);
                        
                        garden.AddPlant(new Plant(type, age, water));
                        break;
                    }

                case 2:
                    {
                        string type = InputFunc.ReadString("Введите вид дерева: ");

                        int typeChoice = InputFunc.ReadInt("Выберите тип дерева (0-Неизвестный 1-Дуб 2-Ель 3-Берёза 4-Клён): ", 0, 4);
                        TreeType sort = (TreeType)typeChoice;

                        int height = InputFunc.ReadInt("Введите рост дерева (м): ", 1, 15);
                        int age = InputFunc.ReadInt("Введите возраст дерева (г): ", 1, 1000);
                        int water = InputFunc.ReadInt("Полито дерево? ", 0, 1);

                        Tree newTree = new Tree(type, sort, height, age, water);
                        garden.AddPlant(newTree);
                        garden.AddTree(newTree);

                        break;
                    }

                case 3:
                    {
                        string type = InputFunc.ReadString("Введите вид куста: ");
                        int age = InputFunc.ReadInt("Введите возраст куста (г): ", 1, 1000);
                        int grow = InputFunc.ReadInt("Введите куста в процентах (г): ", 1, 1000);
                        int water = InputFunc.ReadInt("Полит куст? ", 0, 1);

                        garden.AddPlant(new Shrub(type, age, grow, water));
                        break;
                    }

                case 4:
                    {
                        garden.ShowPlants();
                        break;
                    }
                
                case 5:
                    {
                        garden.ShowTrees();
                        
                        if (garden.trees.Count != 0)
                        {
                            Console.WriteLine("\nВаш выбор:");
                            Console.WriteLine("1 - Собрать урожай ");
                            Console.WriteLine("2 - Срубить дерево (срезать дерево) ");
                            Console.WriteLine("3 - Полить дерево (позаботиться) ");
                            Console.WriteLine("4 - Потрогать под вдохновляющую музыку ");
                            Console.WriteLine("0 - Выход");

                            int choice2 = InputFunc.ReadInt("Введите номер пункта: ", 0, 4);

                            switch (choice2)
                            {
                                case 1:
                                    {
                                        for (int i = 0; i < garden.trees.Count; i++) garden.trees[i].harvest();
                                        Console.WriteLine("Урожай собран");
                                        break;
                                    }
                                case 2:
                                    {
                                        int index = InputFunc.ReadInt("Какое дерево срубить? ", 1, garden.trees.Count);
                                        garden.trees[index - 1].cut(garden, index);
                                        break;
                                    }
                                case 3:
                                    {
                                        int index = InputFunc.ReadInt("Какое дерево полить? ", 1, garden.trees.Count);
                                        garden.trees[index - 1].care(garden, index);
                                        break;
                                    }
                                case 4:
                                    {
                                        garden.trees[0].touch();
                                        break;
                                    }
                            }
                        }

                        break;
                            
                    }

                case 0:
                    return;
            }

        }
    }
}
