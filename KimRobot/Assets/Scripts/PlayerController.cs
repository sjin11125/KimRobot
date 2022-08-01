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

    float z = 0;

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 500.0f;

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

        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        yRotate = transform.eulerAngles.y + yRotateMove;
        //xRotate = transform.eulerAngles.x + xRotateMove; 
        xRotate = xRotate + xRotateMove;

        xRotate = Mathf.Clamp(xRotate, -55, 55); // ��, �Ʒ� ����

        transform.localEulerAngles = new Vector3(xRotate, yRotate, 0);
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
