namespace LP.EventManager.Events
{
    using System;
    using System.Collections.Generic;
    
    public class DynamicArgEvent : Base.EventBase 
    {
        private Dictionary<string, List<Action<dynamic>>> events = new Dictionary<string, List<Action<dynamic>>>();

        public void Add(string key, Action<dynamic> action)
        {
            if (!events.ContainsKey(key))
            {
                events.Add(key,new List<Action<dynamic>>());
            }
            events[key].Add(action);
        }

        public void Remove(string key, Action<dynamic> action)
        {
            if (events.TryGetValue(key, out var list))
            {
                list.Remove(action);
            }
        }

        public void Invoke(string key, dynamic value)
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