using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "newEnemy")]


public class EnemySO : ScriptableObject
{
    // Status do inimigo
    public int enemyLife = 100, enemySpeed = 10, enemyDamage = 5;

    // Métodos "Getter" para obter os status

    public int EnemyLife()
    {
        return enemyLife;
    }

    public int EnemySpeed()
    {
        return enemySpeed;
    }

    public int EnemyDamage()
    {
        return enemyDamage;
    }

}
