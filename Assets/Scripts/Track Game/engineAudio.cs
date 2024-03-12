using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engineAudio : MonoBehaviour
{
    [SerializeField] private Car_Controller car_cntrl;
    [SerializeField] private AudioSource enigneAudio;

    private int Gearshiftlength = 30;
    private float pitchBoost = 0.8f;
    private float pitchRange = 2.5f;

    float Temp1;
    int Temp2;

    // Update is called once per frame
    void Update()
    {
        Temp1 = car_cntrl.KPH/ Gearshiftlength;
        Temp2 = (int)Temp1;

        float Differ = Temp1 - Temp2;

        enigneAudio.pitch = Mathf.Lerp(enigneAudio.pitch, (pitchRange * Differ)+ pitchBoost, .01f);

    }
}
