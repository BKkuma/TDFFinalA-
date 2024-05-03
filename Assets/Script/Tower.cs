using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackDamage = 10f;
    public float cooldownTime = 1f; // Cooldown time in seconds
    private bool canAttack = true; // Flag to check if tower can attack

    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        // Check if tower can attack (not in cooldown)
        if (canAttack)
        {
            // Check for enemies within range
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

            // If there are enemies in range, attack them
            foreach (Collider col in hitColliders)
            {
                HPEnemy enemy = col.GetComponent<HPEnemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
                }
            }

            // Start cooldown
            StartCoroutine(Cooldown());
        }
    }

    // Cooldown coroutine
    IEnumerator Cooldown()
    {
        // Set flag to prevent further attacks during cooldown
        canAttack = false;

        // Wait for cooldown time
        yield return new WaitForSeconds(cooldownTime);

        // Reset flag to allow attacking again
        canAttack = true;
    }

    // Debug visualization of attack range in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
