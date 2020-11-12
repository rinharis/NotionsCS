using System;
using System.Linq;

namespace Generique_Tp_ListeChainee
{
    public class Linked<T>
    {
        public Linked<T> Next { get; set; }
        public Linked<T> Previous { get; set; }
        public T Value { get; set; }
    }

    public class MyLinkedList<T>
    {
        public Linked<T> First { get; private set; }
        
        public Linked<T> Last
        {
            get
            {
                if (First == null)
                    return null;
                Linked<T> last = First;
                while (last.Next != null)
                    last = last.Next;
                return last;
            }
        }

        public void Add(T element)
        {
            if (First == null)
                First = new Linked<T> { Value = element };
            else
            {
                Linked<T> last = Last;
                last.Next = new Linked<T> { Value = element, Previous = last };
            }
        }

        public Linked<T> GetLink(int index)
        {
            Linked<T> temp = First;
            int it = 1;
            while(temp != null && it <= index)
            {
                temp = temp.Next;
                it++;
            }
            return temp;
        }

        public void Insert(T element, int index)
        {
             if(index == 0)
            {
                if (First == null)
                    First = new Linked<T> { Value = element };
                else
                {
                    Linked<T> temp = First;
                    First = new Linked<T> { Value = element, Next = temp };
                    temp.Previous = First;
                }
            }
             else
            {
                Linked<T> elementIndex = GetLink(index);
                if (elementIndex == null)
                    Add(element);
                else
                {
                    Linked<T> previous = elementIndex.Previous;
                    Linked<T> temp = previous.Next;
                    previous.Next = new Linked<T> { Value = element, Previous = previous, Next = temp };
                    temp.Previous = previous.Next;
                }
            }
        }

        public void Delete(int index)
        {
            //get element at wanted index
            Linked<T> temp = GetLink(index);
            
            //if element is out of bounds, do nothing
            if (temp == null)
            {
                Console.WriteLine("Nothing to delete at index " + index + ".");
                return;
            }
            else
                Console.WriteLine("Deleting value {0} at index {1}...", temp.Value, index);
            
            Linked<T> previous = temp.Previous;
            Linked<T> next = temp.Next;

            //if element is at first index
            if (previous == null)
            {
                //if list has a single element
                if(next == null)
                    First = null;
                else
                {
                    next.Previous = null;
                    First = next;
                }
            }
            //if element is at last index
            else if (previous != null && next == null)
                previous.Next = null;
            //if element is at intermediate index (previous != null && next != null)
            else
            {
                previous.Next = next;
                next.Previous = previous;
            }
        }

        public MyLinkedList<T> Clear()
        {
            Console.WriteLine("Clearing " + this.GetType().Name);
            return new MyLinkedList<T>();
        }

    }

    

}