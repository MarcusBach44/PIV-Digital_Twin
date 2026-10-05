using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private float sunRotationSpeed = 1f;

    [SerializeField] private GameObject rotationPoint;
    
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotationPoint.transform.position, Vector3.left, sunRotationSpeed * Time.deltaTime);
    }
}
