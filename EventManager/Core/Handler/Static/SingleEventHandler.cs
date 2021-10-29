namespace LP.EventManager.Events.Handler
{
    using System;

    public static class SingleEventHandler
    {
        private static SingleEvent singleEvents = null;

        public static Dispose.Container.DisposeContainer Add(string key, Action action)
        {
            if (singleEvents == null)
            {
                singleEvents = new SingleEvent();
            }
            singleEvents.Add(key, action);

            return new Dispose.Container.DisposeContainer(() => Remove(key, action));
        }

        public static void Remove(string key, Action action)
        {
            if (singleEvents != null)
            {
                singleEvents.Remove(key, action);
            }
        }

        public static void Invoke(string key)
        {
            if (singleEvents != null)
            {
                singleEvents.Invoke(key);
            }
        }
    }
}

