using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject letterItemParents;
    GameObject[] letters;

    public GameObject numberItemParents;
    GameObject[] numbers;

    public GameObject Quiz;
    public GameObject StarZero;
    public GameObject numberZero;
    public GameObject StarOne;
    public GameObject numberOne;
    public GameObject StarTwo;
    public GameObject numberTwo;
    public Material redMat;
    Material normalMat;
    int count;

    public GameObject lockImg;
    public GameObject picture;//사진있는 스크린 오브젝트 넣기

    public GameObject hallway;
    public GameObject door;
    public GameObject doorFrame;
    public GameObject star;
    public GameObject[] room;
    public Material transparent;
    public Material glow;
    public bool doorOpen;
    public AudioSource switchDown;
    public PlayerController player;

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
        numberItemParents.SetActive(false);
        Quiz.SetActive(false);
        normalMat = StarZero.GetComponent<Renderer>().material;
    }
    public void Update()
    {
        if (lockImg.activeSelf)//스크린이 잠겨있을때
        {
            LetterInput();
        }
        else//스크린 잠금 해제일때
        {
            if (!numberZero.activeSelf)
            {
                NumberZeroInput();
            }
            else
            {
                if (!numberOne.activeSelf && count < ShootLaser.count)
                {
                    NumberOneInput();
                }
                else
                {
                    if (!numberTwo.activeSelf && count < ShootLaser.count)
                    {
                        NumberTwoInput();
                    }
                    else
                    {
                        if (!doorOpen)
                        {
                            NumberInput();
                        }
                        else
                        {
                            switchDown.Play();
                            //여기에 차단기 내려가는듯한 효과음넣기
                            for (int i = 0; i < room.Length; i++)
                            {
                                room[i].GetComponent<Renderer>().material = transparent;
                            }
                            doorFrame.GetComponent<Renderer>().material = glow;
                            hallway.SetActive(false);
                            doorFrame.GetComponent<BoxCollider>().enabled = true;
                            door.SetActive(false);
                            star.SetActive(true); //별 켜기
                            //건물을 투명화, 문 테두리를 형광, 문을 엑티브 폴스
                            numberItemParents.SetActive(false);
                            Quiz.SetActive(false);                           
                        }
                    }
                }
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
                player.Screen.Play();
                lockImg.SetActive(false);
                picture.SetActive(true);
                letterItemParents.SetActive(false);
                numberItemParents.SetActive(true);
                Quiz.SetActive(true);
                StarZero.GetComponent<Renderer>().material = redMat;
            }
            else if (letter[0] == "연" && letter[1] == "인")
            {
                player.Screen.Play();
                lockImg.SetActive(false);
                picture.SetActive(true);
                letterItemParents.SetActive(false);
                numberItemParents.SetActive(true);
                Quiz.SetActive(true);
                StarZero.GetComponent<Renderer>().material = redMat;
            }
        }
    }

    public void NumberZeroInput()
    {
        string number = "";
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].GetComponent<Item>().isRed)
            {
                number = numbers[i].GetComponent<Item>().letter;
            }
        }

        if (number == "4")
        {
            count = ShootLaser.count;
            StarZero.SetActive(false);
            numberZero.SetActive(true);
            StarOne.GetComponent<Renderer>().material = redMat;
        }
    }

    public void NumberOneInput()
    {
        string number = "";
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].GetComponent<Item>().isRed)
            {
                number = numbers[i].GetComponent<Item>().letter;
            }
        }
        if (number == "4")
        {
            count = ShootLaser.count;
            StarOne.SetActive(false);
            numberOne.SetActive(true);
            StarTwo.GetComponent<Renderer>().material = redMat;
            
        }
        if (number == "1")
        {
            StarZero.SetActive(true);
            numberZero.SetActive(false);
            StarOne.GetComponent<Renderer>().material = normalMat;
        }
        if (number == "2")
        {
            StarZero.SetActive(true);
            numberZero.SetActive(false);
            StarOne.GetComponent<Renderer>().material = normalMat;
        }
         if (number == "0")
        {
            StarZero.SetActive(true);
            numberZero.SetActive(false);
            StarOne.GetComponent<Renderer>().material = normalMat;
        }
    }

    public void NumberTwoInput()
    {
        string number = "";
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].GetComponent<Item>().isRed)
            {
                number = numbers[i].GetComponent<Item>().letter;
            }
        }

        if (number == "2")
        {
            StarTwo.SetActive(false);
            numberTwo.SetActive(true);
        }
        else if(number == "1")
        {
            StarZero.SetActive(true);
            numberZero.SetActive(false);
            StarOne.GetComponent<Renderer>().material = normalMat;
            StarOne.SetActive(true);
            numberOne.SetActive(false);
            StarTwo.GetComponent<Renderer>().material = normalMat;
        }
        else if (number == "4")
        {
            StarZero.SetActive(true);
            numberZero.SetActive(false);
            StarOne.GetComponent<Renderer>().material = normalMat;
            StarOne.SetActive(true);
            numberOne.SetActive(false);
            StarTwo.GetComponent<Renderer>().material = normalMat;
        }
        else if (number == "0")
        {
            StarZero.SetActive(true);
            numberZero.SetActive(false);
            StarOne.GetComponent<Renderer>().material = normalMat;
            StarOne.SetActive(true);
            numberOne.SetActive(false);
            StarTwo.GetComponent<Renderer>().material = normalMat;
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
            if (number[1] == "4" && number[0] == "1")
            {
                doorOpen = true;
            }
            else if(number[0] == "1" && number[1] == "4")
            {
                doorOpen = true;
            }
        }
    } 
}
