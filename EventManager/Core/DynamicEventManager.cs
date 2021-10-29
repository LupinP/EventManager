namespace LP.EventManager
{
    using System;
    
    public static class DynamicEventManager
    {
        #region Add event

        /// <summary>
        /// subscribe event
        /// dynamic argument
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="action">event action</param>
        /// <returns>return dispose container</returns>
        public static Events.Dispose.Container.DisposeContainer Add(string key, Action<dynamic> action) => Events.Handler.DynamicArgHandler.Add(key, action);
        /// <summary>
        /// subscribe event
        /// take an unspecified amount dynamic arguments
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="action">event action</param>
        /// <returns>return dispose container</returns>
        public static Events.Dispose.Container.DisposeContainer Add(string key, Action<dynamic[]> action) => Events.Handler.DynamicArgsHandler.Add(key, action);
       
        #endregion

        #region Remove event
        
        /// <summary>
        /// remove dynamic event
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="action">event action</param>
        public static void Remove(string key, Action<dynamic> action) => Events.Handler.DynamicArgHandler.Remove(key, action);
        /// <summary>
        /// remove unspecified amount dynamics event
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="action">event action</param>
        public static void Remove(string key, Action<dynamic[]> action) => Events.Handler.DynamicArgsHandler.Remove(key, action);
        
        #endregion
        
        #region Invoke event
        
        /// <summary>
        /// invoke dynamic events
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="value">dynamic argument</param>
        public static void Invoke(string key, dynamic value) => Events.Handler.DynamicArgHandler.Invoke(key, value);
        /// <summary>
        /// invoke unspecified amount dynamics event
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="value">dynamic arguments</param>
        public static void Invoke(string key, params dynamic[] value) => Events.Handler.DynamicArgsHandler.Invoke(key, value);
        
        #endregion
    }
}