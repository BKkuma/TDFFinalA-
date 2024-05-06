using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float cooldownTime = 1f; 
    [SerializeField] private GameObject vfx; 
    [SerializeField] private LayerMask enemyLayer;
    private bool canAttack = true;


    private void Update()
    {
        if (canAttack)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

            foreach (Collider col in hitColliders)
            {
                VFX();
                HPEnemy enemy = col.GetComponent<HPEnemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
                    enemy.SetAttacked(); 
                }
            }

            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        canAttack = false;

        yield return new WaitForSeconds(cooldownTime);

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void VFX()
    {
        if (vfx != null)
        {
            Instantiate(vfx, transform.position, transform.rotation);
        }
    }
}
