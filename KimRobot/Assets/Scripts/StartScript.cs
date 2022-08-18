using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public GameObject PlayerObj;
    public PlayerController Player;
    public GameObject StartPlayer;


    public AudioSource GlassBroken;          //�Ǹ��� ������ ����
    public AudioSource CylinderWarning;          //�Ǹ��� ��� ����

    public bool isStart = false;
    public bool isStartDone = false;
    Animator StartAnimation;            //���� �ִϸ��̼�
    Transform[] Trs;
    // Start is called before the first frame update
    void Start()
    {

        //Tr = gameObject.GetComponent<Transform>();
        Trs = gameObject.GetComponentsInChildren<Transform>();
        isStart = false;
        StartAnimation = GetComponent<Animator>();
    }
    IEnumerator StartAnimationCo()
    {
        Trs[3].gameObject.SetActive(false);
        StartAnimation.SetTrigger("WakeUp");
        yield return new WaitForSeconds(6f);
        //transform.position = StartPos.transform.position;

        isStartDone = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            isStart = false;
            StartCoroutine(StartAnimationCo());

        }
        if (isStartDone)
        {
            StopCoroutine(StartAnimationCo());
            //Trs[3].gameObject.SetActive(true);
            if (GetComponent<StartScript>() != null)
            {

                GetComponent<StartScript>().StartPos();
            }
            SceneManager.LoadScene("MainGame");
        }
    }
    public void StartPos()
    {
        PlayerObj.SetActive(true);
        Player.isStartDone = true;
        StartPlayer.SetActive(false);
    }
}
