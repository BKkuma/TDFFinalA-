using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            PortalEndGAme portalEndGame = collision.gameObject.GetComponent<PortalEndGAme>();
            if (portalEndGame != null)
            {
                portalEndGame.IncrementEnemyCount();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            Destroy(gameObject);
        }
    }
}
