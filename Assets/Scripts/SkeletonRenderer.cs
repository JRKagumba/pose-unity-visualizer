using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRenderer : MonoBehaviour
{
    public PoseParser poseParser;       // Reference to PoseParser
    public GameObject linePrefab;       // LineRenderer prefab
    private LineRenderer[] boneLines;

    private readonly int[,] bones = new int[,]
    {
        {0,1}, {1,2}, {2,3}, {3,4}, {0,5}, {5,6}, {6,7},
        {9,8}, {10,9},
        {11,12},
        {11,13}, {13,15}, {15,17}, {15,19}, {15,21},
        {12,14}, {14,16}, {14,18}, {14,20}, {14,22},
        {11,23}, {12,24},
        {23,25}, {25,27}, {27,29}, {29,31},
        {24,26}, {26,28}, {28,30}, {30,32}
    };

    void Start()
    {
        boneLines = new LineRenderer[bones.GetLength(0)];
        for (int i = 0; i < bones.GetLength(0); i++)
        {
            GameObject lineObj = Instantiate(linePrefab);
            boneLines[i] = lineObj.GetComponent<LineRenderer>();
            boneLines[i].positionCount = 2;
        }
    }

    void Update()
    {
        if (poseParser == null || poseParser.joints == null)
            return;

        GameObject[] joints = poseParser.joints;

        for (int i = 0; i < bones.GetLength(0); i++)
        {
            int indexA = bones[i, 0];
            int indexB = bones[i, 1];

            if (indexA < joints.Length && indexB < joints.Length && joints[indexA] != null && joints[indexB] != null)
            {
                boneLines[i].SetPosition(0, joints[indexA].transform.position);
                boneLines[i].SetPosition(1, joints[indexB].transform.position);
            }
        }
    }
}

