using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CarMenu : MonoBehaviour
{
    [SerializeField] private Button prevBtn;
    [SerializeField] private Button nextBtn;
    public int currCar;

    private void Awake()
    {
        CarSelector(0);
    }
    private void CarSelector(int index)
    {
        prevBtn.interactable = (index != 0);
        nextBtn.interactable = (index != transform.childCount-1);
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void CarChange(int change)
    {
        currCar += change;
        CarSelectorData.Instance.selectedCarIndex = currCar;
        CarSelector(currCar);
    }
}
