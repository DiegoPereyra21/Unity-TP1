using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float damage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);//antes no escalaba bien con el framerate
    }
    void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if(otherHealth != null)
        {
            otherHealth.TakeDamage(damage);
        }

        Destroy(gameObject);//renege como media hora hasta q me di cuenta q era culpa de la falta de rigibody que no de destruyera contra paredes y obstaculs
    }
}
