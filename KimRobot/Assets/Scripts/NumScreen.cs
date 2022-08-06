using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumScreen : MonoBehaviour
{
    string Password = "QWERT";
    string CurPassword = "";

    public Text PasswordText;   
    

    // Update is called once per frame
    void Update()
    {
        if ( PasswordText.text.Length>=5)
        {
            if (PasswordText.text==Password)
            {
                Debug.Log("Á¤´ä!");
            }
            else
            PasswordText.text = "";
        }
    }
}
