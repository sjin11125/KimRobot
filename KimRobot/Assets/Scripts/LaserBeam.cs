using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserIndices = new List<Vector3>();

    string thisColor;

    public LaserBeam(Vector3 pos, Vector3 dir, Material material, string LaserColor)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        thisColor = LaserColor;
        if (thisColor == "Green")
        {
            this.laser.startColor = Color.green;
            this.laser.endColor = Color.green;
        }
        else if (thisColor == "Red")
        {
            this.laser.startColor = Color.red;
            this.laser.endColor = Color.red;
        }
        else if (thisColor == "Yellow")
        {
            this.laser.startColor = Color.yellow;
            this.laser.endColor = Color.yellow;
        }
        CastRay(pos,dir,laser);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 30, 1))
        {
            if (thisColor == "Green")
            {
                CheckHit(hit, dir, laser);
            }
            else if (thisColor == "Red")
            {
                CheckHit(hit, dir, laser);
            }
            else if (thisColor == "Yellow")
            {
                BoxHit(hit);
            }
            else
            {
                laserIndices.Add(hit.point);
                UpdateLaser();
            }
        }
        else
        {
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector3 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    int count = 0;
    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag == "Wall" || hitInfo.collider.gameObject.tag == "Box")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
            count++;
            if (count < 5)//�ټ��� �̻� �ݻ���� �ʴ´�
            {
                CastRay(pos, dir, laser);
            }
            else
            {
                laserIndices.Add(hitInfo.point);
                UpdateLaser();
            }
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }

    void BoxHit(RaycastHit hitInfo)
    {
        if (hitInfo.collider.gameObject.tag == "Box")
        {
            hitInfo.collider.transform.parent = GameObject.FindWithTag("Pivot").transform;
        }
        laserIndices.Add(hitInfo.point);
        UpdateLaser();
    }
}
