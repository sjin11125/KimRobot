using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    public GameObject lockImg;
    public GameObject picture;

    public GameObject door;
    public GameObject doorFrame;

    public GameObject room;
    public GameObject ground;
    public GameObject roof;
    public Material transparent;
    public Material glow;

    public GameObject timer;
    public GameObject gameExit;
    public GameObject gameRestart;

    public bool doorOpen;

    //��ũ�� �� ���������� ���� �������� �ؾߵ�
    public void LetterInput(string letter1, string letter2)
    {
        if(letter1 == "��" && letter2 == "��")
        {
            lockImg.SetActive(false);
            picture.SetActive(true);
        }
    }

    public void NumberInput(string number1, string number2)
    {
        if (number1 ==  "1" && number2 == "1")
        {
            //�ǹ��� ����ȭ, �� �׵θ��� ����, ���� ��Ƽ�� ����
            doorOpen = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (door.activeSelf == false)
        {
            if (collision.gameObject.name == "doorFrame")
            {
                gameExit.SetActive(true);
            }
        }
    }

    public void Update()
    {
        if( timer.GetComponent<Timer>().minute==0 && timer.GetComponent<Timer>().second == 0)
        {
            gameRestart.SetActive(true);
        }

        if (doorOpen)
        {
            room.GetComponent<Renderer>().material = transparent;
            ground.GetComponent<Renderer>().material = transparent;
            roof.GetComponent<Renderer>().material = transparent;
            doorFrame.GetComponent<Renderer>().material = glow;
            door.SetActive(false);
        }
    }

    public void OnReTry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
    /*
    GameObject[] letters = new GameObject[10];
    List<GameObject> curLetters;

    void Start()
    {
        curLetters = new List<GameObject>();
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = transform.GetChild(i).gameObject;
        }
    }

    public void GetLetters(GameObject letter)
    {
        if (curLetters.Count > 0)
        {
            if (curLetters[curLetters.Count-1] != letter)
            {
                curLetters.Add(letter);
                //letter.GetComponent<Item>().TouchingBox();
            }
        }
        else
        {
            curLetters.Add(letter);
            //letter.GetComponent<Item>().TouchingBox();
        }

        /*
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].GetComponent<Item>().hit = false;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            for (int j = 0; j < curLetters.Count; j++)
            {
                if (letters[i] == curLetters[j])
                {
                    letters[j].GetComponent<Item>().hit = true;
                    print(letters[j]);
                }
            }
        }
    }*/
}
