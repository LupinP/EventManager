namespace LP.EventManager.Events.Handler
{
    using System;
    
    public static class ObjectArgsHandler
    {
        private static ObjectArgsEvent events = null;

        public static Dispose.Container.DisposeContainer Add(string key, Action<object[]> action)
        {
            if (events == null)
            {
                events = new ObjectArgsEvent();
            }
            events.Add(key, action);

            return new Dispose.Container.DisposeContainer(() =>Remove(key, action));
        }

        public static void Remove(string key, Action<object[]> action)
        {
            if (events != null)
            {
                events.Remove(key, action);
            }
        }

        public static void Invoke(string key, params object[] arg)
        {
            if (events != null)
            {
                events.Invoke(key);
            }
        }
    }
}