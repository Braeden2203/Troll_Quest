using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] m_enemy;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int EnemyStartCount;
    [SerializeField] private float horizontalBlockDistance = 3f;
    [SerializeField] private LayerMask enemyLayer;
    private Enemy currentEnemy;
    private const int historySize = 6;
    private Queue<int> lastUsedIndexes = new Queue<int>();
    public int enemiesCount = 0;

    void Start()
    {
        for (int i = 0; i < EnemyStartCount; i++)
            StartCoroutine("SpawnEnemy");
    }
    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int index = GetUniqueSpawnIndex();
            Vector2 spawnPos = spawnPoints[index].position;
            if (IsSpawnPointClear(spawnPos))
            {
                GameObject newEnemy = Instantiate(GetRandomEnemy()) as GameObject;
                enemiesCount++;
                newEnemy.transform.position = spawnPos;
                currentEnemy = newEnemy.GetComponent<Enemy>();
                currentEnemy.OnDeath += HandleEnemyDeath;
                yield break;
            }
        }
        Debug.Log("No valid spawn point found.");
        yield return null;
        if (enemiesCount < EnemyStartCount)
            StartCoroutine(SpawnEnemy());
    }
    private void HandleEnemyDeath()
    {
        enemiesCount--;
        if (enemiesCount < EnemyStartCount)
            StartCoroutine(SpawnEnemy());
    }
    public GameObject GetRandomEnemy()
    {
        int index = Random.Range(0, m_enemy.Length);
        return m_enemy[index];
    }
    private int GetUniqueSpawnIndex()
    {
        List<int> availableIndexes = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (!lastUsedIndexes.Contains(i))
                availableIndexes.Add(i);
        }
        if (availableIndexes.Count == 0)
        {
            lastUsedIndexes.Clear();
            return Random.Range(0, spawnPoints.Length);
        }
        int newIndex = availableIndexes[Random.Range(0, availableIndexes.Count)];
        lastUsedIndexes.Enqueue(newIndex);
        if (lastUsedIndexes.Count > historySize)
            lastUsedIndexes.Dequeue();
        return newIndex;
    }
    private bool IsSpawnPointClear(Vector2 spawnPosition)
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (var enemy in enemies)
        {
            float horizontalDistance = Mathf.Abs(
                enemy.transform.position.x - spawnPosition.x
            );
            if (horizontalDistance < horizontalBlockDistance)
                return false;
        }
        return true;
    }
}