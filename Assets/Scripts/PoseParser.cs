using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseParser : MonoBehaviour
{
    public UDPReceiver udpReceiver;
    public GameObject jointPrefab;
    public GameObject[] joints;

    void Start()
    {
        joints = new GameObject[33];
        for (int i = 0; i < joints.Length; i++)
        {
            joints[i] = Instantiate(jointPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    void Update()
    {
        string data = udpReceiver.lastReceivedUDPPacket;

        if (!string.IsNullOrEmpty(data))
        {
            Debug.Log($"[PoseParser] Raw data received: {data.Substring(0, Mathf.Min(100, data.Length))}"); // first 100 chars

            string[] values = data.Split(',');
            int maxPoints = Mathf.Min(joints.Length, values.Length / 3);

            for (int i = 0; i < maxPoints; i++)
            {
                try
                {
                    float x = float.Parse(values[i * 3]);
                    float y = float.Parse(values[i * 3 + 1]);
                    float z = float.Parse(values[i * 3 + 2]);

                    Vector3 pos = new Vector3(x, -y, -z);
                    joints[i].transform.position = pos;

                    Debug.Log($"[PoseParser] Joint {i} -> Position: {pos}");
                }
                catch
                {
                    Debug.LogWarning($"Invalid landmark at index {i}: {values[i * 3]}, {values[i * 3 + 1]}, {values[i * 3 + 2]}");
                }
            }
        }
    }


    //void Update()
    //{
    //    // TEMPORARY DUMMY DATA FOR DEBUGGING
    //    if (joints == null || joints.Length != 33)
    //        return;

    //    for (int i = 0; i < joints.Length; i++)
    //    {
    //        float angle = i * Mathf.PI * 2 / joints.Length;
    //        float radius = 1.0f;

    //        float x = Mathf.Cos(angle) * radius;
    //        float y = Mathf.Sin(angle) * radius;
    //        float z = 0; // keep flat in 2D plane for now

    //        joints[i].transform.position = new Vector3(x, y, z);
    //    }
    //}

}

