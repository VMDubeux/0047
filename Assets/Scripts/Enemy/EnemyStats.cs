using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{

    public int myHealth, myDamage, mySpeed;
    public Transform tower;    
    public EnemySO enemySO;
    NavMeshAgent agent;
    void Start()
    {
        myHealth = enemySO.EnemyLife();
        myDamage = enemySO.EnemyDamage();
        mySpeed = enemySO.EnemySpeed();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = tower.position;
        
    }





    
}
