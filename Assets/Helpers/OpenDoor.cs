using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   [SerializeField] 
   private float _distanceToMove;
   [SerializeField] 
   private float _timeToOpen;

   [SerializeField] 
   private AudioClip _doorOpenSound;
   
   public void Open()
   {
      transform.DOLocalMove(transform.localPosition + new Vector3(0, _distanceToMove, 0), _timeToOpen);
      AudioSource.PlayClipAtPoint(_doorOpenSound, transform.position);
   }
}
