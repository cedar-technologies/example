using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BinaryTree;
using example.Bst;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        { 
            Enumerable.Range(1, 500000)
                .ToList()
                .ForEach(amount => BinaryRun(amount));

        }


        public static void BinaryRun(int amount)
        {
            Console.WriteLine($"Binary Tree test");

            Tree tree = new Tree();

            Console.WriteLine($"inserting {amount} key in binary tree");

            int randomItem = new Random().Next(amount - 1);
            int randomKey = 0;

            Enumerable.Range(0, amount)
                .ToList()
                .ForEach(i =>
                {
                    int key = new Random().Next(amount * amount);
                    if (i == randomItem) randomKey = key;
                    tree.Insert(key);
                });

            Console.WriteLine("Traversing tree");

            int count = 0;

            tree.Root.Traverse(i =>
            {
                ++count;
                // Console.WriteLine($"#{++count} Node key: {i}");
            });

            Console.WriteLine($"amount in original {count}");

            Console.WriteLine($"Deleting a key {randomKey}");

            tree.remove(randomKey);

            int countAfterDelete = 0;

            tree.Root.Traverse(i =>
            {
                ++countAfterDelete;
                // Console.WriteLine($"#{++countAfterDelete} Node key: {i}");
            });

            Console.WriteLine($"amount in deleted {countAfterDelete}");

            if (count != ++countAfterDelete)
                throw new Exception("should be equal");
        }
    }
}
