using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Player")
        {
            return;
        }
        Debug.Log("충돌체는 " + other.transform.gameObject.name);
        if (other.transform.tag == "Cylinder")
        {
            other.transform.GetComponent<Break>().isBreak = true;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        
    }
}
