using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTask.Core
{
    public class WorkerTask : ITask
    {
        private bool _IsIdSetted;
        private int _Id;
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._IsIdSetted)
                {
                    return;
                }
                this._Id = value;
                this._IsIdSetted = true;
            }
        }

        public TaskResult Result { get; private set; }

        public DateTime CreatedTime { get; private set; }

        public DateTime StartedTime { get; private set; }

        public DateTime CompletedTime { get; private set; }

        public WorkerTask()
        {
            this.CreatedTime = DateTime.UtcNow;
        }

        public void Start()
        {
            this.StartedTime = DateTime.UtcNow;
        }

        public void Completed(TaskResult theResult)
        {
            this.CompletedTime = DateTime.UtcNow;
            this.Result = theResult;
        }
    }
}
