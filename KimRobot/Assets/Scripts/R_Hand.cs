using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Hand : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gun;
    public GameObject UICamera;
    public GameObject ClueCanvas;
    public GameObject UICameraParent;
    public GameObject CenterCamera;
<<<<<<< Updated upstream
=======
    public Transform PosReset;

>>>>>>> Stashed changes
    bool isClue = false;        //�ܼ��� ���� �ֳ�
    GameObject Clue;
    Collision col;

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
    }
    private void Update()
    {

        if ((Input.GetKeyUp(KeyCode.Q) && col != null) ||
            ((OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)) && col != null))
        {
            if (isClue)
            {
                col = null;
                Debug.Log("isClue�� true");
                isClue = false;

                Player.GetComponentsInChildren<Camera>()[1].enabled = true;
                Player.GetComponent<PlayerController>().enabled = true;        //�÷��̾� �����ϼ��հ�
                UICamera.transform.SetParent(UICameraParent.transform);         //ī�޶� �θ� �ٽ� ����
                //UICamera.GetComponentsInChildren<Transform>()[1].transform.gameObject.SetActive(false);     //�ܼ�����

                UICamera.GetComponentsInChildren<Transform>()[1].GetComponent<Canvas>().enabled = false;

                CenterCamera.SetActive(true);
                UICamera.GetComponentsInChildren<Camera>()[0].enabled = false;

                Destroy(Clue);

            }
            else
            {
                Debug.Log("isClue�� false");
                isClue = true;
                UICamera = col.transform.GetComponentInChildren<Camera>().gameObject;
                //Player.transform.position = PosReset.position;
                //UICamera.GetComponentsInChildren<Camera>()[0].enabled = false;

                UICamera.GetComponentsInChildren<Camera>()[0].enabled = true;

                Player.GetComponent<PlayerController>().Book.Play();            //ȿ���� ���
                Player.GetComponent<PlayerController>().enabled = false;        //�÷��̾� �� �����̰�

                // Clue = Instantiate(ClueCanvas, col.transform.GetComponentInChildren<Camera>().transform);

                UICameraParent = UICamera.transform.parent.gameObject;      //ī�޶� �θ� �޾ƿ�
                //UICamera.transform.SetParent(TrackingCamera.transform);     //ī�޶� �θ� �缳��
                UICamera.GetComponentsInChildren<Transform>()[1].GetComponent<Canvas>().enabled = true;


                CenterCamera.SetActive(false);                      //CentereyeAnchor ��Ȱ��ȭ 
                //ClueCanvas.transform.SetParent(other.transform.GetComponentInChildren<Camera>().transform);
                //Clue.SetActive(true);               //�ܼ� �� �߰�
                //Clue.GetComponentInChildren<Text>().text = col.transform.GetComponentInChildren<ClueUI>().ClueString;

            }

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
            if (isClue == false)
            {

                col = null;
            }
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
            if (Input.GetMouseButtonDown(1) || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))       //��Ŭ�� Ȥ�� ������ ��Ʈ�ѷ� 
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
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || Input.GetMouseButtonDown(1))         //��Ŭ�� Ȥ�� ���� ��Ʈ�ѷ�
            {

                Player.GetComponent<PlayerController>().Prism[1] = true;          //������ ������ �����

                //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Debug.Log("������ ������ ����");

                Destroy(other.transform.gameObject);

            }

        }
        if (other.transform.tag == "BluePrism")
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || Input.GetMouseButtonDown(1))         //��Ŭ�� Ȥ�� ���� ��Ʈ�ѷ�
            {

                Player.GetComponent<PlayerController>().Prism[0] = true;          //�ʷϻ� ������ �����

                //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Debug.Log("�ʷϻ� ������ ����");

                Player.GetComponent<PlayerController>().Prism[2] = true;          //����� ������ �����
                Destroy(other.transform.gameObject);

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

        if (other.transform.tag == "Clue" && col == null)
        {
            col = other;


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
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
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
            Player.GetComponent<StartScript>().GlassBroken.Play();
            Player.GetComponent<StartScript>().isStart = true;
            Player.GetComponent<StartScript>().CylinderWarning.Pause();
            other.transform.GetComponent<Break>().isBreak = true;
        }

        if (other.transform.tag == "Clue")
        {
            col = other;
        }
        if (other.transform.tag == "Exit")
        {
            Debug.Log("������");
            Application.Quit();
        }
        if (other.transform.tag == "Next")
        {
            Player.GetComponent<PlayerController>().Clue.Play();            //ȿ���� ���
            other.transform.parent.GetComponent<TutorialScreen>().NextText();
        }
        if (other.transform.tag == "Undo")
        {
            Player.GetComponent<PlayerController>().Clue.Play();            //ȿ���� ���
            other.transform.parent.GetComponent<TutorialScreen>().UndoText();
        }

    }
}

