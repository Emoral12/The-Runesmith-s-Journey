using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage;
    public float projectileSpeed;
    public Rigidbody rb;  // Use 3D Rigidbody

    void Start()
    {
        // Move the prjectul forward in the direction it's facing
        rb.velocity = transform.forward * projectileSpeed;
    }

    // Damage-taking logic and collision detection
    // private void OnTriggerEnter(Collider other) 
   // {
        // if (other.gameObject.CompareTag("Enemy"))  // Check if the object hit is an enemy
        //{
            // Assuming the EnemyController has a health property
           // EnemyController enemy = other.GetComponent<EnemyController>();
           // if (enemy != null)
           // {
             //   enemy.health -= damage;
            //}
      //  }

        // Destroy the projectile on impact
     //   Destroy(gameObject);
    // }
}
