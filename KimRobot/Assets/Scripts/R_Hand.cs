using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hand : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gun;

    
    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(7, 7);
        Physics.IgnoreLayerCollision(7, 8);
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

        if (other.transform.tag == "Clue" || other.transform.tag == "RedPrism" || other.transform.tag == "BluePrism")
        {
            //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
    }
    /*private void OnTriggerExit(Collider other)          //����
    {
       

    }*/
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "GunBefore")
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)||Input.GetMouseButtonDown(1))       //��Ŭ�� Ȥ�� ������ ��Ʈ�ѷ� 
            {
                Debug.Log("�� ���δ�");
                Destroy(other.transform.gameObject);
                /*other.gameObject.layer = LayerMask.NameToLayer("Hand");         //�浹�����ʰ� ���̾� �ٲٱ�
                other.transform.tag = "Gun";
                other.transform.parent = gameObject.transform;
                other.transform.position = new Vector3(0.007f, 0.092f, 0.06f);
                other.transform.rotation = Quaternion.Euler(new Vector3(310.351f, 53.866f, 96.37f));
                */
                Gun.SetActive(true);
            }

        }
        if (other.transform.tag == "Player" || other.transform.tag == "Gun")
        {
            return;
        }
      
            if (other.transform.tag == "RedPrism")
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(1))         //��Ŭ�� Ȥ�� ���� ��Ʈ�ѷ�
            {

                Player.GetComponent<PlayerController>().Prism[0] = true;          //������ ������ �����

                //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Debug.Log("������ ������ ����");
                if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      ��ŧ����
                {
                    Destroy(other.transform.gameObject);
                }
            }
            if (other.transform.tag == "BluePrism")
            {
                Player.GetComponent<PlayerController>().Prism[1] = true;          //�ʷϻ� ������ �����

                //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Debug.Log("�ʷϻ� ������ ����");
                if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      ��ŧ����
                {
                    Player.GetComponent<PlayerController>().Prism[2] = true;          //����� ������ �����
                    Destroy(other.transform.gameObject);
                }
            }
        }
       
        if (other.transform.tag == "Photo1" ||
            other.transform.tag == "Photo2" ||
            other.transform.tag == "Photo3")
        {
            Debug.Log("���̿����׿�");
            other.transform.GetComponent<Screen>().OpenDoor();          //������
        }
    }
    /*private void OnTriggerStay(Collider other)              //���� ���¿���
    {
        

       
       

    }*/

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Gun")
        {
            // Physics.IgnoreCollision(other.collider,);
            return;
        }

        if (other.transform.tag == "GunBefore")
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Debug.Log("�� ���δ�");
                Destroy(other.transform.gameObject);
                /*other.gameObject.layer = LayerMask.NameToLayer("Hand");         //�浹�����ʰ� ���̾� �ٲٱ�
                other.transform.tag = "Gun";
                other.transform.parent = gameObject.transform;
                other.transform.position = new Vector3(0.007f, 0.092f, 0.06f);
                other.transform.rotation = Quaternion.Euler(new Vector3(310.351f, 53.866f, 96.37f));
                */
                Gun.SetActive(true);
            }

        }
        if (other.transform.tag == "Cylinder")
        {
            other.transform.GetComponent<Break>().isBreak = true;
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

