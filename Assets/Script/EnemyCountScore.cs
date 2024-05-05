using UnityEngine;
using TMPro;

public class EnemyCountScore : MonoBehaviour
{
    public TMP_Text enemyCountText; // อ้างอิงไปยังคอมโพเนนต์ TMP_Text
    private int enemyCount = 0; // ตัวนับจำนวน Enemy

    void Start()
    {
        UpdateEnemyCountText(); // อัพเดทข้อความจำนวน Enemy ในเริ่มต้น
    }

    // เพิ่มจำนวน Enemy
    public void IncrementEnemyCount()
    {
        enemyCount++;
        UpdateEnemyCountText(); // อัพเดทข้อความจำนวน Enemy
    }

    // ลดจำนวน Enemy
    public void DecrementEnemyCount()
    {
        enemyCount--;
        UpdateEnemyCountText(); // อัพเดทข้อความจำนวน Enemy
    }

    // อัพเดทข้อความจำนวน Enemy ใน TextMeshPro
    void UpdateEnemyCountText()
    {
        int absEnemyCount = Mathf.Abs(enemyCount); // แปลงค่าจำนวน Enemy เป็นบวก
        enemyCountText.text = "Enemy Count: " + absEnemyCount.ToString() + "/5"; // อัพเดทข้อความจำนวน Enemy
    }

}
