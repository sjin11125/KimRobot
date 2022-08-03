using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public Animator Door;
    public GameObject[] Rooms;
    public GameObject Player;
    public GameObject ScreenWall;

    bool isIn = false;
   public void OpenDoor()
    {
        if (transform.tag=="Photo1")
        {
            Rooms[0].SetActive(true);
            Rooms[1].SetActive(false);
            Rooms[2].SetActive(false);
        }
        else if (transform.tag == "Photo2")
        {
            Rooms[0].SetActive(false);
            Rooms[1].SetActive(true);
            Rooms[2].SetActive(false);
        }
        else
        {
            Rooms[0].SetActive(false);
            Rooms[1].SetActive(false);
            Rooms[2].SetActive(true);
        }
        Door.SetBool("isOpen",true);
    }
   public void CloseDoor()
    {
        Door.SetBool("isOpen",false);
    }
    private void Update()
    {

        if (isIn&&(Player.transform.position.x > ScreenWall.transform.position.x))      //������ ���ӳ�
        {
            isIn = false;
            CloseDoor();
        }
         if (!isIn && (Player.transform.position.x < ScreenWall.transform.position.x))      //�ȿ� ����
            isIn = true;
    }
}
