using System;
using System.Collections.Generic;
using System.Text;

namespace QueueTest.Collections
{
    public class QueueNode<T>
    {
        public QueueNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public QueueNode<T> Next { get; set; }
    }
}
