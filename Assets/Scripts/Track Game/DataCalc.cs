using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCalc : MonoBehaviour
{

    [SerializeField] private Car_Controller carCon;
    [SerializeField] private LapTimer lapT;

    private void Awake()
    {
        StartCoroutine(graphValues());
    }
    public IEnumerator graphValues()
    {
        while (true)
        {
            CollectLap.Instance.speeds.Add(carCon.KPH);
            CollectLap.Instance.brakes.Add(carCon.currentbreakForce);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void addValues()
    {
        CollectLap.Instance.laps.Add(lapT.LapCount);
        CollectLap.Instance.lapTimes.Add(lapT.lapTime);
    }

}
