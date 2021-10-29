namespace LP.EventManager
{
    using System;
    
    public static class EventManager
    {
        #region Add events
       
        /// <summary>
        /// subscribe event
        /// single event, dont take arguments
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="action">event action</param>
        /// <returns>return dispose container</returns>
        public static Events.Dispose.Container.DisposeContainer Add(string key, Action action) => Events.Handler.SingleEventHandler.Add(key, action);
        /// <summary>
        /// subscribe event
        /// Generic event, take T Argument
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="action">event action</param>
        /// <typeparam name="T">argument type</typeparam>
        /// <returns>return dispose container</returns>
        public static Events.Dispose.Container.DisposeContainer Add<T>(string key, Action<T> action) => Events.Handler.GenericEventHandler.Add(key, action);

        /// <summary>
        /// subscribe event
        /// take an unspecified amount arguments
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="action">event action</param>
        /// <returns>return dispose container</returns>
        public static Events.Dispose.Container.DisposeContainer Add(string key, Action<object[]> action) => Events.Handler.ObjectArgsHandler.Add(key, action);
       
        #endregion
        
        #region Remove events
       
        /// <summary>
        /// remove single event
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="action">event action</param>
        public static void Remove(string key, Action action) => Events.Handler.SingleEventHandler.Remove(key, action);
        
        /// <summary>
        /// remove generic event
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="action">event action</param>
        /// <typeparam name="T">argument type</typeparam>
        public static void Remove<T>(string key, Action<T> action) => Events.Handler.GenericEventHandler.Remove(key, action);
        
        /// <summary>
        /// remove unspecified amount event
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="action">event action</param>
        public static void Remove(string key, Action<object[]> action) => Events.Handler.ObjectArgsHandler.Remove(key, action);
       
        #endregion

        #region Invoke events
        
        /// <summary>
        /// invoke single event
        /// </summary>
        /// <param name="key">string event key</param>
        public static void Invoke(string key) => Events.Handler.SingleEventHandler.Invoke(key);
        /// <summary>
        /// invoke generic event
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="value">T argument variable</param>
        /// <typeparam name="T">argument type</typeparam>
        public static void Invoke<T>(string key, T value) => Events.Handler.GenericEventHandler.Invoke(key, value);
        /// <summary>
        /// invoke unspecified amount event
        /// </summary>
        /// <param name="key">string event key</param>
        /// <param name="value">unspecified amount value</param>
        public static void Invoke(string key,params object[] value) => Events.Handler.ObjectArgsHandler.Invoke(key, value);
        
        #endregion
    }
}