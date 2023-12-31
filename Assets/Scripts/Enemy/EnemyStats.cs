using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyStats : MonoBehaviour
{

    public int myHealth, myDamage, mySpeed;
    [Range(0,99)] public int dropRate = 50;
    public EnemySO enemySO;
    public GameObject cardGO;
    public GameObject hurtPS;
    NavMeshAgent navMesh;
    public Transform tower;    
    bool isDead = false;
    public float reducedMoveSpeed = 2.5f;
    public float slowdownDuration = 5f;

    private float currentMoveSpeed;
    private bool isSlowed = false;
    private float slowdownTimer = 0f;
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
        currentMoveSpeed = mySpeed;

    }
    void Update()
    {
        Vector3 target = tower.position - transform.position;
        navMesh.destination = tower.position; 
        if(myHealth <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
        if (isSlowed)
        {
            slowdownTimer -= Time.deltaTime;
            if (slowdownTimer <= 0f)
            {
                isSlowed = false;
                currentMoveSpeed = mySpeed;
            }
        }
    }
private void OnCollisionEnter(Collision other) {
    if(other.collider.CompareTag("Tower") == true)
    Die();
}
    private void Die()
    {
        Instantiate(cardGO, gameObject.transform.position, Quaternion.identity);
        Animator myAnimator = GetComponentInChildren<Animator>();
        AudioSource myAudioSource = GetComponent<AudioSource>();
        myAudioSource.Play();
        myAnimator.SetTrigger("dead");
        Destroy(gameObject,2f);
    }

    public void Hurt()
    {
        GameObject hurt = Instantiate(hurtPS, transform.position, Quaternion.identity);
        Destroy(hurt, 2);
    }

    public void SlowDown()
    {
        isSlowed = true;
        slowdownTimer = slowdownDuration;
        currentMoveSpeed = reducedMoveSpeed;
    }

    public float GetMoveSpeed()
    {
        return currentMoveSpeed;
    }
}
