using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public enum MovePos { x, y, z };
    //public MovePos movePos;
    public enum Type { Letter, Number, Shape};
    public Type type;
    public string letter;
    Material material;
    public Material redMat;
    public bool isRed;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LineCollider")
        {
            //if (type == Type.Letter)
                gameObject.GetComponent<Renderer>().material = redMat;
                isRed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LineCollider")
        {
                gameObject.GetComponent<Renderer>().material = redMat;
                isRed = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LineCollider")
        {
                gameObject.GetComponent<Renderer>().material = material;
                isRed = false;
        }
    }
}