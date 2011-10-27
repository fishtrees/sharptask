using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SharpTask.Core
{
    internal class MessageQueue
    {
        public const string DefaultQueueName = "default";

        private Hashtable _Queues;
        private Queue _DefaultQueue = new Queue();


        public MessageQueue()
        {
            this._Queues = new Hashtable();
            this._Queues.Add(DefaultQueueName, this._DefaultQueue);
        }
        public void AddQueue(string name)
        {
            this.AddQueue(name, 0);
        }
        internal Queue AddQueue(string name, int capacity)
        {
            Queue aQueue = null;
            if (!this._Queues.ContainsKey(name))
            {
                lock (this._Queues.SyncRoot)
                {
                    if (!this._Queues.ContainsKey(name))
                    {
                        if (capacity > 0)
                        {
                            aQueue = new Queue(capacity);
                        }
                        else
                        {
                            aQueue = new Queue();
                        }
                        this._Queues.Add(name, aQueue);
                        return aQueue;
                    }
                }
            }
            return this._Queues[name] as Queue;
        }

        public void Put(string queueName, object data)
        {
            Queue theQueue = null;
            if (!this._Queues.ContainsKey(queueName))
            {
                theQueue = this.AddQueue(queueName, 0);
            }
            else
            {
                theQueue = this._Queues[queueName] as Queue;
            }
            lock (theQueue.SyncRoot)
            {
                theQueue.Enqueue(data);
            }
        }

        public object Get(string queueName)
        {
            if (!this._Queues.ContainsKey(queueName))
            {
                throw new System.ArgumentException("The argument `queueName` is not exists");
            }
            Queue theQueue = this._Queues[queueName] as Queue;
            lock (theQueue.SyncRoot)
            {
                return theQueue.Dequeue();
            }
        }

        public object Peek(string queueName)
        {
            if (!this._Queues.ContainsKey(queueName))
            {
                throw new System.ArgumentException("The argument `queueName` is not exists");
            }
            Queue theQueue = this._Queues[queueName] as Queue;
            lock (theQueue.SyncRoot)
            {
                return theQueue.Peek();
            }
        }
    }
}
