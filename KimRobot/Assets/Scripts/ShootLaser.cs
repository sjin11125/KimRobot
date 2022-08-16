
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    string LaserColor;
    LaserBeam beam;

    GameObject Cube;
    public GameObject pivot;
    GameObject Red;
    GameObject Green;

    public GameObject GunPivot;

    public GameObject Player;
    PlayerController PlayerController;

    public static bool colliderExit;

    private void Start()
    {
        Red = transform.GetChild(0).gameObject;
        Green = transform.GetChild(1).gameObject;
        Cube = GameObject.FindWithTag("Cube");
        PlayerController = Player.GetComponent<PlayerController>();
    }

    void Update()
    {
        //TestScript.colliderPos[0] = GunPivot.transform.position;
        Destroy(GameObject.Find("Laser Beam"));

        if (Input.GetMouseButtonUp(0))
        {
            colliderExit = true;
            if (pivot.transform.childCount > 0)
            {
                pivot.transform.GetChild(0).transform.parent = null;
            }

            Cube.GetComponent<BoxCollider>().enabled = true;
            for (int i = 0; i < Cube.transform.childCount; i++)
            {
                Cube.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
           
        }

        if (Input.GetMouseButton(0))
        {
            if (Red.activeSelf && Green.activeSelf)
            {
                pivot.transform.position = GunPivot.transform.position;
                pivot.transform.rotation = this.transform.rotation;
                beam = new LaserBeam(pivot.transform.position, gameObject.transform.forward, material, "Yellow");
            }
            else
            {
                if (Red.activeSelf)
                {
                    beam = new LaserBeam(GunPivot.transform.position, gameObject.transform.forward, material, "Red");                  
                }
                else if (Green.activeSelf)
                {
                    beam = new LaserBeam(GunPivot.transform.position, gameObject.transform.forward, material, "Green");
                }
            }
        }

        //------------------¿ÀÅ§¿ë----------------------
        /*  if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
          {
              if (Red.activeSelf && Green.activeSelf)
              {
                  pivot.transform.position = GunPivot.transform.position;
                  pivot.transform.rotation = this.transform.rotation;
                  beam = new LaserBeam(pivot.transform.position, gameObject.transform.forward, material, "Yellow");
              }
              else
              {
                  if (Red.activeSelf)
                  {
                      beam = new LaserBeam(GunPivot.transform.position, gameObject.transform.forward, material, "Red");
                  }
                  else if (Green.activeSelf)
                  {
                      beam = new LaserBeam(GunPivot.transform.position, gameObject.transform.forward, material, "Green");
                  }
              }
          }*/



        if (Input.GetKeyDown("z"))
        {
            if (PlayerController.Prism[0]==true)            //레드 프리즘을 얻었는가
            {
                PlayerController.GunColor.Play();               //효과음 재생
                if (Red.activeSelf)
                {
                    Red.SetActive(false);
                }
                else
                {
                    Red.SetActive(true);
                }
            }
            

        }
        if (Input.GetKeyDown("x"))
        {
            if (PlayerController.Prism[1] == true)            //초록 프리즘을 얻었는가
            {
                PlayerController.GunColor.Play();               //효과음 재생
                if (Green.activeSelf)
                {
                    Green.SetActive(false);
                }
                else
                {
                    Green.SetActive(true);
                }
            }
        }



        //-------------------------¿ÀÅ§¿ë------------------------
        /*
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            if(Red.activeSelf)
            {
                Red.SetActive(false);
            }
            else
            {
                Red.SetActive(true);
            }

        }
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (Green.activeSelf)
            {
                Green.SetActive(false);
            }
            else
            {
                Green.SetActive(true);
            }
        }*/



        //RotateGun();
    }

   /* void RotateGun()
    {
        Vector3 pos = Input.mousePosition;

        pos.x = Mathf.Clamp(pos.x, 0, Screen.width);
        pos.y = Mathf.Clamp(pos.y, 0, Screen.height);

        pos.z = 2f;
        Vector3 view = Camera.main.ScreenToViewportPoint(pos);

        transform.LookAt(view);
    }*/
}
