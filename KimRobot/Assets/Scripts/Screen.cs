using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public Animator[] Door;
    public GameObject[] Rooms;
    public GameObject Player;
    public GameObject[] ScreenWall;

    public GameObject[] LockObj;
    public GameObject PhotoObj;

    PlayerController PlayerController;
    private void Start()
    {
        PlayerController = Player.GetComponent<PlayerController>();
    }

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
        Door[0].SetBool("isOpen",true);
        Door[1].SetBool("isOpen",true);
    }
   public void CloseDoor()
    {
        Debug.Log("열림교회 닫힘");
        Door[0].SetBool("isOpen",false);
        Door[1].SetBool("isOpen",false);
    }
    private void Update()
    {
        if (transform.tag.Equals("Screen")&& PlayerController.isQuiz)            //퀴즈 맞혔니?네
        {
            PlayerController.Screen.Play();
            for (int i = 0; i < LockObj.Length; i++)
            {
                LockObj[i].SetActive(false);
            } //잠금 비활성화

           
                PhotoObj.SetActive(true);
            //스크린 활성화
        }
        if (isIn&&(Player.transform.position.x > -9f))      //밖으로 나왓나
        {
            isIn = false;
            CloseDoor();
        }
         if (!isIn && (Player.transform.position.x < -10f))      //안에 들어갔나
            isIn = true;
    }
}
