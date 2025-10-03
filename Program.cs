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
                        int water = InputFunc.ReadInt("Полито растение? (0-Нет 1-Да): ", 0, 1);
                        
                        garden.AddPlant(new Plant(type, age, water, height));
                        break;
                    }

                case 2:
                    {
                        string type = InputFunc.ReadString("Введите вид дерева: ");

                        int typeChoice = InputFunc.ReadInt("Выберите тип дерева (0-Неизвестный 1-Дуб 2-Ель 3-Берёза 4-Клён): ", 0, 4);
                        TreeType sort = (TreeType)typeChoice;

                        int height = InputFunc.ReadInt("Введите рост дерева (м): ", 1, 15);
                        int age = InputFunc.ReadInt("Введите возраст дерева (г): ", 1, 1000);
                        int water = InputFunc.ReadInt("Полито дерево? (0-Нет 1-Да): ", 0, 1);

                        Tree newTree = new Tree(type, sort, height, age, water);
                        garden.AddPlant(newTree);
                        garden.AddTree(newTree);

                        break;
                    }

                case 3:
                    {
                        string type = InputFunc.ReadString("Введите вид куста: ");
                        int age = InputFunc.ReadInt("Введите возраст куста (г): ", 1, 1000);
                        int grow = InputFunc.ReadInt("Введите рост куста в процентах: ", 1, 1000);
                        int water = InputFunc.ReadInt("Полит куст? (0 - нет, 1 - да): ", 0, 1);

                        Shrub newShrub = new Shrub(type, age, grow, water);
                        garden.AddPlant(newShrub);

                        Console.WriteLine("\nВаш выбор:");
                        Console.WriteLine("1 - Вырастить куст");
                        Console.WriteLine("2 - Подрезать куст (-10%)");
                        Console.WriteLine("0 - Назад в меню");

                        int shrubChoice = InputFunc.ReadInt("Введите номер пункта: ", 0, 2);

                        switch (shrubChoice)
                        {
                            case 1:
                                newShrub.Grow();
                                break;
                            case 2:
                                newShrub = newShrub - 10;
                                Console.WriteLine("Куст подрезан на 10%.");
                                break;
                        }

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
                        List<Tree> treesInGarden = garden.GetTrees();

                        if (treesInGarden.Count != 0)
                        {
                            Console.WriteLine("\nВаш выбор:");
                            Console.WriteLine("1 - Собрать урожай ");
                            Console.WriteLine("2 - Срубить дерево ");
                            Console.WriteLine("3 - Полить дерево ");
                            Console.WriteLine("4 - Потрогать под вдохновляющую музыку ");
                            Console.WriteLine("0 - Выход");

                            int choice2 = InputFunc.ReadInt("Введите номер пункта: \n", 0, 4);

                            switch (choice2)
                            {
                                case 1:
                                    {
                                        foreach (var tree in treesInGarden) tree.harvest();
                                        break;
                                    }
                                case 2:
                                    {
                                        int index = InputFunc.ReadInt("Какое дерево срубить? ", 1, treesInGarden.Count);
                                        treesInGarden[index - 1].cut(garden, index);
                                        break;
                                    }
                                case 3:
                                    {
                                        int index = InputFunc.ReadInt("Какое дерево полить? ", 1, treesInGarden.Count);
                                        treesInGarden[index - 1].care(garden, index);
                                        break;
                                    }
                                case 4:
                                    {
                                        treesInGarden[0].touch();
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
