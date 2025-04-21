// https://www.codewars.com/kata/5672682212c8ecf83e000050/train/csharp

namespace Twice_linear
{
    public class MainClass
    {
        public static void Main()
        {
            Console.WriteLine(DoubleLinear.DblLinear(50));
        }
    }

    
    public class DoubleLinear
    {
        public static SortedSet<int> u = new SortedSet<int>();

        public static int DblLinear(int n)
        {
            if (u.Count == 0)
            {
                DblLinearinternal();
            }

            // get the n-th element from u
            int result = u.ElementAt(n);

            return result;
        }

        public static void DblLinearinternal()
        {
            int maxSize = 400000;


            u.Add(1);

            Node root = new Node(null, null, 1);

            List<Node> level = new List<Node>();
            level.Add(root);

            // add numbers in u
            for (; u.Count <= maxSize;)
            {
                foreach (Node node in level)
                {
                    int y = 2 * node.Value + 1;

                    Node left = new Node(null, null, y);
                    node.Left = left;

                    u.Add(y);


                    int z = 3 * node.Value + 1;

                    Node right = new Node(null, null, z);
                    node.Right = right;

                    u.Add(z);
                }

                List<Node> temp = new List<Node>(level);
                level.Clear();
                level.AddRange(temp.Select(node => node.Left));
                level.AddRange(temp.Select(node => node.Right));
            }

        }
    }

    public class Node
    {
        public Node Left;
        public Node Right;
        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }

}
