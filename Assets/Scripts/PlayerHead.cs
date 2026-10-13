using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minRotation = -180f;
    [SerializeField] private float maxRotation = 180f;

    private float mouseX, mouseY;

    [SerializeField] private GameObject rifle;
    [SerializeField] private float interactionRange = 5f;

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);
        
        if (Input.GetKey(KeyCode.E))
        {
            if (!rifle.activeSelf)
            {
                RaycastHit[] hits;
                hits = Physics.RaycastAll(transform.position, transform.forward, interactionRange);
            
                foreach (RaycastHit hit in hits)
                {
                    if (hit.transform.gameObject.CompareTag("Gun"))
                    {
                        rifle.SetActive(true);
                        hit.transform.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
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
