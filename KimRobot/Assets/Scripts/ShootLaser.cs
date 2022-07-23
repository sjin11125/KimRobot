using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    public string LaserColor;
    LaserBeam beam;

    void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));
       // if(LaserPointer.ActiveSelf)
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material, LaserColor);
    }
}
