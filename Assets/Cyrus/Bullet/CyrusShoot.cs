using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyrusShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.3f;

    private float nextFireTime = 0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

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

        // Trigger shoot animation
        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }

        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Flip and set bullet direction
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            if (transform.localScale.x < 0)
            {
                // Flip sprite
                Vector3 scale = bullet.transform.localScale;
                scale.x *= -1;
                bullet.transform.localScale = scale;

                // Set direction
                bulletScript.SetDirection(Vector2.left);
            }
            else
            {
                bulletScript.SetDirection(Vector2.right);
            }
        }
    }
}

