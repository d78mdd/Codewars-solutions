// https://www.codewars.com/kata/52bef5e3588c56132c0003bc/csharp

namespace Sort_binary_tree_by_levels
{
    public class Kata
    {
        public static void Main()
        {

        }

        public static List<int> TreeByLevels(Node node)
        {
            if (node == null)
            {
                return new List<int>();
            }

            List<int> values = new List<int>();

            /*
             * use 1 or 2 lists
             * put all nodes of a level into it
             * collect the list's nodes' values
             * discard the list and/or put all child nodes to a list
             * repeat
             *
             * end if list is empty - no more children were added
             */

            List<Node> level = new List<Node>();
            level.Add(node);

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
                    var left = n.Left;
                    if (left != null)
                    {
                        temp.Add(n.Left);
                    }
                    
                    var right = n.Right;
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
