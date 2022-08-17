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

    bool isClue = false;        //단서를 보고 있나
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

        if ((Input.GetKeyUp(KeyCode.Q)&&col!=null)|| 
            ((OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)) && col != null))
        {
            if (isClue)
            {
                col = null;
                Debug.Log("isClue는 true");
                isClue = false;

                Player.GetComponentsInChildren<Camera>()[1].enabled = true;
                Player.GetComponent<PlayerController>().enabled = true;        //플레이어 움직일수잇게

                UICamera.GetComponentsInChildren<Camera>()[0].enabled = false;
                
                Destroy(Clue);

            }
            else
            {
                Debug.Log("isClue는 false");
                isClue = true;
                UICamera = col.transform.GetComponentInChildren<Camera>().gameObject;
                //UICamera.GetComponentsInChildren<Camera>()[0].enabled = false;

                UICamera.GetComponentsInChildren<Camera>()[0].enabled = true;
                Player.GetComponentsInChildren<Camera>()[1].enabled = false;
                Player.GetComponent<PlayerController>().Book.Play();            //효과음 재생
                Player.GetComponent<PlayerController>().enabled = false;        //플레이어 못 움직이게

                Clue = Instantiate(ClueCanvas, col.transform.GetComponentInChildren<Camera>().transform);
                //ClueCanvas.transform.SetParent(other.transform.GetComponentInChildren<Camera>().transform);
                Clue.SetActive(true);               //단서 글 뜨게
                Clue.GetComponentInChildren<Text>().text = col.transform.GetComponentInChildren<ClueUI>().ClueString;

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
            col = null;
            //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
    }
    /*private void OnTriggerExit(Collider other)          //떼면
    {
       

    }*/
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "GunBefore")
        {
            if (Input.GetMouseButtonDown(1)|| OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)|| OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))       //우클릭 혹은 오른쪽 컨트롤러 
            {
                Debug.Log("총 닿인다");
                Destroy(other.transform.gameObject);
                /*other.gameObject.layer = LayerMask.NameToLayer("Hand");         //충돌되지않게 레이어 바꾸기
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
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || Input.GetMouseButtonDown(1))         //우클릭 혹은 왼쪽 컨트롤러
            {

                Player.GetComponent<PlayerController>().Prism[1] = true;          //빨간색 프리즘 얻었다

                //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Debug.Log("빨간색 프리즘 얻음");
            
                    Destroy(other.transform.gameObject);
                
            }
            if (other.transform.tag == "BluePrism")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || Input.GetMouseButtonDown(1))         //우클릭 혹은 왼쪽 컨트롤러
                {

                    Player.GetComponent<PlayerController>().Prism[0] = true;          //초록색 프리즘 얻었다

                    //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                    Debug.Log("초록색 프리즘 얻음");
                   
                        Player.GetComponent<PlayerController>().Prism[2] = true;          //노란색 프리즘 얻었다
                        Destroy(other.transform.gameObject);
                    
                }
            }
        }
       
        if (other.transform.tag == "Photo1" ||
            other.transform.tag == "Photo2" ||
            other.transform.tag == "Photo3")
        {
            Debug.Log("문이열리네여");
            Player.GetComponent<PlayerController>().Door.Play();            //효과음 재생
            other.transform.GetComponent<Screen>().OpenDoor();          //문열어
        }

        if (other.transform.tag == "Clue"&&col==null)
        {
            col = other;


        }
    }
    /*private void OnTriggerStay(Collider other)              //닿인 상태에서
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
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)|| OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                Debug.Log("총 닿인다");
                Destroy(other.transform.gameObject);
                /*other.gameObject.layer = LayerMask.NameToLayer("Hand");         //충돌되지않게 레이어 바꾸기
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

        if (other.transform.tag == "Clue")
        {
            col = other;
        }
        if (other.transform.tag == "Next")
        {
            other.transform.parent.GetComponent<TutorialScreen>().NextText();
        }
        if (other.transform.tag == "Undo")
        {
            other.transform.parent.GetComponent<TutorialScreen>().UndoText();
        }

    }
}

