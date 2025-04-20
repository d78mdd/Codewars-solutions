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
