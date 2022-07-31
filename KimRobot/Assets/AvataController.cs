using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class    MapTranforms
{
    public Transform vrTarget;
    public Transform ikTarget;

    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void VRMapping()
    {
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}
public class AvataController : MonoBehaviour
{
    [SerializeField] private MapTranforms head;
    [SerializeField] private MapTranforms leftHand;
    [SerializeField] private MapTranforms rightHand;

    [SerializeField] private float turnSmoothness;
    [SerializeField] Transform ikHead;
    [SerializeField] Vector3 headBodyOffset;

    private void LateUpdate()
    {
        transform.position = ikHead.position + headBodyOffset;
        transform.forward =Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(ikHead.forward,Vector3.up).normalized,Time.deltaTime*turnSmoothness);

        head.VRMapping();
        leftHand.VRMapping();
        rightHand.VRMapping();


    }

}
