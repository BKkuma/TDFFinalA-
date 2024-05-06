using UnityEngine;
using TMPro;

public class EnemyCountScore : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyCountText; 
    private int enemyCount = 0;
    private void Start()
    {
        UpdateEnemyCountText(); 
    }

    
    public void IncrementEnemyCount()
    {
        enemyCount++;
        UpdateEnemyCountText(); 
    }

    
    public void DecrementEnemyCount()
    {
        enemyCount--;
        UpdateEnemyCountText(); 
    }

    
    private void UpdateEnemyCountText()
    {
        int absEnemyCount = Mathf.Abs(enemyCount); 
        enemyCountText.text = "Enemy Count: " + absEnemyCount.ToString() + "/5"; 
    }

}
