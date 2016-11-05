using System.Collections.Generic;
using Panels;
using log4net;

namespace Stocks
{
    public abstract class Subject
    {
        private readonly object myLock;
        private readonly List<Observer> observers;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Subject));

        public List<Observer> Observers { get { return observers; } }

        protected void NotifyObservers()
        {
            lock (myLock)
            {
                logger.Debug("NotifyingObservers....");
                foreach (Observer observer in observers)
                {
                    observer.update(Clone());
                    logger.Debug("Successfully notified Observer.");
                }
            }
        }

        public Subject()
        {
            myLock = new object();
            observers = new List<Observer>();
        }

        public void Subscribe(Observer observer)
        {
            lock (myLock)
            {
                if (observer != null && !observers.Contains(observer))
                {
                    observers.Add(observer);
                    logger.Debug("Successfully subscribed observer.");
                }
            }
        }

        public void Unsubscribe(Observer observer)
        {
            lock (myLock)
            {
                if (observers.Contains(observer))
                {
                    observers.Remove(observer);
                    logger.Debug("Successfully unsubscribed observer.");
                }
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
