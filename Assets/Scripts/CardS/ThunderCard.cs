using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCard : MonoBehaviour
{
    public int damage;
    public float timeToFade, volumeFade = 2;
    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        Destroy(gameObject, volumeFade);
    }
    void Update()
    {
        // reduz som do efeito com o tempo 
        timeToFade -= Time.deltaTime;
        if(timeToFade > 0)
        myAudioSource.volume = (1/volumeFade) * timeToFade;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyHit!");

            // Dano ao inimigo
            collision.gameObject.GetComponent<EnemyStats>().myHealth = collision.gameObject.GetComponent<EnemyStats>().myHealth - damage;
            collision.gameObject.GetComponent<EnemyStats>().myHealth = collision.gameObject.GetComponent<EnemyStats>().myHealth - damage;
            collision.gameObject.GetComponent<EnemyStats>().Hurt();
            // Ativar �rea de fogo
        }
        
    }    
}
