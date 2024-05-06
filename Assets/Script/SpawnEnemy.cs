using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private LayerMask layerMask; 
    private bool canSpawn = true; 

    private void Update()
    {
        if (canSpawn && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Spawn(hit.point);
                canSpawn = false; 
            }
        }
    }

    private void Spawn(Vector3 position)
    {
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }
}
