using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public void KillEnemy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;

        Destroy(_enemy, 2);
        enemies.Remove(_enemy);
    }

    void OnEnemyDied(Enemy _enemy)
    {
        KillEnemy(_enemy.gameObject);
    }
}
