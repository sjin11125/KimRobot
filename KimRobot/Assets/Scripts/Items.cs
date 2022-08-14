using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    public GameObject letterItemParents;
    GameObject[] letters;

    public GameObject numberItemParents;
    GameObject[] numbers;

    public GameObject lockImg;
    public GameObject picture;

    public GameObject door;
    public GameObject doorFrame;

    public GameObject[] room;
    public Material transparent;
    public Material glow;

    public GameObject timer;
    public GameObject gameExit;
    public GameObject gameRestart;

    public bool doorOpen;

    private void Start()
    {
        letters = new GameObject[letterItemParents.transform.childCount];
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = letterItemParents.transform.GetChild(i).gameObject;
        }

        numbers = new GameObject[numberItemParents.transform.childCount];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numberItemParents.transform.GetChild(i).gameObject;
        }
    }
    public void Update()
    {
        if (timer.GetComponent<Timer>().minute == 0 && timer.GetComponent<Timer>().second == 0)
        {
            gameRestart.SetActive(true);
        }      

        if (lockImg.activeSelf)//스크린이 잠겨있을때
        {
            LetterInput();
        }
        else//스크린 잠금 해제일때
        {
            NumberInput();

            if (doorOpen)//번호를 맞춘 후
            {
                for (int i = 0; i < room.Length; i++)
                {
                    room[i].GetComponent<Renderer>().material = transparent;
                }
                doorFrame.GetComponent<Renderer>().material = glow;
                door.SetActive(false);
                //건물을 투명화, 문 테두리를 형광, 문을 엑티브 폴스
            }
        }
    }

    public void LetterInput()
    {
        List<string> letter = new List<string>();
        for (int i = 0; i < letters.Length; i++)
        {
            if(letters[i].GetComponent<Item>().isRed)
            {
                letter.Add(letters[i].GetComponent<Item>().letter);
            }
        }

        if (letter.Count == 2)
        {
            if(letter[1] == "연" && letter[0] == "인")
            {
                lockImg.SetActive(false);
                picture.SetActive(true);
            }
        }
    }

    public void NumberInput()
    {
        List<string> number = new List<string>();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].GetComponent<Item>().isRed)
            {
                number.Add(numbers[i].GetComponent<Item>().letter);
            }
        }

        if (number.Count == 2)
        {
            print(number[0]);
            if (number[1] == "2" && number[0] == "1")
            {
                doorOpen = true;
            }
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

    public void OnReTry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
