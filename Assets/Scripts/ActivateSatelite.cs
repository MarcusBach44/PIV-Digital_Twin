using System;
using UnityEngine;

public class ActivateSatelite : MonoBehaviour
{
    [SerializeField] private GameObject satellite;
    private void OnTriggerEnter(Collider other)
    {
        satellite.GetComponent<RotatingSatelite>().isRotating = true;
        gameObject.SetActive(false);
    }
}
