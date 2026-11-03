using System;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject energy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Power_Cube")
        {
            energy.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
