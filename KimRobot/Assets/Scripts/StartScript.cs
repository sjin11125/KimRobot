using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public GameObject PlayerObj;
    public VRPlayerController Player;
    public GameObject StartPlayer;


    public AudioSource GlassBroken;          //실린더 깨지는 사운드
    public AudioSource CylinderWarning;          //실린더 경고 사운드

    public bool isStart = false;
    public bool isStartDone = false;
    Animator StartAnimation;            //시작 애니메이션
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
            SceneManager.LoadScene("MainGame");
            StopCoroutine(StartAnimationCo());
            //Trs[3].gameObject.SetActive(true);
            if (GetComponent<StartScript>() != null)
            {

                GetComponent<StartScript>().StartPos();
            }
        }
    }
    public void StartPos()
    {
        // PlayerObj.SetActive(true);
        //Instantiate(PlayerObj);
        //Player.isStartDone = true;
        //StartPlayer.SetActive(false);
        SceneManager.LoadScene("GunAvataTest");
    }
}
