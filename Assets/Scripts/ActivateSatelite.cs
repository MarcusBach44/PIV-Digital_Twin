using System;
using UnityEngine;

public class ActivateSatelite : MonoBehaviour
{
    [SerializeField] private GameObject satellite;
    private void OnCollisionEnter(Collision collision)
    {
        satellite.GetComponent<RotatingSatelite>().isRotating = true;
        gameObject.SetActive(false);
    }
}
