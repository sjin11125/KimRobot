﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform Tr;
    public int Speed = 3;
    public int JumpForce = 150;

    float dirX = 0;
    float dirZ = 0;

    float z = 0;

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 500.0f;

    bool isJump = false;

    public Camera Camera;
    RaycastHit hit=new RaycastHit();
    Ray ray;
    private Vector3 ScreenCenter;
    public GameObject rayEnd;
    Rigidbody rigi;

    public bool isWalk = false;
    public bool isGun = false;      //총을 쥐었는가?
    public GameObject Hand;         //손 오브젝트
    public Transform Gun;

    void Start()
    {
        Tr = gameObject.GetComponent<Transform>();
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        rigi = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMove();                   //플레이어 이동(컨트롤러)

        //---------------PC버전---------------------------------
        PlayerMove_Keyboard();          //플레이어 이동(키보드로)
        Grab();                         //우클릭 잡기

        ray = Camera.ScreenPointToRay(ScreenCenter);            //레이 쏘기
        //hit=;
        

        
    }
    public void Grab()
    {
        Debug.DrawLine(ray.origin, ray.GetPoint(10f), Color.green);
        
        if (Input.GetMouseButton(1))            //우클릭 잡기
        {
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(hit.point,hit.normal, Color.green);
                Debug.Log("충돌함");
                if (hit.transform.tag == "Clue")
                {
                    Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, 0.3f);
                }
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, -0.17f);

        }
        if (Input.GetMouseButtonDown(0)&&isGun==false)              //총을 아직 획득 안했을 때
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(hit.point, hit.normal, Color.green);
                if (hit.transform.tag == "Gun")                 //총을 집으면
                {
                    Debug.Log("총집음");
                    isGun = true;
                    //hit.transform.localPosition = new Vector3(0, 0, 0);
                    Gun.transform.gameObject.SetActive(true);
                }
            }
        }
        }
    public void PlayerMove()
    {
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)   )     // 이동
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(pos.x);
            var absY = Mathf.Abs(pos.y);

            isWalk = true;

            if (absX>absY)
            {
                if (pos.x>0)            //오른쪽 이동
                {
                    dirX = +1;
                }
                else                //왼쪽 이동
                {
                    dirX = -1;
                }
            }
            else
            {
                if (pos.y>0)            //위로 이동
                {
                    dirZ = +1;
                }
                else                            //아래로 이동
                {
                    dirZ = -1;
                }
            }
            Vector3 moveDir = new Vector3(dirX * Speed, 0, dirZ * Speed);
            transform.Translate(moveDir * Time.smoothDeltaTime);
        }
        else
        {
            isWalk = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))                   //점프
        {
            rigi.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)  )          //단서보기
        {

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(hit.point, hit.normal, Color.green);
                Debug.Log("충돌함");
                if (hit.transform.tag == "Clue")
                {
                    Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, 0.3f);
                }
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, -0.17f);

        }
    }
    public void PlayerMove_Keyboard()
    {

        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        yRotate = transform.eulerAngles.y + yRotateMove;
        xRotate = xRotate + xRotateMove;

        xRotate = Mathf.Clamp(xRotate, -50, 50); // 위, 아래 고정

        transform.localEulerAngles = new Vector3(xRotate, yRotate, 0);
        if (Input.GetKey(KeyCode.A))        //왼쪽이동
        {
            Tr.Translate(Vector3.left*Time.smoothDeltaTime* Speed);
            isWalk = true;
        }
        if (Input.GetKey(KeyCode.W))        //앞으로 이동
        {
            isWalk = true;
            Tr.Translate(Vector3.forward * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))        //뒤로이동
        {
            isWalk = true;
            Tr.Translate(Vector3.back * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))        //오른쪽이동
        {
            isWalk = true;
            Tr.Translate(Vector3.right * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isJump==false)        //점프
        {
            isJump = true;
            Rigidbody rigi=transform.GetComponent<Rigidbody>();
            rigi.AddForce(Vector3.up*5,ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {        //바닥에 닿으면        
        if (collision.gameObject.CompareTag("Wall"))
        {
            isJump=false;

        }
    }
       
}
