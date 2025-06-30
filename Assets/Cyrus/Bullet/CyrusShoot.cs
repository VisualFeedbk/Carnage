using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyrusShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.3f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Missing bulletPrefab or firePoint!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Flip bullet if Cyrus is facing left
        if (transform.localScale.x < 0)
        {
            Vector3 bulletScale = bullet.transform.localScale;
            bulletScale.x *= -1;
            bullet.transform.localScale = bulletScale;
        }
    }
}
