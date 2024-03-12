using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectorData : MonoBehaviour
{
    public static CarSelectorData Instance;

    public int selectedCarIndex;

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
