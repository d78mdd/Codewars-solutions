// https://www.codewars.com/kata/5672682212c8ecf83e000050/train/csharp

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


            SortedSet<int> u = new SortedSet<int>();
            u.Add(1);

            Node root = new Node(null, null, 1);

            List<Node> level = new List<Node>();
            level.Add(root);

            bool reached = false;

            // add numbers in u
            for (; u.Count <= n;)
            {
                foreach (Node node in level)
                {
                    int y = 2 * node.Value + 1;

                    Node left = new Node(null, null, y);
                    node.Left = left;

                    u.Add(y);
                    

                    if (u.Count == n + 1) // n - 0-based index
                    {
                        reached = true;
                        break;
                    }


                    int z = 3 * node.Value + 1;

                    Node right = new Node(null, null, z);
                    node.Right = right;

                    u.Add(z);

                    if (u.Count == n + 1)
                    {
                        reached = true;
                        break;
                    }
                }

                if (reached)
                {
                    break;
                }

                List<Node> temp = new List<Node>(level);
                level.Clear();
                level.AddRange(temp.Select(node => node.Left));
                level.AddRange(temp.Select(node => node.Right));
            }

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
