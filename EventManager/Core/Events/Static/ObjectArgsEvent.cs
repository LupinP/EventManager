namespace LP.EventManager.Events
{
    using System;
    using System.Collections.Generic;
    
    public class ObjectArgsEvent : Base.EventBase
    {
        private Dictionary<string, List<Action<object[]>>> actions = new Dictionary<string, List<Action<object[]>>>();
        
        
        public void Add(string key, Action<object[]> action)
        {
            if (!actions.ContainsKey(key))
            {
                actions.Add(key, new List<Action<object[]>>());
            }
            actions[key].Add(action);
        }

        public void Remove(string key, Action<object[]> action)
        {
            if (actions.TryGetValue(key, out var val))
            {
                val.Remove(action);
            }
        }
        public void Invoke(string key, params object[] prms)
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
