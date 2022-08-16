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
    public GameObject picture;//�����ִ� ��ũ�� ������Ʈ �ֱ�

    public GameObject door;
    public GameObject doorFrame;

    public GameObject[] room;
    public Material transparent;
    public Material glow;

    public GameObject timer;
    public GameObject gameRestart;

    public bool doorOpen;

    public PlayerController PlayerController;

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
        doorFrame.GetComponent<BoxCollider>().enabled = false;
    }
    public void Update()
    {
        if (timer.GetComponent<Timer>().minute == 0 && timer.GetComponent<Timer>().second == 0)
        {
            gameRestart.SetActive(true);
        }      

        if (lockImg.activeSelf)//��ũ���� ���������
        {
            LetterInput();
        }
        else//��ũ�� ��� �����϶�
        {
            NumberInput();

            if (doorOpen)//��ȣ�� ���� ��
            {
                doorOpen = false;
                for (int i = 0; i < room.Length; i++)
                {
                    room[i].GetComponent<Renderer>().material = transparent;
                }
                PlayerController.Neon.Play();
                doorFrame.GetComponent<Renderer>().material = glow;
                doorFrame.GetComponent<BoxCollider>().enabled = true;
                door.SetActive(false);
                //�ǹ��� ����ȭ, �� �׵θ��� ����, ���� ��Ƽ�� ����
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
            if(letter[1] == "��" && letter[0] == "��")
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
            if (number[1] == "2" && number[0] == "1")
            {
                doorOpen = true;
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
