using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale          = 0;
        StaticClass.pausedGame  = true;
        StaticClass.isDeath     = true;  
    }
}
