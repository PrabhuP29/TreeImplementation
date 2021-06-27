using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildBinaryTree();
            BuildBinarySearchTree();
        }

        static void BuildBinaryTree()
        {
            var root = Tree.BuildBinaryTree(1);
            Tree.BuildBinaryTree(2, root);
            Tree.BuildBinaryTree(3, root);
            Tree.BuildBinaryTree(4, root);
            Tree.BuildBinaryTree(5, root);
            Tree.BuildBinaryTree(6, root);
            Tree.BuildBinaryTree(7, root);
            Tree.BuildBinaryTree(8, root);

            var InOrderResult = new List<int>();
            Tree.InorderTraversal(root, InOrderResult);
            Console.WriteLine("Inorder Traversal - " + string.Join(" ", InOrderResult));
            var PreOrderResult = new List<int>();
            Tree.PreorderTraversal(root, PreOrderResult);
            Console.WriteLine("Preorder Traversal - " + string.Join(" ", PreOrderResult));
            var PostOrderResult = new List<int>();
            Tree.PostorderTraversal(root, PostOrderResult);
            Console.WriteLine("Postorder Traversal - " + string.Join(" ", PostOrderResult));
            var BFSResult = new List<int>();
            Tree.BFSTraversal(root, BFSResult);
            Console.WriteLine("BFS Traversal - " + string.Join(" ", BFSResult));

            Tree.BuildTreeFromList(InOrderResult, PreOrderResult);

            Console.ReadLine();
        }

        static void BuildBinarySearchTree()
        {
            var root = Tree.BuildBinarySearchTree(20);
            Tree.BuildBinaryTree(18, root);
            Tree.BuildBinaryTree(30, root);
            Tree.BuildBinaryTree(12, root);
            Tree.BuildBinaryTree(19, root);
            Tree.BuildBinaryTree(25, root);
            Tree.BuildBinaryTree(32, root);

            var InOrderResult = new List<int>();
            Tree.InorderTraversal(root, InOrderResult);
            Console.WriteLine("Inorder Traversal - " + string.Join(" ", InOrderResult));
            var PreOrderResult = new List<int>();
            Tree.PreorderTraversal(root, PreOrderResult);
            Console.WriteLine("Preorder Traversal - " + string.Join(" ", PreOrderResult));
            var PostOrderResult = new List<int>();
            Tree.PostorderTraversal(root, PostOrderResult);
            Console.WriteLine("Postorder Traversal - " + string.Join(" ", PostOrderResult));
            var BFSResult = new List<int>();
            Tree.BFSTraversal(root, BFSResult);
            Console.WriteLine("BFS Traversal - " + string.Join(" ", BFSResult));

            Tree.BuildTreeFromList(InOrderResult, PreOrderResult);

            Tree.deleteKey(root, 18);

            InOrderResult = new List<int>();
            Tree.InorderTraversal(root, InOrderResult);
            Console.WriteLine("Inorder Traversal after delete 18 - " + string.Join(" ", InOrderResult));

            

            Console.ReadLine();

        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Counter { get; set; }

        public Node(int data, Node left = null, Node right = null)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
            this.Counter += 1;
        }
    }

    public class Tree
    {
        public static Node BuildBinaryTree(int data, Node root = null)
        {
            return InsertBT(data, root);
        }

        public static Node BuildBinarySearchTree(int data, Node root = null)
        {
            return InsertBST(data, root);
        }

        public static void InorderTraversal(Node root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            InorderTraversal(root.Left, result);
            result.Add(root.Data);
            InorderTraversal(root.Right, result);

            //return result;
        }

        public static void PreorderTraversal(Node root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            result.Add(root.Data);
            PreorderTraversal(root.Left, result);
            PreorderTraversal(root.Right, result);

            //return result;
        }

        public static void PostorderTraversal(Node root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            PostorderTraversal(root.Left, result);
            PostorderTraversal(root.Right, result);
            result.Add(root.Data);
            //return result;
        }

        public static void BFSTraversal(Node root, List<int> result)
        {
            Queue<Node> inline = new Queue<Node>();
            inline.Enqueue(root);

            while (inline.Count > 0)
            {
                Node temp = inline.Dequeue();
                result.Add(temp.Data);
                if (temp.Left != null)
                    inline.Enqueue(temp.Left);
                if (temp.Right != null)
                    inline.Enqueue(temp.Right);
            }
        }

        private static Node InsertBT(int data, Node root = null)
        {
            if (root == null)
            {
                return new Node(data);
            }

            Queue<Node> inline = new Queue<Node>();
            inline.Enqueue(root);

            while (inline.Count() > 0)
            {
                Node temp = inline.Dequeue();

                if (temp.Left == null)
                {
                    temp.Left = new Node(data);
                    break;
                }
                else
                {
                    inline.Enqueue(temp.Left);
                }

                if (temp.Right == null)
                {
                    temp.Right = new Node(data);
                    break;
                }
                else
                {
                    inline.Enqueue(temp.Right);
                }

            }

            return root;
        }

        private static Node InsertBST(int data, Node root = null)
        {
            if (root == null)
            {
                return new Node(data);
            }
            var current = root;
            while (true)
            {
                if (data == current.Data)
                {
                    current.Counter++;
                    break;
                }
                if (data < current.Data)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(data);
                        break;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                else if (data > current.Data)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(data);
                        break;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }

            return root;
        }
        public static void deleteKey(Node root, int key) { root = deleteRec(root, key); }
        static Node deleteRec(Node root, int key)
        {
            /* Base Case: If the tree is empty */
            if (root == null)
                return root;

            /* Otherwise, recur down the tree */
            if (key < root.Data)
                root.Left = deleteRec(root.Left, key);
            else if (key > root.Data)
                root.Right = deleteRec(root.Right, key);

            // if key is same as root's key, then This is the
            // node to be deleted
            else
            {
                // node with only one child or no child
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // node with two children: Get the
                // inorder successor (smallest
                // in the right subtree)
                root.Data = minValue(root.Right);

                // Delete the inorder successor
                root.Right = deleteRec(root.Right, root.Data);
            }
            return root;
        }

        static int minValue(Node root)
        {
            int minv = root.Data;
            while (root.Left != null)
            {
                minv = root.Left.Data;
                root = root.Left;
            }
            return minv;
        }

        public static Node BuildTreeFromList(List<int> inorder, List<int> preorder)
        {
            if(preorder == null || preorder.Count == 0)
            {
                return null;
            }

            if (inorder == null || inorder.Count == 0)
            {
                return null;
            }

            if(inorder.Count != preorder.Count)
            {
                return null;
            }
            Node root = new Node(preorder[0]);
            int rootIndex = inorder.IndexOf(root.Data);
            BuildTreeHelper(inorder.GetRange(0, rootIndex), preorder.GetRange(1, rootIndex), root, true);
            BuildTreeHelper(inorder.GetRange(rootIndex+1, inorder.Count-rootIndex-1), preorder.GetRange(rootIndex+1, preorder.Count - rootIndex - 1), root);
            return root;
        }

        static void BuildTreeHelper(List<int> inorder, List<int> preorder, Node node, bool isleft = false)
        {
            if (preorder == null || preorder.Count == 0)
            {
                return ;
            }

            if (inorder == null || inorder.Count == 0)
            {
                return ;
            }

            if (isleft)
            {
                node.Left = new Node(preorder[0]);
                node = node.Left;
            }
            else
            {
                node.Right = new Node(preorder[0]);
                node = node.Right;
            }

            if(inorder.Count == 1)
            {
                return;
            }
            int rootIndex = inorder.IndexOf(node.Data);
            BuildTreeHelper(inorder.GetRange(0, rootIndex), preorder.GetRange(1, rootIndex), node, true);
            BuildTreeHelper(inorder.GetRange(rootIndex + 1, inorder.Count - rootIndex - 1), preorder.GetRange(rootIndex + 1, preorder.Count - rootIndex - 1), node);
        }
       
    }
}
