using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minRotation = -180f;
    [SerializeField] private float maxRotation = 180f;

    private float mouseX, mouseY;
    
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject keycard_yellow, keycard_purple;
    
    [SerializeField] private float interactionRange = 5f;
    [SerializeField] private TMP_Text pickupText;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Debug.DrawRay(transform.position, transform.forward*interactionRange, Color.red);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, 
            transform.forward*interactionRange, interactionRange);
        pickupText.text = "";
        foreach (RaycastHit hit in hits)
        {
            /*
            //Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag != "Untagged")
            {
                Debug.Log(hit.transform.gameObject.tag);
            }
            */
            if (hit.transform.gameObject.CompareTag("Gun"))
            {
                pickupText.text = "Press 'e' to pick up";
                if (Input.GetKeyUp(KeyCode.E))
                {
                    rifle.SetActive(true);
                    hit.transform.gameObject.SetActive(false);
                    break;
                } 
            }
            
            else if (hit.transform.gameObject.CompareTag("Dragable"))
            {
                pickupText.text = "Hold 'right click' to pick up";
                if (Input.GetMouseButton(1))
                {
                    hit.transform.position = transform.position + transform.forward * 1f;
                    break;
                }
            }
            
            else if (hit.transform.gameObject.CompareTag("Door"))
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    DoorButton doorBtn =  hit.transform.gameObject.GetComponent<DoorButton>();
                    if (!doorBtn.isOpen)
                    {
                        doorBtn.OpenDoor();
                    }
                    else
                    {
                        doorBtn.CloseDoor();
                    }
                }
            }
            
            else if (hit.transform.gameObject.CompareTag("PowerCenterScreen"))
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<PowerCubeComputer>().Interact();
                }
            }
            
            else if (hit.transform.gameObject.CompareTag("KeycardScreen"))
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    if (keycard_yellow.activeSelf)
                    {
                        hit.transform.gameObject.GetComponent<KeycardComputer>().Interact(keycard_yellow);
                    }
                    else if (keycard_purple.activeSelf)
                    {
                        hit.transform.gameObject.GetComponent<KeycardComputer>().Interact(keycard_purple);
                    }
                }
            }
            
            else if (hit.transform.gameObject.CompareTag("KeyCard"))
            {
                pickupText.text = "Press 'e' to pick up";
                if (Input.GetKeyUp(KeyCode.E))
                {
                    if (hit.transform.gameObject.name == "Keycard_Yellow") 
                    {
                        keycard_yellow.SetActive(true);
                        hit.transform.gameObject.SetActive(false);
                    }
                    else if (hit.transform.gameObject.name == "Keycard_Purple")
                    {
                        keycard_purple.SetActive(true);
                        hit.transform.gameObject.SetActive(false);
                    }
                }
            }
            
            else if (hit.transform.gameObject.CompareTag("SatelliteButton"))
            {
                if (Input.GetKeyUp(KeyCode.E))
                    hit.transform.gameObject.GetComponent<SatelliteComputerScript>().Interact();
            }
            
            else if (hit.transform.gameObject.CompareTag("LinkButton"))
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<CommunicationButtonScript>().Interact();
                }
            }
            
            else if (hit.transform.gameObject.CompareTag("Rocket"))
            {
                pickupText.text = "Press 'e' Take Off";
                if (Input.GetKeyUp(KeyCode.E))
                {
                    SceneManager.LoadScene(0);
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
