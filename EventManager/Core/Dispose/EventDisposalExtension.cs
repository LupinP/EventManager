namespace LP.EventManager.Events.Dispose
{
    public static class EventDisposalExtension
    {
        public static Container.DisposeContainer AddTo(this Container.DisposeContainer container, EventDisposal disposal)
        {
            disposal.Add(container);
            return container;
        }
    }
}