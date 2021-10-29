namespace LP.EventManager.Events
{
    using System;
    using System.Collections.Generic;
    
    public class DynamicArgsEvent : Base.EventBase
    {
        private Dictionary<string, List<Action<dynamic[]>>> actions = new Dictionary<string, List<Action<dynamic[]>>>();
        
        
        public void Add(string key, Action<dynamic[]> action) 
        {
            if (!actions.ContainsKey(key))
            {
                actions.Add(key, new List<Action<dynamic[]>>());
            }
            actions[key].Add(action);
        }

        public void Remove(string key, Action<dynamic[]> action)
        {
            if (actions.TryGetValue(key, out var val))
            {
                val.Remove(action);
            }
        }
        public void Invoke(string key, params dynamic[] prms)
        {
            if (actions.TryGetValue(key, out var val))
            {
                for (int i = 0; i < val.Count; i++)
                {
                    if(val[i]!=null)val[i](prms);
                }
            }
        }
    }
}

