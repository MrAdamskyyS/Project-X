using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    private Vector3 targetPosition;
    private Vector3 direction;
    private Quaternion rotation;
    private float translateSpeed = 10;
    private float rotationSpeed = 10;
    public new Camera camera;
    private float fieldOfView;

    private void Start()
    { 
        fieldOfView = camera.fieldOfView;
    }

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        
        targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        direction = target.position - transform.position;
        rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}