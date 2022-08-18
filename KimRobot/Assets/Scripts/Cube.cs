using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2.549997f)
        {
            transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
        }
    }
}
