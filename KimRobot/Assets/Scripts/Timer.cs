using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int minute = 3;
    public int second = 1;

    public TextMesh TimerText;
    public GameObject Player;
    VRPlayerController PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = Player.GetComponent<VRPlayerController>();
        StartCoroutine(Time());
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = minute + ":" + second;
        if (second<10)
        {
            TimerText.text = minute + ":0" + second;
        }
         if(second<0)
        {
            minute--;
            second = 59;
            TimerText.text = minute + ":" + second;
        }
        if (minute<=3&&second==0)
        {
            PlayerController.TimerSound.Play();
            PlayerController.TimerSound2.Play();
        }
    }
    IEnumerator Time()
    {
        while (minute!=0)
        {
            yield return new WaitForSeconds(1f);
            second--;
        }
        
      
    }
}
