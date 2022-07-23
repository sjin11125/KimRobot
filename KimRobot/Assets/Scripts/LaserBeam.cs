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
        CastRay(pos,dir,laser);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 30, 1))
        {
            //CheckHit(hit, dir, laser);

            if (thisColor == "Green")
            {
                CheckHit(hit, dir, laser);
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

    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag != null)
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }
}
