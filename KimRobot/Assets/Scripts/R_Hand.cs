using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hand : MonoBehaviour
{
    public GameObject Player;
    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(7, 7);
        Debug.Log("���� ���̾�� " + this.transform.gameObject.layer);
    }
    private void FixedUpdate()
    {

    }
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Gun")
        {
            return;
        }

        Debug.Log("Exit �浹ü�� " + other.transform.gameObject.name);
        if (other.transform.tag == "Clue" || other.transform.tag == "RedPrism" || other.transform.tag == "BluePrism")
        {
            other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
    }
    /*private void OnTriggerExit(Collider other)          //����
    {
       

    }*/
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Gun")
        {
            return;
        }

        Debug.Log("Stay �浹ü�� " + other.transform.gameObject.name);
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
    /*private void OnTriggerStay(Collider other)              //���� ���¿���
    {
        

       
       

    }*/

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter �浹ü�� " + other.transform.gameObject.name);
        if (other.transform.tag == "Player" || other.transform.tag == "Gun")
        {
            // Physics.IgnoreCollision(other.collider,);
            return;
        }

        if (other.transform.tag == "GunBefore")
        {
            other.transform.tag = "Gun";
            other.transform.parent = gameObject.transform;
            other.transform.position = new Vector3(0.007f, 0.092f, 0.06f);
            other.transform.rotation =Quaternion.Euler( new Vector3(310.351f, 53.866f, 96.37f));

        }
        if (other.transform.tag == "Cylinder")
        {
            other.transform.GetComponent<Break>().isBreak = true;
        }
        if (other.transform.tag == "Photo1" ||
            other.transform.tag == "Photo2" ||
            other.transform.tag == "Photo3")
        {
            Debug.Log("���̿����׿�");
            other.transform.GetComponent<Screen>().OpenDoor();          //������
        }

        if (other.transform.tag == "Clue")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))          //�ܼ�����
            {
                //Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, 0.3f);

            }
        }
    }
}

