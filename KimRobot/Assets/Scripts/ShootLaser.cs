using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    public string LaserColor;
    LaserBeam beam;
    //public static int ycount = 0;
   // public static Vector3 offset = Vector3.zero;

    void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));
       
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material, LaserColor);
    }
}
