using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.transform.gameObject.name);
        if (collision.transform.tag=="VRPlayer")
        {
            Debug.Log("³ª°¡±â");
            Application.Quit();
        }
    }
}
