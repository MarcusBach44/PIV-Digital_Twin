using System;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dragable"))
        {
            other.transform.position = new Vector3(spawnPosition.position.x, spawnPosition.position.y+0.5f, other.transform.position.z);
        }
    }
}
