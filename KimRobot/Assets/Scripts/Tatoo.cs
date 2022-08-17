using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tatoo : MonoBehaviour
{
    public GameObject GreenPrism;
    public VRPlayerController PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isTatoo)
        {
            PlayerController.isTatoo = false;
            PrismOn();
        }
    }
   /* private void OnTriggerEnter(Collision collision)
    {
        if (collision.transform.gameObject.name== "Laser Beam")
        {
            
        }
    }*/

    public void PrismOn()
    {
        GreenPrism.SetActive(true);
        PlayerController.Clue.Play();
    }
}
