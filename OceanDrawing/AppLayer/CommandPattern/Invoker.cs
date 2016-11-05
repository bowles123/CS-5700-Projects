using AppLayer.CommandPattern.Commands;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;

namespace AppLayer.CommandPattern
{
    public class Invoker
    {
        private readonly ConcurrentQueue<Command> queue;
        private Stack<Command> history = new Stack<Command>();
        private readonly AutoResetEvent enqueueOccurred = new AutoResetEvent(false);
        private Thread thread;
        private bool listening;
        private static Invoker uniqueInstance = new Invoker();

        public Stack<Command> History { get { return history; } }

        private Invoker()
        {
            queue = new ConcurrentQueue<Command>();
        }

        public static Invoker getUniqueInstance()
        {
            return uniqueInstance;
        }

        public void ResetHistory()
        {
            history = new Stack<Command>();
        }

        public void Enqueue(Command command)
        {
            if (command != null)
            {
                queue.Enqueue(command);
                enqueueOccurred.Set();
            }
        }

        public void Start()
        {
            listening = true;
            thread = new Thread(Listening);
            thread.Start();
        }

        public void Undo()
        {
            history?.Pop()?.Undo();
        }

        public void Stop()
        {
            listening = false;
        }

        private void Listening()
        {
            while(listening)
            {
                Command command;
                queue.TryDequeue(out command);

                if (command != null)
                {
                    command.Execute();
                    history.Push(command);
                }
                else
                {
                    enqueueOccurred.WaitOne(100);
                }
            }
        }
    }
}
