using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    [SerializeField] private GameObject LeftBackLight;
    [SerializeField] private GameObject RightBackLight;

    // Start is called before the first frame update
    void Start()
    {
        LeftBackLight.SetActive(false);
        RightBackLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LeftBackLight.SetActive(true);
            RightBackLight.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            LeftBackLight.SetActive(false);
            RightBackLight.SetActive(false);
        }
    }
}
