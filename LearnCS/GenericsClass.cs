using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCS
{
    class GenericsClass<T>
    {
        private T[] _buffer;
        private int _end;

        public GenericsClass() : this(10)
        {

        }

        public GenericsClass(int capacity)
        {
            _buffer = new T[capacity];
            _buffer[0] = default(T);
            _end = 0;
        }
        public void WriteMethod(T inputVal)
        {
            if(_end > _buffer.Length)
            {
                Console.WriteLine("Array out of size...");
            }
            else
            {
                _buffer[_end] = inputVal;
                _end += 1;
                Console.WriteLine("Added to Array...");
            }

        }
        public T ReadMethod(int location)
        {
            if (location <= _buffer.Length && location > 0)
            {
                return _buffer[location-1];
            }
            else
            {
                Console.WriteLine("Not a valid Array index defaulting to first element");
                return _buffer[0];
            }
            
        }

        public int Position()
        {
            return _end;
        }
    }
}
