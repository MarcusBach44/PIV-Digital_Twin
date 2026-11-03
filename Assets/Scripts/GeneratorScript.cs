using System;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public bool isPowerOn = false;
    [SerializeField] private GameObject energy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Power_Cube")
        {
            isPowerOn = true;
            energy.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
