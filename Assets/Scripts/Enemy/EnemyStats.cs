using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyStats : MonoBehaviour
{

    public int myHealth, myDamage, mySpeed;
    public Transform tower;    
    public EnemySO enemySO;
    NavMeshAgent navMesh;
    void Start()
    {
        // Pegar par�metros dos ScriptleObjects
        myHealth = enemySO.EnemyLife();
        myDamage = enemySO.EnemyDamage();
        mySpeed = enemySO.EnemySpeed();
        // Utilizar componente NavMeshAgent
        navMesh = GetComponent<NavMeshAgent>();
        // Igualar Stopdistance com par�metro
        navMesh.stoppingDistance = 0;
        // Igualar NavMeshSpeed com par�metro
        navMesh.speed = mySpeed;

    }
    void Update()
    {
        Vector3 target = tower.position - transform.position;
        navMesh.destination = tower.position;

    }
}
