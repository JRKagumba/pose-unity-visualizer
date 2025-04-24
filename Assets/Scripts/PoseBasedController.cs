using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseBasedController : MonoBehaviour
{
    public PoseParser poseParser;
    public GameObject leftCube;
    public GameObject rightCube;

    void Update()
    {
        // Ensure joint data is available and complete
        if (poseParser.joints == null || poseParser.joints.Length < 33)
            return;

        // Get wrist transforms from joints
        Transform leftWrist = poseParser.joints[15].transform;
        Transform rightWrist = poseParser.joints[16].transform;

        if (leftWrist != null)
        {
            float leftHeight = leftWrist.position.y;
            leftCube.transform.position = new Vector3(
                leftCube.transform.position.x,
                leftHeight * 2f,
                leftCube.transform.position.z
            );
        }

        if (rightWrist != null)
        {
            float rightHeight = rightWrist.position.y;
            rightCube.transform.position = new Vector3(
                rightCube.transform.position.x,
                rightHeight * 2f,
                rightCube.transform.position.z
            );
        }
    }
}
