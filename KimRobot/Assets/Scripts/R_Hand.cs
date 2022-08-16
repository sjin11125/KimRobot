using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hand : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gun;
    public GameObject UICamera;

    bool isClue = false;        //�ܼ��� ���� �ֳ�

    
    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(7, 7);
        Physics.IgnoreLayerCollision(7, 8);
        Physics.IgnoreLayerCollision(7, 9);
        Physics.IgnoreLayerCollision(6, 9);
        Physics.IgnoreLayerCollision(8, 9);
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(isClue);
        }
        if (isClue)
        {
            UICamera.GetComponentsInChildren<Camera>()[0].enabled = true;
            Player.GetComponentsInChildren<Camera>()[1].enabled = false;
            Player.GetComponent<PlayerController>().enabled = false;        //�÷��̾� �� �����̰�

        }
        else
        {
            //UICamera.GetComponentsInChildren<Camera>()[1].enabled = false;
            Player.GetComponentsInChildren<Camera>()[1].enabled = true;
            Player.GetComponent<PlayerController>().enabled = true;        //�÷��̾� �����ϼ��հ�
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Gun")
        {
            return;
        }

        if (other.transform.tag == "Clue")
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
            Player.GetComponent<PlayerController>().Door.Play();            //ȿ���� ���
            other.transform.GetComponent<Screen>().OpenDoor();          //������
        }
        if (other.transform.tag == "Clue")
        {
            if (Input.GetKeyDown(KeyCode.Q))       //OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)   //�ܼ�����(���� ��Ʈ�ѷ�)
            {


                if (isClue)
                {
                   // UICamera = other.transform.GetComponentsInChildren<Camera>()[0].gameObject;
                    isClue = false;
                }
                else
                {
                    UICamera = other.transform.GetComponentsInChildren<Camera>()[0].gameObject;
                    Player.GetComponent<PlayerController>().Book.Play();            //ȿ���� ���
                    isClue = true;
                }

            

            }
            /*if (Input.GetKey(KeyCode.Q))       //OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)   //�ܼ�����(���� ��Ʈ�ѷ�)
            {
                isClue = true;

                UICamera = other.transform.GetComponentsInChildren<Camera>()[0].gameObject;
                //Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, 0.3f);
                Debug.Log("��Ŭ��");
          
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                Debug.Log("��");
                isClue = false;
            
            }*/
        }
    }
    /*private void OnTriggerStay(Collider other)              //���� ���¿���
    {
        

       
       

    }*/

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.transform.name);
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
            Player.GetComponent<PlayerController>().GlassBroken.Play();
            Player.GetComponent<PlayerController>().isStart = true;
            Player.GetComponent<PlayerController>().CylinderWarning.Pause();
            other.transform.GetComponent<Break>().isBreak = true;
        }
        

      
    }
}

