using System.Reflection.Emit;

namespace Twice_linear
{
    public class DoubleLinear
    {

        public static void Main()
        {
            Console.WriteLine(DblLinear(10));
        }

        public static int DblLinear(int n)
        {

            List<int> u = new List<int>();
            u.Add(1);

            Node root = new Node(null, null, 1);

            List<Node> level = new List<Node>();
            level.Add(root);

            // add numbers in u
            for (; u.Count <= n; )
            {
                foreach (Node node in level)
                {
                    int y = 2 * node.Value + 1;

                    Node left = new Node(null, null, y);
                    node.Left = left;

                    int z = 3 * node.Value + 1;

                    Node right = new Node(null, null, z);
                    node.Right = right;

                    u.Add(y);
                    u.Add(z);
                }

                List<Node> temp = new List<Node>(level);
                level.Clear();
                level.AddRange(temp.Select(node => node.Left));
                level.AddRange(temp.Select(node => node.Right));
            }

            // sort u
            u = u.OrderBy(i => i)
                .ToList();

            // get the n-th element from u
            int result = u.ElementAt(n);

            return result;
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
