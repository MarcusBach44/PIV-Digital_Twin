using System;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public bool isPowerOn = false;
    [SerializeField] private GameObject energy;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Power_Cube")
        {
            isPowerOn = true;
            animator.SetBool("isPowerOn",isPowerOn);
            energy.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
