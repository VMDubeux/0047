using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaterCard : MonoBehaviour
{
    public Transform target;
    Vector3 movingVector;
    bool goingUp = true;
    public float speed = 10, volumeFade = 7.5f, timeToFade;
    public int damage = 10;
    AudioSource myAudioSource;
    //bool returning = false;


    void Start()
    {
        movingVector = new Vector3 (0,1,0);
        //(target.position - transform.position).normalized;
        Destroy(gameObject, volumeFade);
        myAudioSource = GetComponent<AudioSource>();
        timeToFade = volumeFade;
    }

    void Update()
    {
        if(transform.position.y > target.position.y)
        {
            goingUp = false;
        }
        if(goingUp)
        {
        transform.Translate(movingVector * speed * Time.deltaTime);
        }
        else 
        transform.Translate(-movingVector * speed * Time.deltaTime);
        // reduz som do efeito com o tempo 
        timeToFade -= Time.deltaTime;
        if(timeToFade > 0)
        myAudioSource.volume = (1/volumeFade) * timeToFade;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
        collision.gameObject.GetComponent<EnemyStats>().myHealth = collision.gameObject.GetComponent<EnemyStats>().myHealth - damage;
        collision.gameObject.GetComponent<EnemyStats>().myHealth = collision.gameObject.GetComponent<EnemyStats>().myHealth - damage;
        collision.gameObject.GetComponent<EnemyStats>().Hurt();
        }
    }
}
