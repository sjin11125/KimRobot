using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    // Start is called before the first frame update
    Transform Tr;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.smoothDeltaTime * 10);
        rb.AddForce(Vector3.right*5, ForceMode.Impulse);
    }
}
