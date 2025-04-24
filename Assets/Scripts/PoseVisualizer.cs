using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseVisualizer : MonoBehaviour
{
    public PoseParser poseParser;

    void Update()
    {
        if (poseParser == null || poseParser.joints == null) return;

        // Optionally: add any logic here to work with the joints
        for (int i = 0; i < poseParser.joints.Length; i++)
        {
            if (poseParser.joints[i] != null)
            {
                // Just for demonstration: draw debug spheres or lines if needed
                Debug.DrawRay(poseParser.joints[i].transform.position, Vector3.up * 0.05f, Color.green);
            }
        }
    }
}
