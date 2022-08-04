using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int minute = 10;
    public int second = 10;

    public TextMesh TimerText;
    // Start is called before the first frame update
    void Start()
    {
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
