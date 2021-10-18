using System;

namespace DataStructuresWithLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implement LRU Cache 
            LRUCache lc = new LRUCache();
            Console.WriteLine("This is given LRU Cache");

            lc.set(1, 235);
            lc.set(2, 896);
            lc.set(3, 529);
            lc.set(2, 95);
            lc.PrintCache();
         }
    }

    public class Node
    {
        public int data;
        public Node next;
    }

    public class KeyValueNode
    {
        public int key;
        public int value;
        public KeyValueNode next;
    }
    public class LinkedList
    {
        Node head;
        Node tail;
        int size;

        public LinkedList()
        {
            head = new Node();
            head.next = null;
            size = 1;
        }

    }

    // The task is to design and implement methods of an LRU cache. The
    // class has two methods get and set which are defined as follows.
    // get(x)   : Gets the value of the key x if the key exists in the
    // cache otherwise returns -1
    // set(x, y) : inserts the value if the key x is not already present.
    // If the cache reaches its capacity it should invalidate the least
    // recently used item before inserting the new item. In the constructor
    // of the class the size of the cache should be initialized.
    class LRUCache
    {
        private KeyValueNode head;
        private KeyValueNode tail;
        int Capacity;
        int Length;

        public LRUCache()
        {
            head = new KeyValueNode();
            
            head.next = null;
            Capacity = 3;
            Length = 0;
        }

        public void AddToFront(int x, int y)
        {
            KeyValueNode newNode = new KeyValueNode();
            newNode.key = x;
            newNode.value = y;
            newNode.next = head;
            head = newNode;
        }

        // Drop the node at head. Move all nodes and 
        public void DropLastNode()
        {
            KeyValueNode currNode = head;
            while (currNode.next.next != null)
            {
                currNode = currNode.next;
            }
            currNode.next = null;
        }

        public int get(int x)
        {
            KeyValueNode currNode = head;
            //currNode = head;
            while(currNode.next != null)
            {
                if (currNode.key == x)
                {
                    return (currNode.value);
                }
                currNode = currNode.next;
            }

            return -1;
        }

        public void set(int x, int y)
        {
            DeleteNode(x);
            if (Length == Capacity)
            {
                DropLastNode();
            }
            AddToFront(x, y);
            Length++;
        }

        public void DeleteNode(int x)
        {
            KeyValueNode currNode = head;
            //currNode = head;
            while (currNode.next != null)
            {
                if (currNode.next.key == x)
                {
                    currNode.next = currNode.next.next;
                    Length--;
                }
                currNode = currNode.next;
            }

        }

        public void PrintCache()
        {
            KeyValueNode currNode = head;
            currNode = head;

            do
            {
                Console.WriteLine($"{currNode.key} : {currNode.value}");
                currNode = currNode.next;
            }
            while (currNode.next != null);
        }

    }
}
