using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hand : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerExit(Collider other)          //����
    {
        if (other.transform.tag == "Clue"|| other.transform.tag == "RedPrism"|| other.transform.tag == "BluePrism")
        {
            other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }

    }
    private void OnTriggerStay(Collider other)              //���� ���¿���
    {
        

        if (other.transform.tag == "RedPrism")
        {

            Player.GetComponent<PlayerController>().Prism[0] = true;          //������ ������ �����

            other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

            if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      ��ŧ����
            {
                Destroy(other.transform.gameObject);
            }
        }
            if (other.transform.tag == "BluePrism")
        {
            Debug.Log("�浹ü�� " + other.transform.gameObject.name);
            Player.GetComponent<PlayerController>().Prism[1] = true;          //�Ķ��� ������ �����
            Debug.Log(other.transform.GetComponentInChildren<SkinnedMeshRenderer>().gameObject.name);
            other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

            if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      ��ŧ����
            {
                Player.GetComponent<PlayerController>().Prism[2] = true;          //����� ������ �����
                Destroy(other.transform.gameObject);
            }
        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Player"|| other.transform.tag == "Gun")
        {
            return;
        }
        

        if (other.transform.tag == "Cylinder")
        {
            other.transform.GetComponent<Break>().isBreak = true;
        }
        if (other.transform.tag == "Photo1"||
            other.transform.tag == "Photo2"|| 
            other.transform.tag == "Photo3")
        {
            other.transform.GetComponent<Screen>().OpenDoor();          //������
        }
       
        
    }
    void OnCollisionEnter(Collision collision)
    {
        
    }
}
