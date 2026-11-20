using System;
using TMPro;
using UnityEngine;

public class KeycardComputer : MonoBehaviour
{
    
    [SerializeField] private TMP_Text popUpText;
    
    [SerializeField] private GameObject playerKey1, playerKey2;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject keycard;
    [SerializeField] private Material finished;


    private void Start()
    {
        popUpText.text = "Insert Keycard";
    }

    public void Interact(GameObject playerKeycard)
    {
        if (playerKeycard.name == keycard.name)
        {
            keycard.SetActive(true);
            playerKeycard.SetActive(false);
            GetComponent<Renderer>().material = finished;
            popUpText.text = "Insert Another Keycard";
            if (CheckScreens())
            {
                popUpText.text = "Identification Complete";
            }
        }
    }
    
    private bool CheckScreens()
    {
        if (!playerKey1.activeSelf && !playerKey2.activeSelf)
        {
            gun.GetComponent<BoxCollider>().enabled = true;
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        popUpText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popUpText.gameObject.SetActive(false);
        }
    }
}
