using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMng : MonoBehaviour
{
    [SerializeField] private GameObject graphPanel;
    [SerializeField] private GameObject timesScrollView;
    [SerializeField] private Text lapandtimesText;
    [SerializeField] private GameObject textWyniki;
    [SerializeField] private GameObject graphBtn;
    [SerializeField] private GameObject menuBtn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CollectLap.Instance.laps.Count; i++)
        {
            lapandtimesText.text += " " + CollectLap.Instance.laps[i] + ". " + CollectLap.Instance.lapTimes[i] + " sekund\n";
        }
    }

    public void showGraph()
    {
        graphPanel.SetActive(true);
        timesScrollView.SetActive(false);
        textWyniki.SetActive(false);
        graphBtn.SetActive(false);
        menuBtn.SetActive(false);
    }

    public void hideGraph()
    {
        graphPanel.SetActive(false);
        timesScrollView.SetActive(true);
        textWyniki.SetActive(true);
        graphBtn.SetActive(true);
        menuBtn.SetActive(true);
    }

}
