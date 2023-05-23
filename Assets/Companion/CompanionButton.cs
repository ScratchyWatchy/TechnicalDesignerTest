using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompanionButton : MonoBehaviour
{
   public UnityEvent onButtonActivated;
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("GoodBoy"))
      {
         onButtonActivated.Invoke();
      }
   }
}
