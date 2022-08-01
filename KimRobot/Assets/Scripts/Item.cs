using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum MovePos { x, y, z };
    public MovePos movePos;
    public string letter;
    Material material;
    public Material blue;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void TouchingBox()
    {
        if(movePos == MovePos.z)
        {
            Vector3 pos = new Vector3(transform.localPosition.x, transform.localPosition.y, 4);
            transform.localPosition = pos;
            gameObject.GetComponent<Renderer>().material = blue;
        }
    }

    public void ExitBox()
    {
        if (movePos == MovePos.z)
        {
            Vector3 pos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            transform.localPosition = pos;
            gameObject.GetComponent<Renderer>().material = material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "감지 시작!");
    }

    // Collider 컴포넌트의 is Trigger가 true인 상태로 충돌중일 때
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name + "감지 중!");
    }

    // Collider 컴포넌트의 is Trigger가 true인 상태로 충돌이 끝났을 때
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "감지 끝!");
    }
}
