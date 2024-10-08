using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    [SerializeField] private List<LifePoint> _lifePoints = new List<LifePoint>();

    private void Awake()
    {
        foreach (var lifePoint in _lifePoints)
        {
            lifePoint.Init();
        }
    }

    public void OnDamaged()
    {
        foreach (var lifePoint in _lifePoints)
        {
            if (lifePoint.isLife == true)
            {
                lifePoint.OnDamaged();
                return;
            }
        }
    }

    public void OnHealing()
    {
    }
}