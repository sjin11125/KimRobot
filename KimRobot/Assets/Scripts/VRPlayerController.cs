using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerController : MonoBehaviour
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
    RaycastHit hit = new RaycastHit();
    Ray ray;
    private Vector3 ScreenCenter;
    public GameObject rayEnd;
    Rigidbody rigi;

    public bool isWalk = false;
    public bool isGun = false;      //���� ����°�?
    public bool[] Prism = new bool[3] { true, true, true };               //������ (R,G,Y)
    public bool isQuiz = false;             //���� ������
    public bool isTatoo = false;            //Ÿ������ ������
    public GameObject Hand;         //�� ������Ʈ
    public Transform Gun;
    public bool isStart = false;
    public bool isStartDone = false;
    public GameObject StartPos;         //��������
    Animator StartAnimation;            //���� �ִϸ��̼�
    Transform[] Trs;

    //�����
    public AudioSource walkAudio;           //�߻���
    public AudioSource GunColor;           //�� �¿��� ����
    public AudioSource Jump;           //���� ����
    public AudioSource TimerSound;           //�ð� ��� ����
    public AudioSource TimerSound2;           //�ð� ��� ����2
    public AudioSource BeamBounce;          //���� ƨ��� ����
    public AudioSource Clue;          //�ܼ�ȹ�� ���� (�ʷϻ� ������ �������� ����)
    public AudioSource Book;          //å �ѱ�� ����
    public AudioSource Door;          //�������� ����
    public AudioSource Screen;          //��ũ�� Ȱ��ȭ ����
    public AudioSource GunShoot;          //�ѹ߻� ����
    public AudioSource Neon;          //�׿� ������ ����
    public AudioSource GlassBroken;          //�Ǹ��� ������ ����
    public AudioSource CylinderWarning;          //�Ǹ��� ��� ����
    public GameObject gameExit;

    List<string> Inventory = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        Tr = gameObject.GetComponent<Transform>();
        Trs = gameObject.GetComponentsInChildren<Transform>();
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        rigi = GetComponent<Rigidbody>();

        isStart = false;
        StartAnimation = GetComponent<Animator>();


    }
    IEnumerator StartAnimationCo()
    {
        Trs[3].gameObject.SetActive(false);
        StartAnimation.SetTrigger("WakeUp");
        yield return new WaitForSeconds(6f);
        transform.position = StartPos.transform.position;

        isStartDone = true;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        //---------------PC����---------------------------------

        // Grab();                         //��Ŭ�� ���
        isStartDone = true;
        //PlayerMove_Keyboard();
        if (isQuiz)                     //���� Ǯ���� ��
        {
            isQuiz = false;

        }
        if (isStart)              //��ó�� ���ۿ��� �ּ�Ǯ��
        {
            isStart = false;
            StartCoroutine(StartAnimationCo());

        }
        /* if (isTatoo)
         {
             isTatoo = false;
         }*/
        if (isStartDone)
        {
            StopCoroutine(StartAnimationCo());
            //Trs[3].gameObject.SetActive(true);
            if (GetComponent<StartScript>() != null)
            {

                GetComponent<StartScript>().StartPos();
            }

            PlayerMove_Keyboard();          //�÷��̾� �̵�(Ű�����)
        }
        //hit=;
        if (isWalk && !walkAudio.isPlaying)
        {

            walkAudio.Play();

        }
        else if (!isWalk)
        {
            walkAudio.Pause();
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isJump = false;

        }

        if (collision.gameObject.name == "doorFrame")
        {
            gameExit.SetActive(true);
        }
    }
    public void Grab()
    {
        Debug.DrawLine(ray.origin, ray.GetPoint(10f), Color.green);

        if (Input.GetMouseButton(1))            //��Ŭ�� ���
        {

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(hit.point, hit.normal, Color.green);
                Debug.Log("�浹��");
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
        if (Input.GetMouseButtonDown(0) && isGun == false)              //���� ���� ȹ�� ������ ��
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(hit.point, hit.normal, Color.green);
                if (hit.transform.tag == "Gun")                 //���� ������
                {
                    Debug.Log("������");
                    isGun = true;
                    //hit.transform.localPosition = new Vector3(0, 0, 0);
                    Gun.transform.gameObject.SetActive(true);
                }
            }
        }
    }
    public void PlayerMove()
    {
        // Vector2 mov2d = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        // Vector3 mov = new Vector3(mov2d.x * Time.deltaTime * Speed, 0f, mov2d.y * Time.deltaTime * Speed);
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch) != new Vector2(0, 0))     // ȸ��
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
            // Debug.Log(pos);
            if (pos.x > 0)
            {
                // transform.rotation = Quaternion.Slerp(rigi.rotation,Vector3.right,10*Time.deltaTime);
                transform.Rotate(Vector3.up, 50 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.down, 50 * Time.deltaTime);
                // transform.rotation -=  Vector3.right;
            }
        }
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch) != new Vector2(0, 0))     // �̵�
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
            Debug.Log(pos);
            var absX = Mathf.Abs(pos.x);
            var absY = Mathf.Abs(pos.y);

            // isWalk = true;

            if (absX > absY)
            {
                if (pos.x > 0)            //������ �̵�
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
                if (pos.y > 0)            //���� �̵�
                {
                    dirZ = +1;
                }
                else                            //�Ʒ��� �̵�
                {
                    dirZ = -1;
                }
            }
            Vector3 moveDir = new Vector3(pos.x * Speed, 0, pos.y * Speed);
            transform.Translate(moveDir * Time.smoothDeltaTime);
        }
        if (OVRInput.GetUp(OVRInput.Touch.PrimaryThumbstick))               //�̵� ����
        {
            isWalk = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && isJump == false)                   //����
        {
            Jump.Play();
            rigi.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonUp(1))
        {
            Camera.transform.localPosition = new Vector3(Camera.transform.localPosition.x, Camera.transform.localPosition.y, -0.17f);

        }
    }
    public void PlayerMove_Keyboard()
    {


        if (Input.GetKey(KeyCode.A))        //�����̵�
        {
            Tr.Translate(Vector3.left * Time.smoothDeltaTime * Speed);
            isWalk = true;
        }
        if (Input.GetKey(KeyCode.W))        //������ �̵�
        {
            isWalk = true;
            Tr.Translate(Vector3.forward * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))        //�ڷ��̵�
        {
            isWalk = true;
            Tr.Translate(Vector3.back * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))        //�������̵�
        {
            isWalk = true;
            Tr.Translate(Vector3.right * Time.smoothDeltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)        //����
        {
            Jump.Play();
            isJump = true;
            Rigidbody rigi = transform.GetComponent<Rigidbody>();
            rigi.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isWalk = false;
        }
    }


}
