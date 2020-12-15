using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab09EN
{
    class CircularBuffer<T> : IBuffer<T>, IEnumerable<T>
        where T: IComparable<T>
    {
        List<T> buffer;
        int max;
        int size;

        public CircularBuffer(int size)
        {
            max = size;
            buffer = new List<T> (size);
            //Count = 0;

        }

        public uint Size { get { return (uint)buffer.Capacity; } }

        public uint Count { get { return (uint)buffer.Count; } }

        public bool Empty => 0 == Count;

        public bool Full { get { return buffer.Count == buffer.Capacity; } }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i< buffer.Count; i++)
            {
                yield return buffer[i];
            }
        }

        public T Get()
        {
            if(buffer.Count != 0)
            {
                T t = buffer[0];
                buffer.RemoveAt(0);
                return t;
            }
            else
            {
                throw new IndexOutOfRangeException("Empty buffer");
            }
            
        }

        

        public void Put(T value)
        {
           if(buffer.Count < buffer.Capacity)
            {
                buffer.Add(value);
            }
            else
            {
                throw new IndexOutOfRangeException("Full buffer");
            }
            
        }

        public void Reset()
        {
            buffer.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for(int i=0; i< buffer.Count; i++)
            {
                yield return buffer[i];
            }
        }

        public IEnumerable FilterLowerThan(T a)
        {
            foreach(T value in buffer)
            {
                if(value.CompareTo(a) < 0)
                {
                    yield return value;
                }
                
            }
        }
    }
}

