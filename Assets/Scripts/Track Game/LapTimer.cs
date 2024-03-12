using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour
{
    public float lapTime = 0;
    public float bestTime = 0;
    public int LapCount = 0;

    [SerializeField] private GameObject DataCalc;

    private bool isLapStarted = false;
    private bool Sector1;
    private bool Sector2;
    public Text timerText;
    public Text bestTimeText;
    public Text lapCountText;
    // Start is called before the first frame update
    void Start()
    {
        bestTimeText.text = "Najlepszy czas: " + bestTime.ToString("F2");
        timerText.text = "Czas okraz.: " + lapTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (isLapStarted == true)
        {
            lapTime = lapTime + Time.deltaTime;
            timerText.text = "Czas okraz.: " + lapTime.ToString("F2");
            lapCountText.text = "Okrazenie: " + LapCount;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "S/FCollider")
        {
            
            if (Sector1 == true && Sector2 == true)
            {
                isLapStarted = false;
                if(bestTime == 0)
                {
                    bestTime = lapTime;
                }
                if (lapTime < bestTime)
                {
                    bestTime = lapTime;
                }
                bestTimeText.text = "Najlepszy czas: " + bestTime.ToString("F2");
                LapCount++;
                GetComponent<Car_Controller>().isNitroReady = true;
                DataCalc.GetComponent<DataCalc>().addValues();

            }
        }
        
        if(other.gameObject.name == "S1Collider")
        {
            Sector1 = true;
        }
        if (other.gameObject.name == "S2Collider")
        {
            Sector2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isLapStarted == false)
        {
            isLapStarted = true;
            lapTime = 0;
            Sector1 = false;
            Sector2 = false;
        }
    }
}
