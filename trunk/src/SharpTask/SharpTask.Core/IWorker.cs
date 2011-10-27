using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTask.Core
{
    public interface IWorker
    {
        void Run(ITask aTask);
    }
}
