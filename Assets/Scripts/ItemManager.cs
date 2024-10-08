using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
  [SerializeField] private LifePoints _lifePoints;
  public void OnDamaged()
  {
    _lifePoints.OnDamaged();
  }

  public void OnHealing()
  {
    
  }
}
