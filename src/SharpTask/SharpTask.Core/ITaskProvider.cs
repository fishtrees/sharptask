using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTask.Core
{
    public interface ITaskProvider<T>
    {
        ITask CreateTask(T originalData);
    }
}
