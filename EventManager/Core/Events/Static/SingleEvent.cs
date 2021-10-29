namespace LP.EventManager.Events
{
    using System;
    using System.Collections.Generic;
    
    public class SingleEvent : Base.EventBase
    {
        private Dictionary<string, List<Action>> events = new Dictionary<string, List<Action>>();

        public void Add(string key, Action action)
        {
            if (!events.ContainsKey(key))
            {
                events.Add(key, new List<Action>());
            }

            events[key].Add(action);
        }
        public void Remove(string key, Action action)
        {
            if (events.TryGetValue(key, out var list))
            {
                list.Remove(action);
            }
        }

        public void Invoke(string key)
        {
            if (events.TryGetValue(key, out var lastInvokeList))
            {
                for (int i = 0; i < lastInvokeList.Count; i++)
                {
                    lastInvokeList[i]?.Invoke();
                }
            }
        }

    }
}