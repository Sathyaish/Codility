using System;

namespace L7.StacksAndQueues.RM.QWithCyclicBuffer
{
    public class CyclicBuffer<T>
    {
        private T[] _storage;

        private int _tail;
        private int _head;

        private int _capacity;

        private const int TAIL_INITIAL_STARTING_INDEX = 0;
        private const int HEAD_INITIAL_STARTING_INDEX = -1;
        private const int DEFAULT_CAPACITY = 100;

        public CyclicBuffer(int capacity = DEFAULT_CAPACITY)
        {
            _capacity = capacity;

            _storage = new T[_capacity];

            _head = HEAD_INITIAL_STARTING_INDEX;
            _tail = TAIL_INITIAL_STARTING_INDEX;
        }

        // Or push
        public void Enqueue(T item)
        {
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

            var value = _storage[_head];
            _head = ((_head + 1 + _capacity) % _capacity);

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