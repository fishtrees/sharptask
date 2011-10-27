using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTask.Core
{
    public interface IMessageClient
    {
        event EventHandler MessageArrived;

        void Watch(string queueName);
        void Put(string queueName, ITask aTask);
        ITask Get(string queueName);
        ITask Peek(string queueName);
        void Delete(string queueName, int id);
    }
}
