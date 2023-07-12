using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyStats : MonoBehaviour
{

    public int myHealth, myDamage, mySpeed;
    [Range(0,99)] public int dropRate = 50;
    public Transform tower;    
    public EnemySO enemySO;
    public GameObject cardGO;    
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
private void OnCollisionEnter(Collision other) {
    if(other.collider.CompareTag("Ground") == false)
    Die();
}
    private void Die()
    {
        int r = Random.Range(0,99);
        if(r <= dropRate)
        {
            Instantiate(cardGO, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject,0.1f);
    }
}
