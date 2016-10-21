using System;

namespace L7.StacksAndQueues.RM.QWithCyclicBuffer
{
    // Finite storage queue
    // Based on a circular buffer / cyclic buffer
    // Please see https://codility.com/media/train/5-Stacks.pdf
    // Or https://en.wikipedia.org/wiki/Circular_buffer
    // to know what a circular buffer is
    public class Queue<T>
    {
        private T[] _storage;

        private int _tail;
        private int _head;

        private int _capacity;
        
        private const int TAIL_INITIAL_STARTING_INDEX = 0;
        private const int HEAD_INITIAL_STARTING_INDEX = -1;

        public Queue(int capacity)
        {
            _capacity = capacity;

            _storage = new T[_capacity];
            
            _head = HEAD_INITIAL_STARTING_INDEX;
            _tail = TAIL_INITIAL_STARTING_INDEX;
        }

        // Or push
        public void Enqueue(T item)
        {
            if (IsFull)
            {
                throw new OutOfMemoryException("Queue full");
            }

            _storage[_tail] = item;
            _tail = ((_tail + 1 + _capacity) % _capacity);
        }

        // Or pop
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue empty");
            }

            var wasFullBeforeDequeue = IsFull;

            var value = _storage[_head];
            _head = ((_head + 1 + _capacity) % _capacity);

            if (wasFullBeforeDequeue) _tail = TAIL_INITIAL_STARTING_INDEX;

            return value;
        }

        public void Clear()
        {
            _head = HEAD_INITIAL_STARTING_INDEX;
            _tail = TAIL_INITIAL_STARTING_INDEX;
        }

        public bool IsEmpty
        {
            get
            {
                return (_head == HEAD_INITIAL_STARTING_INDEX) ||
                    (AvailableSlots == _capacity);
            }
        }

        public bool IsFull
        {
            get
            {
                return AvailableSlots == 0;
            }
        }

        public int AvailableSlots
        {
            get
            {
                return _head == HEAD_INITIAL_STARTING_INDEX 
                    ? _capacity 
                    : (_tail - _head + _capacity) % _capacity;
            }
        }
    }
}