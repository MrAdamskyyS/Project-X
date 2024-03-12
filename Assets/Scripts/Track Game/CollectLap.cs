using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLap : MonoBehaviour
{
    public static CollectLap Instance;

    public List<float> speeds;
    public List<float> brakes;
    public List<float> lapTimes;
    public List<int> laps;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
