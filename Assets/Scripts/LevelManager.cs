using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static double leftSide = -6.75;
    public static double rightSide = 6.75;
    public double InternalLeft;
    public double InternalRight;


    void Update()
    {
        InternalLeft = leftSide;
        InternalRight = rightSide;
    }
}