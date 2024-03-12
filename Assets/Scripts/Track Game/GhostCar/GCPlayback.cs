using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GCPlayback : MonoBehaviour
{

    GCData ghostCarData = new GCData();
    List<GCDataList> ghostCarDataList = new List<GCDataList>();
    public GameObject PlayerCar;

    int currentPlaybackIndex = 0;

    float lastStoredTime = 0;
    Vector3 lastStoredPos = Vector3.zero;
    Quaternion lastStoredRot = Quaternion.identity;
    Vector3 lastStoredLocalScale = Vector3.zero;

    float duration = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(ghostCarDataList.Count == 0)
        {
            return;
        }

        if (Time.timeSinceLevelLoad >= ghostCarDataList[currentPlaybackIndex].timeSinceLevelLoaded)
        {
            lastStoredTime = ghostCarDataList[currentPlaybackIndex].timeSinceLevelLoaded;
            lastStoredPos = ghostCarDataList[currentPlaybackIndex].position;
            lastStoredRot = ghostCarDataList[currentPlaybackIndex].rotationZ;
            lastStoredLocalScale = ghostCarDataList[currentPlaybackIndex].localScale;

            if (currentPlaybackIndex < ghostCarDataList.Count - 1)
            {
                currentPlaybackIndex++;
            }

            duration = ghostCarDataList[currentPlaybackIndex].timeSinceLevelLoaded - lastStoredTime;
        }

        float timePassed = Time.timeSinceLevelLoad - lastStoredTime; // GetComponent<LapTimer>().lapTime - lastStoredTime
        float lerpPercentage = timePassed / duration;

        transform.SetPositionAndRotation(Vector3.Lerp(lastStoredPos, ghostCarDataList[currentPlaybackIndex].position, lerpPercentage), Quaternion.Lerp(lastStoredRot, ghostCarDataList[currentPlaybackIndex].rotationZ, lerpPercentage));
        transform.localScale = Vector3.Lerp(lastStoredLocalScale, ghostCarDataList[currentPlaybackIndex].localScale, lerpPercentage);      
    }

    public void LoadData()
    {
        if (!PlayerPrefs.HasKey($"{SceneManager.GetActiveScene().name}_ghost"))
        {
            Destroy(gameObject);
        }
        else
        {
            string jsonEncodedData = PlayerPrefs.GetString($"{SceneManager.GetActiveScene().name}_ghost");

            ghostCarData = JsonUtility.FromJson<GCData>(jsonEncodedData);
            ghostCarDataList = ghostCarData.GetDataList();
        }
    }
}
