using System;

namespace SeedFullBinaryTree
{

    public class BinaryTreeNode<T>
    {

        T Value { get; }
        BinaryTreeNode<T> LeftNode { get; set; }
        BinaryTreeNode<T> RightNode { get; set; }

        public BinaryTreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value cannot be null.");
            }

            Value = value;
        }

        public static BinaryTreeNode<T> SeedFullBinaryTree(T[] range, int depth)
        {
            //Validation
            ValidateSeedData(range, depth);

            //Set root node
            var root = new BinaryTreeNode<T>(RandomValue(range));
            
            if(0 < depth)
            {
                root.LeftNode = SeedFullBinaryTree(range, depth - 1);
                root.RightNode = SeedFullBinaryTree(range, depth - 1);
            }

            return root;
        }

        //not "really" random, good enough for my project!
        private static T RandomValue(T[] range) => range[DateTime.Now.Ticks % range.Length]; 


        private static void ValidateSeedData(T[] range, int depth)
        {
            if (range == null)
            {
                throw new ArgumentNullException("range cannot be null.");
            }
            if (range.Length == 0)
            {
                throw new ArgumentException("range must be an array with of at least one element.");
            }
            if (depth < 0)
            {
                throw new ArgumentOutOfRangeException("depth must be 0 or greater.");
            }
        }


    }



    public class Program
    {
        static void Main(string[] args)
        {
            //This is the sum of my lazy Saturday's fun coding.
            int[] range = { 4, 5, 6, 8, 23 };
            var tree = BinaryTreeNode<int>.SeedFullBinaryTree(range, 5);
        }
    }
}
