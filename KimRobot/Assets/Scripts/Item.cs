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
    public Material blue;
    //public bool hit;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Laser Beam")
        {
            print("enter");
            if (type == Type.Letter)
            {
                gameObject.GetComponent<Renderer>().material = blue;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Laser Beam")
        {
            print("exit");
            if (type == Type.Letter)
            {
                gameObject.GetComponent<Renderer>().material = material;
            }
        }
    }
    /*
    public void TouchingBox()
    {
        if (movePos == MovePos.z)
        {
            Vector3 pos = new Vector3(transform.localPosition.x, transform.localPosition.y, 1.5f);
            //transform.localPosition = pos;
            gameObject.GetComponent<Renderer>().material = blue;
        }
    }

    public void ExitBox()
    {
        if (movePos == MovePos.z)
        {
            Vector3 pos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
            //transform.localPosition = pos;
            gameObject.GetComponent<Renderer>().material = material;
        }
    }*/
}