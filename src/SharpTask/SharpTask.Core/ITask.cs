using System;

namespace SharpTask.Core
{
    public interface ITask
    {
        DateTime CreatedTime
        {
            get;
        }
        DateTime StartedTime
        {
            get;
        }
        DateTime CompletedTime
        {
            get;
        }
        
    }
}
