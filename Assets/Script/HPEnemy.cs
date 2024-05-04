using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    public float hp = 10f;
    public GameObject hitVFXPrefab;
    [SerializeField] GameObject dieVFX;
    private bool isAttacked = false; // Flag to check if enemy is attacked

    // Function to take damage
    public void TakeDamage(float damage)
    {
        hp -= damage;

        // Check if HP is less than or equal to zero
        if (hp <= 0)
        {
            Die();
            VFXDIE();

        }
        else
        {
            // Play hit VFX only if the enemy is attacked
            if (isAttacked && hitVFXPrefab != null)
            {
                Instantiate(hitVFXPrefab, transform.position, transform.rotation);
            }
        }

        // Reset flag after being attacked
        isAttacked = false;
    }

    // Function to handle death
    void Die()
    {
        Destroy(gameObject);

    }

    // Set flag when enemy is attacked
    public void SetAttacked()
    {
        isAttacked = true;
    }

    private void VFXDIE()
    {
        Instantiate(dieVFX, transform.position, transform.rotation);
    }
}
