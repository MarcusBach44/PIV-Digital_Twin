using System;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public bool isPowerOn = false;
    [SerializeField] private GameObject energy;
    [SerializeField] private GameObject generator_1, generator_2;
    
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
            generator_1.GetComponent<ParticleSystem>().Play();
            generator_2.GetComponent<ParticleSystem>().Play();
        }
    }
}
