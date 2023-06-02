using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSpawn : MonoBehaviour
{
    [SerializeField] private float timeToLive = 1f;
    private void OnEnable()
    {
        Destroy(gameObject,timeToLive);
    }
}
