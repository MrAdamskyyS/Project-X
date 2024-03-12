using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackMenuScript : MonoBehaviour
{
    [SerializeField] private Button prevBtn;
    [SerializeField] private Button nextBtn;
    private int currTrack;

    private void Awake()
    {
        TrackSelector(0);
    }
    private void TrackSelector(int index)
    {
        prevBtn.interactable = (index != 0);
        nextBtn.interactable = (index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void TrackChange(int change)
    {
        currTrack += change;
        TrackSelector(currTrack);
    }
}
