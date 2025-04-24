using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseToRig : MonoBehaviour
{
    public PoseParser poseParser;

    public Transform leftShoulder, leftElbow, leftWrist;
    public Transform rightShoulder, rightElbow, rightWrist;
    public Transform leftHip, leftKnee, leftAnkle;
    public Transform rightHip, rightKnee, rightAnkle;
    public Transform head;

    void Update()
    {
        if (poseParser == null || poseParser.joints == null || poseParser.joints.Length < 33)
            return;

        // Example: align left upper arm (shoulder to elbow)
        Vector3 upperArm = poseParser.joints[13].transform.position - poseParser.joints[11].transform.position;
        leftShoulder.forward = upperArm;

        // Do the same for each limb segment...
    }
}

