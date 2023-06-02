using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCap : MonoBehaviour
{
    [SerializeField][Range(15,120)] private int fps;
    void Start()
    {
        Application.targetFrameRate = fps;
    }

}
