using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDataCollector : MonoBehaviour
{
    public static SettingsDataCollector Instance;

    public float motorForceValue;
    public float brakeForceValue;
    public float boostForceValue;

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
