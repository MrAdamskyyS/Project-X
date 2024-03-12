using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject setPanel;
    public GameObject Tytul;
    public GameObject Dane;

    [SerializeField] private Slider mtrForceSlider;
    [SerializeField] private Slider brkForceSlider;
    [SerializeField] private Slider bstForceSlider;

    [SerializeField] private Text mtrForceText;
    [SerializeField] private Text brkForceText;
    [SerializeField] private Text bstForceText;

    public void Update()
    {
        SettingsDataCollector.Instance.motorForceValue = mtrForceSlider.value;
        SettingsDataCollector.Instance.brakeForceValue = brkForceSlider.value;
        SettingsDataCollector.Instance.boostForceValue = bstForceSlider.value;

        mtrForceText.text = mtrForceSlider.value.ToString();
        brkForceText.text = brkForceSlider.value.ToString();
        bstForceText.text = bstForceSlider.value.ToString();

    }

    public void options()
    {
        setPanel.SetActive(true);
        Tytul.SetActive(false);
        Dane.SetActive(false);
    }

    public void closeOpts()
    {
        setPanel.SetActive(false);
        Tytul.SetActive(true);
        Dane.SetActive(true);
    }

    public void gameExit()
    {
        Application.Quit();
    }
}
