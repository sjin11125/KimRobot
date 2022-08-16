using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueUI : MonoBehaviour
{
    public GameObject Player;
    RectTransform rect;
    public string ClueString;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.LookAt(Player.transform.position);
    }
}
