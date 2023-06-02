using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool IsLeft;

    public Enemy enemy;

    private void OnBecameVisible()
    {
        enemy.PopOut(IsLeft);
    }
}
