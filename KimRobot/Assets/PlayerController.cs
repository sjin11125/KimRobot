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
        PlayerMove();                   //플레이어 이동(컨트롤러)
        PlayerMove_Keyboard();          //플레이어 이동(키보드로)
    }
    public void PlayerMove()
    {
        
    }
    public void PlayerMove_Keyboard()
    {
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
    }
}
