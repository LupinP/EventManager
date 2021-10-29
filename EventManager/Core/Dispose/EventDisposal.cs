namespace LP.EventManager.Events.Dispose
{
    using System.Collections.Generic;
    
    public class EventDisposal 
    {
        private readonly List<Container.DisposeContainer> _disposeActions = new List<Container.DisposeContainer>();

        public void Add(Container.DisposeContainer contaienr_)
        {
            _disposeActions.Add(contaienr_);
        }

        public void Dispose()
        {
            while (_disposeActions.Count > 0)
            {
                var contaienr_ = _disposeActions[0];
                _disposeActions.Remove(contaienr_);
                contaienr_.Invoke();
            }
        }
    }
}