using UnityEngine;
using TMPro;

public class EnemyCountScore : MonoBehaviour
{
    public TMP_Text enemyCountText; // ��ҧ�ԧ��ѧ����๹�� TMP_Text
    private int enemyCount = 0; // ��ǹѺ�ӹǹ Enemy

    void Start()
    {
        UpdateEnemyCountText(); // �Ѿഷ��ͤ����ӹǹ Enemy ��������
    }

    // �����ӹǹ Enemy
    public void IncrementEnemyCount()
    {
        enemyCount++;
        UpdateEnemyCountText(); // �Ѿഷ��ͤ����ӹǹ Enemy
    }

    // Ŵ�ӹǹ Enemy
    public void DecrementEnemyCount()
    {
        enemyCount--;
        UpdateEnemyCountText(); // �Ѿഷ��ͤ����ӹǹ Enemy
    }

    // �Ѿഷ��ͤ����ӹǹ Enemy � TextMeshPro
    void UpdateEnemyCountText()
    {
        int absEnemyCount = Mathf.Abs(enemyCount); // �ŧ��Ҩӹǹ Enemy �繺ǡ
        enemyCountText.text = "Enemy Count: " + absEnemyCount.ToString() + "/5"; // �Ѿഷ��ͤ����ӹǹ Enemy
    }

}
