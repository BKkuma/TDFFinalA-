using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEndGAme : MonoBehaviour
{
    [SerializeField] private GameObject vfxEndGame;

    private int enemyCount = 0;
    private bool isLoaded = false;

    private void Start()
    {
        Instantiate(vfxEndGame, transform.position, transform.rotation);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IncrementEnemyCount();
        }    }

    public void IncrementEnemyCount()
    {
        enemyCount++;

        if (enemyCount >= 5 && !isLoaded)
        {
            isLoaded = true;
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(2); 
    }
}
