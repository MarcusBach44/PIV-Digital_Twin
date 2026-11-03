using System;
using TMPro;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private TMP_Text popUpText;
    [SerializeField] private GameObject doorPoint;
    public bool isOpen = false;


    public void OpenDoor()
    {
        if (!generator.GetComponent<GeneratorScript>().isPowerOn)
        {
            return;
        }
        
        isOpen = true;
        //gameObject.SetActive(false);
        gameObject.transform.RotateAround(doorPoint.transform.position, Vector3.up, 90);
    }

    public void CloseDoor()
    {
        if (!generator.GetComponent<GeneratorScript>().isPowerOn)
        {
            return;
        }
        
        isOpen = false;
        //gameObject.SetActive(true);
        gameObject.transform.RotateAround(doorPoint.transform.position, Vector3.up, -90);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            popUpText.gameObject.SetActive(true);
            if (generator.GetComponent<GeneratorScript>().isPowerOn)
            {
                popUpText.text = "Press 'e' to open";
            }
            else
            {
                popUpText.text = "Needs Power";
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popUpText.gameObject.SetActive(false);
        }
    }
}
