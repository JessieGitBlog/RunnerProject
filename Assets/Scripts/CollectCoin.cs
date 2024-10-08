using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
   public AudioSource coinFX;
   private int value = 1;
private void OnTriggerEnter(Collider other)
   {
      other.GetComponent<PlayerInfo>().GetCoin(value);
      this.gameObject.SetActive(false);
   }
}
