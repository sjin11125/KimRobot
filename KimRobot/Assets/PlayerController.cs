using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform Tr;
    public int Speed = 3;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        Tr = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();                   //�÷��̾� �̵�(��Ʈ�ѷ�)
        PlayerMove_Keyboard();          //�÷��̾� �̵�(Ű�����)
    }
    public void PlayerMove()
    {
        
    }
    public void PlayerMove_Keyboard()
    {
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
    }
}
