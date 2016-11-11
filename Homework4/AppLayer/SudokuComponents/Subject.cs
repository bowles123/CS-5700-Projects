using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public abstract class Subject
    {
        private readonly object myLock;
        private readonly List<Observer> observers;

        public List<Observer> Observers { get { return observers; } }

        public Subject()
        {
            myLock = new object();
            observers = new List<Observer>();
        }

        protected void NotifyObservers()
        {
            lock (myLock)
            {
                foreach (Observer observer in observers)
                {
                    observer.Update(Clone());
                }
            }
        }

        public void Subscribe(Observer observer)
        {
            lock (myLock)
            {
                if (observer != null && !observers.Contains(observer))
                {
                    observers.Add(observer);
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
                }
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
