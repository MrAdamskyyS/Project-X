using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMenuAnim : MonoBehaviour
{
    private Vector3 initPos;
    [SerializeField] private Vector3 finalPos;

    private void Awake()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPos, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = initPos;
    }
}
