using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.EventManager.Events.Dispose.Container
{
    public class DisposeContainer
    {
        private Action _disposeAction;

        public DisposeContainer(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }


        public void Invoke()
        {
            _disposeAction?.Invoke();
            _disposeAction = null;
        }
    }
}
