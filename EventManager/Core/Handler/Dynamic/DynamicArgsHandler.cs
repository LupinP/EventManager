namespace LP.EventManager.Events.Handler
{
    using System;

    public static class DynamicArgsHandler
    {
        private static DynamicArgsEvent events = null;

        public static Dispose.Container.DisposeContainer Add(string key, Action<dynamic[]> action)
        {
            if (events == null)
            {
                events = new DynamicArgsEvent();
            }
            events .Add(key,action);

            return new Dispose.Container.DisposeContainer(()=>Remove(key,action));
        }

        public static void Remove(string key, Action<dynamic[]> action)
        {
            if (events != null)
            {
                events.Remove(key,action);
            }
        }

        public static void Invoke(string key, params dynamic[] value)
        {
            if (events != null)
            {
                events.Invoke(key,value);
            }
        } 
    }
}