# EventManager
## Event Manager with static and dynamic typing

There are two managers in the repository:
EventManager and DynamicEventManager

EventManager has three methods:

### Add:

> Add new event in EventManager
```
EventManager.Add(EventName, EventAction).AddTo(eventDisposal); // No argument event

EventManager.Add<T>(EventName, EventAction<T>).AddTo(eventDisposal); // T Argument event

EventManager.Add(EventName, EventAction<object[]>).AddTo(eventDisposal); // unspecified amount arguments event

```

### Remove: 
> Remove event from EventManager

```
EventManager.Remove(EventName, EventAction); // No argument event

EventManager.Remove<T>(EventName, EventAction<T>); // T Argument event

EventManager.Remove(EventName, EventAction<object[]>); // unspecified amount arguments event

```

### Invoke
> Invoke events from EventManager
```
EventManager.Invoke(EventName); // No argument event

EventManager.Invoke<T>(EventName, T_Value); // T Argument event

EventManager.Invoke(EventName, objectArray); // unspecified amount arguments event

```

## EventDisposal

Storage responsible for unsubscribing events from **EventManager**. Method **Add** return **DisposeContainer**, this container need put to **EventDisposal**.

### Create EventDisposal
```
 private EventDisposal eventDisposal = new EventDisposal();
```
### Add to EventDisposal

DisposeContainer has **AddTo** method
```
DisposeContainer eventDisposal = EventManager.Add(EventName, EventAction);

eventDisposal.AddTo(eventDisposal);
```

**OR**

```
EventManager.Add(EventName, EventAction).AddTo(eventDisposal);
```

### Dispose 

EventDisposal has **Dispose** method. This method unsubscribing events from **EventManager**.

```
eventDisposal.Dispose();
```

----------------------------------------------------------------------------------------------

# Dymanic Event manager

It contains the same architecture. Only the type argument has been replaced with dynamical.

> Be careful: when working with dynamics, you need to remember where what function takes what. 

