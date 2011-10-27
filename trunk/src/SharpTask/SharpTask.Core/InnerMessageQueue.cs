using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTask.Core
{
    public class InnerMessageQueue : IMessageClient
    {
        private MessageQueue _MQ = new MessageQueue();

        public event EventHandler MessageArrived;

        public void Watch(string queueName)
        {
            throw new NotSupportedException();
        }

        public void Put(string queueName, ITask aTask)
        {
            this._MQ.Put(queueName, aTask);
        }

        public ITask Get(string queueName)
        {
            return this._MQ.Get(queueName) as ITask;
        }

        public ITask Peek(string queueName)
        {
            return this._MQ.Peek(queueName) as ITask;
        }

        public void Delete(string queueName, int id)
        {
            throw new System.NotSupportedException();
        }
    }
}
