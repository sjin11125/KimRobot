using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    string LaserColor;
    LaserBeam beam;

    public GameObject pivot;
    GameObject Red;
    GameObject Green;

    private void Start()
    {
        Red = transform.GetChild(0).gameObject;
        Green = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));

        if (Input.GetMouseButtonUp(0))
        {
            if(pivot.transform.childCount > 0)
            {
                pivot.transform.GetChild(0).transform.parent = null;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Red.activeSelf && Green.activeSelf)
            {
                pivot.transform.position = this.transform.position;
                pivot.transform.rotation = this.transform.rotation;
                beam = new LaserBeam(gameObject.transform.position, gameObject.transform.forward, material, "Yellow");
            }
            else
            {
                if (Red.activeSelf)
                {
                    beam = new LaserBeam(gameObject.transform.position, gameObject.transform.forward, material, "Red");
                }
                else if (Green.activeSelf)
                {
                    beam = new LaserBeam(gameObject.transform.position, gameObject.transform.forward, material, "Green");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Green.activeSelf)
            {
                Green.SetActive(false);
            }
            else
            {
                Green.SetActive(true);
            }
        }
        RotateGun();
    }

    void RotateGun()
    {
        Vector3 pos = Input.mousePosition;

        pos.x = Mathf.Clamp(pos.x, 0, Screen.width);
        pos.y = Mathf.Clamp(pos.y, 0, Screen.height);

        pos.z = 2f;
        Vector3 view = Camera.main.ScreenToViewportPoint(pos);

        transform.LookAt(view);
    }
}
