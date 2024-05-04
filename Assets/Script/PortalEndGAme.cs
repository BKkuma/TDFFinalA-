using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEndGAme : MonoBehaviour
{
    [SerializeField] private GameObject vfxEndGame;

    public int enemyCount = 0;
    public bool isLoaded = false;

    private void Start()
    {
        Instantiate(vfxEndGame, transform.position, transform.rotation);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IncrementEnemyCount();
        }
    }

    public void IncrementEnemyCount()
    {
        enemyCount++;

        if (enemyCount >= 5 && !isLoaded)
        {
            isLoaded = true;
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1); // Change 1 to the build index of the scene you want to load
    }
}
