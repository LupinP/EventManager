using System.Collections;
using System.Collections.Generic;
using LP.EventManager.Events.Dispose.Container;
using UnityEngine;

namespace LP.EventManager.Events.Dispose
{
    public class EventDisposal 
    {
        private readonly List<DisposeContainer> _disposeActions = new List<DisposeContainer>();

        public void Add(DisposeContainer contaienr_)
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