using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Task
{
    class SmartStack<T> : IEnumerable<T>
    {
        private T[] _smartStack;
        public int Capacity
        {
            get
            {
                return _smartStack.Length;
            }
        }
        public int Count
        {
            get
            {
                return _top;
            }
        }

        private int _top;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index violation");
                return _smartStack[Count - index - 1];
            }
        }
        public SmartStack()
        {
            _smartStack = new T[4];
            _top = 0;
        }
        public SmartStack(int capacity)
        {
            _smartStack = new T[capacity];
            _top = 0;
        }
        public SmartStack(IEnumerable<T> collection) : this()
        {
            PushRange(collection);
        }

        public void Push(T value)
        {
            if (_top >= Capacity)
            {
                ResizeStack(Capacity * 2);
            }
            _smartStack[_top] = value;
            _top++;
        }
        public void PushRange(IEnumerable<T> collection)
        {
            int collectionSize = 0;
            foreach (T item in collection)
                collectionSize++;
            if ((Capacity - Count) < collectionSize)
            {
                ResizeStack(Count + collectionSize);
            }
            foreach (T item in collection)
            {
                Push(item);
            }
        }
        public T Pop()
        {
            if (_top == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            T topElement = _smartStack[_top - 1];
            _smartStack[_top - 1] = default;
            _top--;
            return topElement;
        }
        public T Peek()
        {
            if (_top == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            T topElement = _smartStack[_top - 1];
            return topElement;

        }
        public bool Contains(T element)
        {
            foreach (T item in this)
            {
                if (EqualityComparer<T>.Default.Equals(item, element))
                    return true;
            }
            return false;
        }
        private void ResizeStack(int size)
        {
            T[] resizedStack = new T[size];
            for (int i = 0; i < Count; i++)
            {
                resizedStack[i] = _smartStack[i];
            }
            _smartStack = resizedStack;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _top - 1; i >= 0; i--)
            {
                yield return _smartStack[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
