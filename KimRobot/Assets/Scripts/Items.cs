using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
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
                letter.GetComponent<Item>().TouchingBox();
            }
        }
        else
        {
            curLetters.Add(letter);
            letter.GetComponent<Item>().TouchingBox();
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
        }*/
    }
}
