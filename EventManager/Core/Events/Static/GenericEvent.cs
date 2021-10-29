namespace LP.EventManager.Events
{
    using System;
    using System.Collections.Generic;

    public class GenericEvent<T> : Base.EventBase
    {
        private Dictionary<string, List<Action<T>>> events = new Dictionary<string, List<Action<T>>>();

        public void Add(string key, Action<T> action)
        {
            if (!events.ContainsKey(key))
            {
                events.Add(key, new List<Action<T>>());
            }

            events[key].Add(action);
        }

        public void Remove(string key, Action<T> action)
        {
            if (events.TryGetValue(key, out var list))
            {
                list.Remove(action);
            }
        }

        public void Invoke(string key, T value)
        {
            if (events.TryGetValue(key, out var lastInvokeList))
            {
                for (int i = 0; i < lastInvokeList.Count; i++)
                {
                    lastInvokeList[i]?.Invoke(value);
                }
            }
        }
    }
}