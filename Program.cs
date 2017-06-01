using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nathan_Young_HW11
{
    class Program
    {
        static void Main(string[] args)
        {
            Random numbers = new Random();
            char UserInput = 'y';

            while (UserInput == 'y')
            {
                BST tree = new BST();

                for (int i = 0; i < 30; i++)
                {
                    tree.Add(numbers.Next(0, 100));
                }
                Console.WriteLine("Satan's Traversal:");
                tree.HellSpawnInorderTraversal(tree.Root);
                Console.WriteLine("\n\nStack Traversal:");
                tree.StackInorderTraversal(tree.Root);
                Console.WriteLine("\n\nRecursive Traversal:");
                tree.RecursiveInorderTraversal(tree.Root);

                Console.WriteLine("\nAgain? (y/n)");
                UserInput = Console.ReadLine()[0];
            }
        }


        public class BST
        {
            //*************************** TREE STUFF ***************************

            BSTNode pRoot;

            public BST()
            {
                pRoot = null;
            }

            public BSTNode Root
            {
                get { return pRoot; }
                set { pRoot = value; }
            }

            public void Add(int value)
            {
                if (pRoot == null)
                {
                    pRoot = new BSTNode(value);
                }
                else
                {
                    RecursiveAdd(value, pRoot);
                }
            }
            private void RecursiveAdd(int value, BSTNode current)
            {
                if (value < current.Data)
                {
                    if (current.Left == null)
                    { current.Left = new BSTNode(value); }
                    else
                    { RecursiveAdd(value, current.Left); }
                }
                else if (value > current.Data)
                {
                    if (current.Right == null)
                    { current.Right = new BSTNode(value); }
                    else
                    { RecursiveAdd(value, current.Right); }
                }
            }



            //************************************ PART 1 *******************************
            public void RecursiveInorderTraversal(BSTNode current)
            {
                if (current == null)
                { return; }
                if (current.Left != null)
                {
                    RecursiveInorderTraversal(current.Left);
                }

                Console.Write(current.Data + " ");
                RecursiveInorderTraversal(current.Right);
            }


            //************************************* PART 2 ************************************
            public void StackInorderTraversal(BSTNode root) // layout found on geeksforgeeks.com
            {
                Stack<BSTNode> thestack = new Stack<BSTNode>();
                BSTNode current = root;
                BSTNode item = new BSTNode(0);


                while (current != null)
                {
                    thestack.Push(current);
                    current = current.Left;


                    if (current == null)
                    {
                        while (current == null)
                        {
                            if (thestack.Count != 0)
                            {
                                item = thestack.Pop();
                                Console.Write(item.Data + " ");
                                current = item.Right;
                            }
                            else
                            { break; }
                        }
                    }
                }
            }


            // ********************************* PART 3 *******************************************
            public void HellSpawnInorderTraversal(BSTNode root) // layout found on geeksforgeeks
            {
                BSTNode Current = root;
                BSTNode Precurser = new BSTNode(0);
                if (root == null)
                { return; }

                while (Current != null)
                {
                    if (Current.Left == null)
                    {
                        Console.Write(Current.Data + " ");
                        Current = Current.Right;
                    }
                    else
                    {
                        Precurser = Current.Left;
                        while (Precurser.Right != null && Precurser.Right != Current)
                        {
                            Precurser = Precurser.Right;
                        }
                        if (Precurser.Right == null)
                        {
                            Precurser.Right = Current;
                            Current = Current.Left;
                        }
                        else
                        {
                            Precurser.Right = null;
                            Console.Write(Current.Data + " ");
                            Current = Current.Right;
                        }
                    }
                }
            }
        }


        // ********************************* NODE STUFF *****************************************

        public class BSTNode
        {
            int data;
            BSTNode left;
            BSTNode right;

            public BSTNode(int stuff)
            {
                data = stuff;
                left = null;
                right = null;
            }

            public BSTNode Left
            {
                get { return left; }
                set { left = value; }
            }

            public BSTNode Right
            {
                get { return right; }
                set { right = value; }
            }

            public int Data
            {
                get { return data; }
                set { data = value; }
            }
        }
    }
}
