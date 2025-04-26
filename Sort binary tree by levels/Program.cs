// https://www.codewars.com/kata/52bef5e3588c56132c0003bc/csharp

namespace Sort_binary_tree_by_levels
{
    public class Kata
    {
        public static void Main()
        {

        }

        public static List<int> TreeByLevels(Node? node)
        {
            if (node == null)
            {
                return new List<int>();
            }

            List<int> values = new List<int>();

            /*
             * put all nodes of a level into a list
             * collect the list's nodes' values
             * discard the list and put all child nodes to it instead
             * repeat
             *
             * end if list is empty - no more children were added
             */

            List<Node> level = new List<Node>
            {
                node
            };

            for (; ; )
            {
                if (level.Count == 0)
                {
                    break;
                }

                values.AddRange(level.Select(n => n.Value));

                List<Node> temp = new List<Node>();
                foreach (Node n in level)
                {
                    Node? left = n.Left;
                    if (left != null)
                    {
                        temp.Add(left);
                    }

                    Node? right = n.Right;
                    if (right != null)
                    {
                        temp.Add(right);
                    }

                }
                level.Clear();
                level.AddRange(temp);
            }

            return values;
        }
    }

    public class Node
    {
        public Node? Left;
        public Node? Right;
        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }

}
