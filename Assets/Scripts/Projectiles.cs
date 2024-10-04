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
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("GameArea"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().health -= damage;
            Debug.Log("Damage dealt");
            Destroy(gameObject);
        }
    }
}
