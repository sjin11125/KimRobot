using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + offset;
        transform.position = newPosition;
        transform.LookAt(player);
    }
}
