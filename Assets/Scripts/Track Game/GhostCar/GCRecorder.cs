using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GCRecorder : MonoBehaviour
{

    public Transform carObject;
    public GameObject GCarPrefab;

    GCData ghostCarData  = new GCData();

    bool isRecording = true;

    Rigidbody carRB;
    GameObject ghostCar;
    string jsonEncodedData;

    private void Awake()
    {
        carRB = GetComponent<Rigidbody>();
        //PlayerPrefs.DeleteKey($"{SceneManager.GetActiveScene().name}_ghost");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GCarCall()
    {
        ghostCar = Instantiate(GCarPrefab);
        ghostCar.GetComponent<GCPlayback>().LoadData();
    }

    public void GCarDestroy()
    {
        Destroy(ghostCar);
    }

    //korutyna
    public IEnumerator RecordCarPosCor()
    {
        while (isRecording)
        {
            if (carObject != null)
            {
                ghostCarData.AddDataItem(new GCDataList(carRB.position, carRB.rotation, carObject.localScale, Time.timeSinceLevelLoad)); //GetComponent<LapTimer>().lapTime
            }
            yield return new WaitForSeconds(0.15f);  
        }
    }
    public void SaveData()
    {

        jsonEncodedData = JsonUtility.ToJson(ghostCarData);

        Debug.Log($"Dane {jsonEncodedData}");

        PlayerPrefs.SetString($"{SceneManager.GetActiveScene().name}_ghost", jsonEncodedData);
        PlayerPrefs.Save();
    }
}
