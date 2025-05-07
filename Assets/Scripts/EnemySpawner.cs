using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{

    

    public List<EnemySO> enemyTypeList = new List<EnemySO>();
    public float enemySpawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            int enemychoice = Random.Range(0, enemyTypeList.Count);
            float spawnposX = Random.Range(GameData.XMin, GameData.XMax);  

            Vector3 enemyPos = new Vector3(spawnposX, GameData.YMax, 0);
            GameObject enemyInstance= Instantiate(enemyTypeList[enemychoice].enemyPrefab, enemyPos, Quaternion.identity);
            enemyInstance.GetComponent<Enemy>().strength = enemyTypeList[enemychoice].strength;
            enemyInstance.GetComponent<Enemy>().hitpoints = enemyTypeList[enemychoice].hitpoints;
            enemyInstance.GetComponent<Enemy>().speed = enemyTypeList[enemychoice].speed;
            yield return new WaitForSeconds(enemySpawnInterval);   
        }
    }
}
