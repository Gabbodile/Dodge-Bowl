using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemy;
    /*public Transform[] spawnPoints;

    //Respawning of enemies after enemy is dead
    void SpawnEnemy()
    {
        if (enemy.Count == 0)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Instantiate(enemy, spawnPoints[i].position, spawnPoints[i].rotation);
            }
        }
    }*/

    public void KillEnemy(GameObject _enemy)
    {
        if (enemy.Count == 0)
            return;

        Destroy(_enemy, 2);
        enemy.Remove(_enemy);
    }

    void OnEnemyDied(Enemy _enemy)
    {
        KillEnemy(_enemy.gameObject);
    }
}
