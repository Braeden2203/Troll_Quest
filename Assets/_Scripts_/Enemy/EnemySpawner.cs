using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_enemy;
    [SerializeField] private Transform wall1;
    [SerializeField] private Transform wall2;
    private Enemy currentEnemy;

    void Start()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(m_enemy) as GameObject;
        newEnemy.transform.position = new Vector2(Random.Range(wall1.transform.position.x, wall2.transform.position.x), 2.0f);
        currentEnemy = newEnemy.GetComponent<Enemy>();
        currentEnemy.OnDeath += HandleEnemyDeath;
    }
    private void HandleEnemyDeath()
    {
        SpawnEnemy();
    }
}
