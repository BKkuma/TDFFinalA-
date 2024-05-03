using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    public float hp = 10f;

    // Function to take damage
    public void TakeDamage(float damage)
    {
        hp -= damage;

        // Check if HP is less than or equal to zero
        if (hp <= 0)
        {
            Die();
        }
    }

    // Function to handle death
    void Die()
    {
        // Add any death behavior here (e.g., play death animation, deactivate game object, etc.)
        Destroy(gameObject);
    }
}
