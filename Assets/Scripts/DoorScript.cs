using System;
using TMPro;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private TMP_Text popUpText;
    [SerializeField] private GameObject doorPoint;
    public bool isOpen = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (!generator.GetComponent<GeneratorScript>().isPowerOn)
        {
            return;
        }
        
        isOpen = true;
        animator.SetBool("IsOpen", true);
    }

    public void CloseDoor()
    {
        if (!generator.GetComponent<GeneratorScript>().isPowerOn)
        {
            return;
        }
        
        isOpen = false;
        animator.SetBool("IsOpen", false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            
            if (!generator.GetComponent<GeneratorScript>().isPowerOn)
            {
                popUpText.gameObject.SetActive(true);
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
