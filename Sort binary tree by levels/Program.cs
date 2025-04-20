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

            /*
             * use 1 or 2 lists
             * put all nodes of a level into it
             * print the list's nodes' values
             * discard the list and/or put all child nodes to a list
             * repeat
             *
             * end if list is empty - no more children were added
             */

            List<Node> level = new List<Node>();
            level.Add(node);

            for (; ; )
            {
                
            }


            return null;
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
