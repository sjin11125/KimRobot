using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform Tr;
    public int Speed = 3;
    public int JumpForce = 150;

    float dirX = 0;
    float dirZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        Tr = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMove();                   //플레이어 이동(컨트롤러)
        PlayerMove_Keyboard();          //플레이어 이동(키보드로)
    }
    public void PlayerMove()
    {
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)   )     //
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(pos.x);
            var absY = Mathf.Abs(pos.y);

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
        }
       Vector3 moveDir = new Vector3(dirX * Speed, 0, dirZ * Speed);
        transform.Translate(moveDir*Time.smoothDeltaTime);

    }
    public void PlayerMove_Keyboard()
    {
        Vector3 Angle = transform.eulerAngles;
        Angle.y+= -Input.GetAxis("Mouse X") * 5;
        Angle.x+= Input.GetAxis("Mouse Y") * 5;
        //Angle.x = (Angle.x <0) ? Angle.x + 360 : Angle.x;
        Angle.x = (Angle.x <1) ? Angle.x - 360 : Angle.x;
        Angle.x = Mathf.Clamp(Angle.x,-50f,50f);
        transform.rotation = Quaternion.Euler(Angle);
       // float y=0;
        //y += Input.GetAxis("Mouse Y") * 5;
       // y = Mathf.Clamp(y, -100f, 100f);
        //transform.Rotate(Mathf.Clamp(-Input.GetAxis("Mouse Y"), -55f, 55f), Input.GetAxis("Mouse X") * Speed, 0f);
        //transform.eulerAngles = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X") * Speed, 0f);
       // transform.rotation=Vector3(-y, Input.GetAxis("Mouse X") * Speed, 0f);
        if (Input.GetKey(KeyCode.A))        //왼쪽이동
        {
            Tr.Translate(Vector3.left*Time.smoothDeltaTime* Speed);
        }
        if (Input.GetKey(KeyCode.W))        //앞으로 이동
        {
            Tr.Translate(Vector3.forward * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))        //뒤로이동
        {
            Tr.Translate(Vector3.back * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))        //오른쪽이동
        {
            Tr.Translate(Vector3.right * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))        //점프
        {
            Tr.Translate(Vector3.up* Time.smoothDeltaTime * JumpForce);
        }
    }
}
