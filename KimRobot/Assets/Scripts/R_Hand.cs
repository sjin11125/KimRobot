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
    /*private void OnTriggerExit(Collider other)          //떼면
    {
       

    }*/
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "GunBefore")
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)||Input.GetMouseButtonDown(1))       //우클릭 혹은 오른쪽 컨트롤러 
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
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(1))         //우클릭 혹은 왼쪽 컨트롤러
            {

                Player.GetComponent<PlayerController>().Prism[0] = true;          //빨간색 프리즘 얻었다

                //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Debug.Log("빨간색 프리즘 얻음");
                if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      오큘에서
                {
                    Destroy(other.transform.gameObject);
                }
            }
            if (other.transform.tag == "BluePrism")
            {
                Player.GetComponent<PlayerController>().Prism[1] = true;          //초록색 프리즘 얻었다

                //other.transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                Debug.Log("초록색 프리즘 얻음");
                if (Input.GetMouseButton(0))//OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))      오큘에서
                {
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
            other.transform.GetComponent<Screen>().OpenDoor();          //문열어
        }
    }
    /*private void OnTriggerStay(Collider other)              //닿인 상태에서
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
            other.transform.GetComponent<Break>().isBreak = true;
        }
        

        if (other.transform.tag == "Clue")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))          //단서보기
            {
                //Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, 0.3f);

            }
        }
    }
}

