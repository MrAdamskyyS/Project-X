using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadCarMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void loadTrackMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void loadTrackLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void loadEndGame()
    {
        SceneManager.LoadScene(4);
    }
}
