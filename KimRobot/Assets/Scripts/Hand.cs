using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HandPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = HandPrefab.transform.position;
    }
}