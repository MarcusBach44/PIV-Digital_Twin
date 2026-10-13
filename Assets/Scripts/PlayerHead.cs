using System;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minRotation = -180f;
    [SerializeField] private float maxRotation = 180f;

    private float mouseX, mouseY;

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        float yRotation = mouseX * sensitivity;
        float xRotation = -mouseY * sensitivity;
        
        if (yRotation != 0f || xRotation != 0f)
        {
            transform.eulerAngles += new Vector3(xRotation, yRotation, 0f);
            float rotationLock = transform.eulerAngles.x;
            if (rotationLock > 180)
            {
                rotationLock -= 360;
            }
            rotationLock = Mathf.Clamp(rotationLock, minRotation, maxRotation);
            transform.eulerAngles = new Vector3(rotationLock, 
                transform.eulerAngles.y, 
                transform.eulerAngles.z);
        }
    }
}
