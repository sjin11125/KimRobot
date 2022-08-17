using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string Main;
    public void OnStart()
    {
        SceneManager.LoadScene(Main);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
