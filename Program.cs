using System;
using System.Collections.Generic;
using DataStructures.Trees;

namespace ConsoleApp4
{
    class Program
    {
        private static List<int> BuildTree()
        {
            // Объявляем и инициализируем временную переменную для работы с бинарным деревом
            var binaryTree = new BinarySearchTree<int>();

            // Инициализируем временную переменную для записи всех элементов введенных пользователем
            List<int> ListNodes = new List<int>() { };

            // Просим пользователя ввести необходимое количество элементов для бинарного дерева
            Console.WriteLine("Введите количество необходимых элементов бинарного дерева");
            int count = int.Parse(Console.ReadLine());
            // При помощи списка считываем все узлы и элементы дерева, которые вводит пользователь
            for (int i = 0; i < count; i++)
            {
                ListNodes.Add(int.Parse(Console.ReadLine()));
            }

            // Возвращаем список элементов дерева
            return ListNodes;
        }

        // Просим пользователя указать искомый элемент и возвращаем его
        private static int FindNode()
        {
            Console.WriteLine("Введите элемент дерева, который необходимо найти");
            int isFind = int.Parse(Console.ReadLine());
            Console.WriteLine("Ищем элемент " + isFind + " в дереве");
            return isFind;
        }

        // Просим пользователя указать удаляемый элемент и возвращаем его
        private static int RemoveNode()
        {
            Console.WriteLine("Введите элемент дерева, который необходимо удалить");
            int isRemove = int.Parse(Console.ReadLine());
            Console.WriteLine("Удаляем элемент " + isRemove + " из дерева");
            return isRemove;
        }

        // Просим пользователя указать элемент который нужно добавить
        private static int AddNode()
        {
            Console.WriteLine("Введите элемент дерева, который необходимо добавить");
            int isAdd = int.Parse(Console.ReadLine());
            Console.WriteLine("Добавляем элемент " + isAdd + " в дерево");
            return isAdd;
        }

        static void Main(string[] args)
        {
            // Объявляем и инициализируем переменную для работы с бинарным деревом
            var binaryTree = new BinarySearchTree<int>();

            // Инициализируем переменную для записи всех элементов введенных пользователем
            List<int> ListNodes = new List<int>() { };

            /// Пишем меню навигации для удобного использования и тестирования
            for (int i = 0; i < 20; i++)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\tГлавное меню");
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Построить и вывести дерево" +
                    "\n2. Найти элемент дерева" +
                    "\n3. Вставить элемент и вывести дерево" +
                    "\n4. Удалить элемент и вывести дерево" +
                    "\n5. Обойти дерево прямым способом" +
                    "\n6. Обойти дерево симметричным способом" +
                    "\n7. Обойти дерево обратным способом" +
                    "\n8. Выйти из приложения");
                string selection = Console.ReadLine();
                switch (selection)
                {

                    case "1":
                        ListNodes = BuildTree();
                        // Инициализируем пользовательскую переменную для записи списка
                        var numbersForBinaryTree = ListNodes;
                        // Выведем все элементы дерева на консоль
                        Console.WriteLine($"Элементы бинарного дерева: {string.Join(" ", numbersForBinaryTree)}");
                        // Вставляем значение в бинарное дерево
                        binaryTree.Insert(numbersForBinaryTree);
                        // Рисуем и выводим дерево на консоль
                        Console.WriteLine($"Бинарное дерево:");
                        Console.WriteLine($"{TreeDrawer.DrawTree(binaryTree)}");

                        Console.ReadLine();
                        break;

                    case "2":
                        if (binaryTree.Contains(FindNode()))
                        {
                            Console.WriteLine($"Значение найдено в дереве");
                        }
                        else
                        {
                            Console.WriteLine($"Значение не найдено в дереве");
                        }
                        Console.ReadLine();
                        break;

                    case "3":
                        ListNodes.Add(AddNode());
                        // Добавляем в дерево элемент
                        numbersForBinaryTree = ListNodes;
                        // Выведем все элементы дерева на консоль
                        Console.WriteLine($"Элементы бинарного дерева: {string.Join(" ", numbersForBinaryTree)}");
                        // Вставляем значение в бинарное дерево
                        binaryTree.Insert(numbersForBinaryTree);
                        // Рисуем и выводим дерево на консоль
                        Console.WriteLine($"Бинарное дерево:");
                        Console.WriteLine($"{TreeDrawer.DrawTree(binaryTree)}");

                        Console.ReadLine();
                        break;

                    case "4":
                        // Проверяем, есть ли такое значение в дереве
                        int temp = RemoveNode();
                        if (binaryTree.Contains(temp))
                        {
                            // Если есть - удаляем
                            binaryTree.Remove(temp);
                            // И выводим обновленное дерево
                            Console.WriteLine($"Бинарное дерево:");
                            Console.WriteLine($"{TreeDrawer.DrawTree(binaryTree)}");
                        }
                        else
                        {
                            // Если нет, говорим, что такого значения нет
                            Console.WriteLine($"Такого значения в дереве нет");
                        }
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.WriteLine("Обход дерева прямым способом:");
                        // Выводим список значений при обходе дерева прямым способом 
                        var preOrederedTree = binaryTree.GetPreOrderEnumerator();
                        while (preOrederedTree.MoveNext())
                        {
                            Console.Write($"{preOrederedTree.Current} ");
                        }
                        Console.ReadLine();
                        break;

                    case "6":
                        Console.WriteLine("Обход дерева симметричным способом:");
                        // Выводим список значений при обходе дерева симметричным способом
                        var inOrderedTree = binaryTree.GetInOrderEnumerator();
                        while (inOrderedTree.MoveNext())
                        {
                            Console.Write($"{inOrderedTree.Current} ");
                        }
                        Console.ReadLine();
                        break;

                    case "7":
                        Console.WriteLine("Обход дерева обратным способом:");
                        // Выводим список значений при обходе дерева обратным способом
                        var postOrderedTree = binaryTree.GetPostOrderEnumerator();
                        while (postOrderedTree.MoveNext())
                        {
                            Console.Write($"{postOrderedTree.Current} ");
                        }
                        Console.ReadLine();
                        break;

                    case "8":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }
    }
}
