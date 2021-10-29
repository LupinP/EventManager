using System.Collections;
using System.Collections.Generic;
using LP.EventManager;
using LP.EventManager.Events;
using LP.EventManager.Events.Dispose;
using LP.EventManager.Events.Handler;
using UnityEngine;

public class Example : MonoBehaviour
{
   private EventDisposal _disposal = new EventDisposal();
   void Awake()
   {
      ExampleAddEvents();
   }

   void ExampleAddEvents()
   {
      EventManager.Add("Example1", () =>
      {
         //Example1
      }).AddTo(_disposal);
      
      
      EventManager.Add<int>("Example2", intValue =>
      {
         //Example2
      }).AddTo(_disposal);
      
      
      EventManager.Add("Example3", objects =>
      {
         //Example3
      }).AddTo(_disposal);

      DynamicEventManager.Add("Example4", o =>
      {
         //Example4
      }).AddTo(_disposal);

      DynamicEventManager.Add("Example5", objects =>
      {
         //Example5
      }).AddTo(_disposal);

   }

   void ExampleInvokeEvents()
   {
      EventManager.Invoke("Example1");

      EventManager.Invoke("Exampl2", 1);
      
      EventManager.Invoke("Example3", 1, 2, "example_data");
      
      DynamicEventManager.Invoke("Example4", "example_data");
      //OR
      DynamicEventManager.Invoke("Example4", 1);

      DynamicEventManager.Invoke("Example5", 1, 2, "example_data");


   }

   void OnDestroy()
   {
      _disposal.Dispose();
   }
}
