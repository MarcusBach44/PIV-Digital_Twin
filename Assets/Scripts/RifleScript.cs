using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPoint;

    [SerializeField] private float rateOfFire = 1f;
    private float cooldown = 0;
    
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletLifeTime = 3f;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && cooldown <= 0)
        {
            animator.SetBool("IsShooting", true);
            cooldown = rateOfFire;
            GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
            
            bulletSctipt bs = bullet.GetComponent<bulletSctipt>();
            bs.bulletSpeed = bulletSpeed;
            bs.lifeTime = bulletLifeTime;
        }
        cooldown -= Time.deltaTime;
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsShooting",  false);
        }
    }

    
}
