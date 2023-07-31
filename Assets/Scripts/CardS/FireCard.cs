using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCard : MonoBehaviour
{
    public int damage;
    public float colTimer = 1;
    float timeToFade, volumeFade = 2;
    BoxCollider myBoxCollider;
    AudioSource myAudioSource; 

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myBoxCollider = GetComponent<BoxCollider>();
        Invoke("CollisionEnable", colTimer);
        Destroy(gameObject, volumeFade);        
    }
    void Update()
    {
        // reduz som do efeito com o tempo 
        timeToFade -= Time.deltaTime;
        if(timeToFade > 0)
        myAudioSource.volume = (1/volumeFade) * timeToFade;
    }
private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
        Debug.Log("EnemyHit!"); 
        
        // Dano ao inimigo
        other.gameObject.GetComponent<EnemyStats>().myHealth = other.gameObject.GetComponent<EnemyStats>().myHealth - damage;
        other.gameObject.GetComponent<EnemyStats>().Hurt();
        // Ativar �rea de fogo
        }
    }

    void CollisionEnable()
    {
        myBoxCollider.enabled = true;
    }
}
