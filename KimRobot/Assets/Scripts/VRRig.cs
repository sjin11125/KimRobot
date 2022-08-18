using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);

        
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
    public void PrintPosition()
    {
        Debug.Log("오른손 위치: " + rigTarget.rotation);
    }
}

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;

    VRPlayerController playerController;
    Animator animator;

    private void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
        playerController = transform.parent.GetComponent<VRPlayerController>();
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;
       // transform.forward =Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized,Time.deltaTime*5); //머리 회전을 y축으로만 하도록 허용

        head.Map();
        leftHand.Map();
        rightHand.Map();
        // rightHand.PrintPosition();
        if (playerController!=null)
        {
            if (playerController.isWalk)                    //걷고있냐
            {
                animator.SetBool("IsWalk", true);
            }
            else
            {
                animator.SetBool("IsWalk", false);
            }
        }
  
    }
}