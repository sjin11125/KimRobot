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
        //PlayerMove();                   //�÷��̾� �̵�(��Ʈ�ѷ�)
        PlayerMove_Keyboard();          //�÷��̾� �̵�(Ű�����)
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
                if (pos.x>0)            //������ �̵�
                {
                    dirX = +1;
                }
                else                //���� �̵�
                {
                    dirX = -1;
                }
            }
            else
            {
                if (pos.y>0)            //���� �̵�
                {
                    dirZ = +1;
                }
                else                            //�Ʒ��� �̵�
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
        if (Input.GetKey(KeyCode.A))        //�����̵�
        {
            Tr.Translate(Vector3.left*Time.smoothDeltaTime* Speed);
        }
        if (Input.GetKey(KeyCode.W))        //������ �̵�
        {
            Tr.Translate(Vector3.forward * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))        //�ڷ��̵�
        {
            Tr.Translate(Vector3.back * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))        //�������̵�
        {
            Tr.Translate(Vector3.right * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))        //����
        {
            Tr.Translate(Vector3.up* Time.smoothDeltaTime * JumpForce);
        }
    }
}
