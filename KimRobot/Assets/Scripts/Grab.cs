using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="L_Hand")              //왼쪽 손인가
        {
          
        }
    }
}
