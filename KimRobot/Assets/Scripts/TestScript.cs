using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public LineRenderer line;
    private GameObject laserObj;

    public GameObject[] pointPrefab;

    void Update()
    {
        laserObj = GameObject.Find("Laser Beam");
        if(laserObj != null)
        {
            Vector3[] newPos = new Vector3[laserObj.GetComponent<LineRenderer>().positionCount];
            line.positionCount = laserObj.GetComponent<LineRenderer>().positionCount;
            laserObj.GetComponent<LineRenderer>().GetPositions(newPos);
            line.SetPositions(newPos);

            for (int i = 0; i < line.positionCount; i++)
            {
                pointPrefab[i].transform.position = newPos[i];
            }
        }

        if (ShootLaser.colliderExit)
        {
            for (int i = 0; i < pointPrefab.Length; i++)
            {
                pointPrefab[i].transform.position = Vector3.zero;
            }
            ShootLaser.colliderExit = false;
        }
    }
}
