using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GCDataList : ISerializationCallbackReceiver
{
    [System.NonSerialized]
    public Vector3 position = Vector3.zero;

    [System.NonSerialized]
    public Quaternion rotationZ = Quaternion.identity;

    [System.NonSerialized]
    public float timeSinceLevelLoaded = 0;

    [System.NonSerialized]
    public Vector3 localScale = Vector3.one;

    //position
    [SerializeField]
    int x = 0;

    [SerializeField]
    int y = 0;

    [SerializeField]
    int z = 0;

    [SerializeField]
    Quaternion r = Quaternion.identity;

    //time and scale
    [SerializeField]
    int t = 0;

    [SerializeField]
    int s = 0;

    public GCDataList(Vector3 position_, Quaternion rotation_, Vector3 localScale_, float timeSinceSceneLoaded_)
    {
        position = position_;
        rotationZ = rotation_;
        localScale = localScale_;
        timeSinceLevelLoaded = timeSinceSceneLoaded_;
    }

    public void OnBeforeSerialize()
    {
        t = (int)(timeSinceLevelLoaded * 1000.0f); // * 1000.0f
        x = (int)(position.x * 1000.0f);
        y = (int)(position.y * 1000.0f);
        z = (int)(position.z * 1000.0f);

        s = (int)(localScale.x * 1000.0f);

        r = rotationZ;

    }

    public void OnAfterDeserialize()
    {
        timeSinceLevelLoaded = t / 1000.0f; // / 1000.0f
        position.x = x / 1000.0f;
        position.y = y / 1000.0f;
        position.z = z / 1000.0f;

        localScale = new Vector3(s / 1000.0f, s / 1000.0f, s / 1000.0f);

        rotationZ = r;
    }
}
