﻿using System;

namespace Generique_Tp_ListeChainee
{
    public class TestMyLinkedList
    {
        public void Start()
        {
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            myLinkedList.Add(5);
            myLinkedList.Add(10);
            myLinkedList.Add(4);
            ShowListFromFirst(myLinkedList);
            ShowListFromIndex(myLinkedList, new int[] { 5, 10, 4 });
            myLinkedList.Insert(99, 0);
            myLinkedList.Insert(33, 1);
            myLinkedList.Insert(30, 1);
            ShowListFromFirst(myLinkedList);
        }

        private void ShowListFromFirst(MyLinkedList<int> list)
        {
            Console.Write("My linked list's content from first element : ");
            Linked<int> first = list.First;
            if (first == null)
                Console.Write("Empty list !");
            else
            {
                Console.Write("{0} ", first.Value);
                Linked<int> next = first.Next;
                while (next != null)
                {
                    Console.Write("{0} ", next.Value);
                    next = next.Next;
                }
            }
            Console.WriteLine();
        }

        private void ShowListFromIndex(MyLinkedList<int> list, int[] indexes)
        {
            Console.Write("My linked list's content from index : ");
            for(int i = 0; i < indexes.Length; i++)
                Console.Write("{0} ", list.GetLink(i).Value);
            Console.WriteLine();
        }


    }
}