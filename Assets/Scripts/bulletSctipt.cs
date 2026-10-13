using System.Collections;
using UnityEngine;

public class bulletSctipt : MonoBehaviour
{
    public float lifeTime;
    public float bulletSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletSpeed;
        StartCoroutine(DestroyBullet(gameObject));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(bullet);
    }
}
