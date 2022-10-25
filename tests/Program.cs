namespace tests
{
    public class Program
    {
        public static void Main()
        {
            var list = new Node(new byte[] { 1 }
                    , new Node(new byte[] { 2 }
                        , new Node(new byte[] { 3 }
                            , new Node(new byte[] { 4 }
                                , new Node(new byte[] { 5 }, null))))
                );
            Print(list);
            Print(Reverse(list));
        }

        public static void Print(Node? current)
        {
            while (null != current)
            {
                var data = current.Data ?? new byte[0];
                Console.Write($"[{string.Join(',', data)}]"); // не сильно хорошо конечно джойнить, лучше бы поштуно выводить в консоль
                current = current.Next;
            }
            Console.WriteLine();
        }

        public static Node? Reverse(Node? head)
        {
            if (null != head)
            {
                Node? previous = null;
                Node? current = head;
                Node? next = null;

                while (current.Next != null)
                {
                    next = current.Next;
                    current.Next = previous;
                    previous = current;
                    current = next;
                }
                current.Next = previous;
                head = current;
            }
            return head;
        }

        public class Node
        {
            public byte[]? Data { get; set; }
            public Node? Next { get; set; }
            public Node(byte[]? data, Node? next)
            {
                Data = data;
                Next = next;
            }
        }
    }
}
