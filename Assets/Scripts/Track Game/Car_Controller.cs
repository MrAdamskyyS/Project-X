using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class Car_Controller : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    public float currentbreakForce;
    private bool isBreaking;
    private int gearNum;
    public float KPH;
    public bool isNitroReady;
    private float nitroDuration = 3f;

    private float motorForce = SettingsDataCollector.Instance.motorForceValue;
    private float breakForce = SettingsDataCollector.Instance.brakeForceValue;
    private float boostForce = SettingsDataCollector.Instance.boostForceValue;
    private float maxSteerAngle = 30.0f;

    private new Rigidbody rigidbody;
    [SerializeField] private Image nosSprite;
    [SerializeField] private Sprite nosGreenSprite;
    [SerializeField] private Sprite nosRedSprite;
    [SerializeField] private GameObject nitroParticles;
    [SerializeField] private List<WheelCollider> WheelCollider;
    [SerializeField] private List<Transform> WheelTransform;
    [SerializeField] private Text kph;
    [SerializeField] private Text gear;
    [SerializeField] private Slider kphSlider;
    [SerializeField] private Slider motorForceSlider;
    [SerializeField] private Slider breakForceSlider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        kphSlider.maxValue = 280;
        breakForceSlider.maxValue = breakForce;
        motorForceSlider.maxValue = motorForce;
        isNitroReady = true;    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isNitroReady)
        {
            nitroBoost(boostForce);
        }
        if (isNitroReady)
        {
            nosSprite.sprite = nosGreenSprite;
        }
        else
        {
            nosSprite.sprite = nosRedSprite;
        }
    }


    private void FixedUpdate()
    {    
        GetInput();
        HandleMotor(motorForce);
        HandleSteering();
        UpdateWheels();
        kphCalculator();
        gearShifter();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor(float motorForce)
    {
        motorForceSlider.value = verticalInput * motorForce;
        WheelCollider[2].motorTorque = verticalInput * motorForce;
        WheelCollider[3].motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        breakForceSlider.value = currentbreakForce;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        WheelCollider[1].brakeTorque = currentbreakForce;
        WheelCollider[0].brakeTorque = currentbreakForce;
        WheelCollider[2].brakeTorque = currentbreakForce;
        WheelCollider[3].brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        WheelCollider[0].steerAngle = currentSteerAngle;
        WheelCollider[1].steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(WheelCollider[0], WheelTransform[0]);
        UpdateSingleWheel(WheelCollider[1], WheelTransform[1]);
        UpdateSingleWheel(WheelCollider[3], WheelTransform[3]);
        UpdateSingleWheel(WheelCollider[2], WheelTransform[2]);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    } 
    
    private void kphCalculator()
    {
        KPH = rigidbody.velocity.magnitude * 3.6f;
        kph.text = KPH.ToString("F0") + " KM/H";
        kphSlider.value = KPH;
    }

    private void gearShifter()
    {
        if (KPH <= 30)
        {
            gearNum = 1;
        }
        else if (KPH > 30 && KPH <= 60)
        {
            gearNum = 2;
        }
        else if (KPH > 60 && KPH <= 90)
        {
            gearNum = 3;
        }
        else if (KPH > 90 && KPH <= 120)
        {
            gearNum = 4;
        }
        else if (KPH > 120 && KPH <= 150)
        {
            gearNum = 5;
        }
        else if (KPH > 150 && KPH <= 180)
        {
            gearNum = 6;
        }
        else if (KPH > 210)
        {
            gearNum = 7;
        }
        gear.text = "Bieg: " + gearNum;
    }

    public void nitroBoost(float boostForce)
    {
        isNitroReady = false;
        rigidbody.velocity = transform.forward * (KPH + boostForce)/3.6f;
        nitroParticles.SetActive(true);
        Invoke("ResetSpeed", nitroDuration);
    }
    void ResetSpeed()
    {
        nitroParticles.SetActive(false);
        rigidbody.velocity = transform.forward * KPH / 3.6f;
    }
}