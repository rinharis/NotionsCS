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

    }



}