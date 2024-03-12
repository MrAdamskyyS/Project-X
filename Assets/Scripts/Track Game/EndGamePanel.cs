using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    public GameObject Endgamepanel;

    public void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Endgamepanel.SetActive(true);
        }
    }

    public void backtoGame()
    {
        Endgamepanel.SetActive(false);
    }

}
