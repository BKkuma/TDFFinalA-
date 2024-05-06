using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    [SerializeField] private float hp = 10f;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] GameObject dieVFX;
    private bool isAttacked = false; 

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
            VFXDIE();

        }
        else
        {
            if (isAttacked && hitVFXPrefab != null)
            {
                Instantiate(hitVFXPrefab, transform.position, transform.rotation);
            }
        }

        isAttacked = false;
    }

    private void Die()
    {
        Destroy(gameObject);

    }

    public void SetAttacked()
    {
        isAttacked = true;
    }

    private void VFXDIE()
    {
        Instantiate(dieVFX, transform.position, transform.rotation);
    }
}
