using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hand : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerExit(Collider other)          //떼면
    {
        if (other.transform.tag == "Clue"|| other.transform.tag == "RedPrism"|| other.transform.tag == "BluePrism")
        {
            other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }

    }
    private void OnTriggerStay(Collider other)              //닿인 상태에서
    {
        

        if (other.transform.tag == "RedPrism")
        {

            Player.GetComponent<PlayerController>().Prism[0] = true;          //빨간색 프리즘 얻었다

            other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

            if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      오큘에서
            {
                Destroy(other.transform.gameObject);
            }
        }
            if (other.transform.tag == "BluePrism")
        {
            Debug.Log("충돌체는 " + other.transform.gameObject.name);
            Player.GetComponent<PlayerController>().Prism[1] = true;          //파란색 프리즘 얻었다
            Debug.Log(other.transform.GetComponentInChildren<SkinnedMeshRenderer>().gameObject.name);
            other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

            if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      오큘에서
            {
                Player.GetComponent<PlayerController>().Prism[2] = true;          //노란색 프리즘 얻었다
                Destroy(other.transform.gameObject);
            }
        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Player")
        {
            return;
        }
        

        if (other.transform.tag == "Cylinder")
        {
            other.transform.GetComponent<Break>().isBreak = true;
        }
       
        
    }
    void OnCollisionEnter(Collision collision)
    {
        
    }
}
