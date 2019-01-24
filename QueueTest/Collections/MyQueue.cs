using QueueTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueTest.Collections
{
    public class MyQueue<T> : IEnumerable<T>
    {
        protected QueueNode<T> First;
        protected QueueNode<T> Last;
        protected int Count;

        /// <summary>
        /// удаляет и возвращает первый элемент в очереди
        /// </summary>
        public T dequeue()
        {
            if (isEmpty())
                throw new Exception("Очередь не содержит столько элементов");
            T _data;

            _data = First.Data;
            First = First.Next;
            Count--;
            return _data;

        }

        /// <summary>
        /// добавляет последний элемент в очередь
        /// </summary>
        /// <param name="data"></param>
        public void enqueue(T data)
        {
            if (isEmpty())
            {
                First = new QueueNode<T>(data);
                Last = First;
                Count++;
            }
            else
            {
                QueueNode<T> _data = new QueueNode<T>(data);
                Last.Next = _data;
                Last = _data;
                Count++;
            }
        }

        /// <summary>
        /// возвращает true если очередь пуста
        /// </summary>
        public bool isEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// возвращает количество элементов в очереди
        /// </summary>
        public int size()
        {
            return Count;
        }
        
        /// <summary>
        /// сортирует элементы по возрастанию ID
        /// </summary>
        public void sortByID()
        {
            if (!(First.Data is Person))
                throw new NotImplementedException(string.Format("Метод не реализован для {0}", First.Data.GetType()));

            if (isEmpty())
                throw new Exception("Очередь пуста");

            bool _replacementExist = true;
            while (_replacementExist)
            {
                int _replacementCount = 0;
                var current = First as QueueNode<Person>;
                while (current.Next != null)
                {
                    if (current.Data.Id > current.Next.Data.Id)
                    {
                        var _d = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = _d;
                        _replacementCount++;
                    }
                    current = current.Next;


                }
                if (_replacementCount == 0)
                    _replacementExist = false;


            }
        }

        /// <summary>
        /// сортирует элементы по возрастанию PhoneNumber
        /// </summary>
        public void sortByPhoneNumber()
        {
            if (!(First.Data is Person))
                throw new NotImplementedException(string.Format("Метод не реализован для {0}", First.Data.GetType()));

            if (isEmpty())
                throw new Exception("Очередь пуста");

            bool _replacementExist = true;
            while (_replacementExist)
            {
                int _replacementCount = 0;
                var current = First as QueueNode<Person>;
                while (current.Next != null)
                {
                    if (int.Parse(current.Data.PhoneNumber) > int.Parse(current.Next.Data.PhoneNumber))
                    {
                        var _d = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = _d;
                        _replacementCount++;
                    }
                    current = current.Next;
                    

                }
                if (_replacementCount == 0)
                   _replacementExist = false;
                

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            QueueNode<T> current = First;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }    
}
