using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public GameObject PlayerObj;
    public VRPlayerController Player;
    public GameObject StartPlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
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
