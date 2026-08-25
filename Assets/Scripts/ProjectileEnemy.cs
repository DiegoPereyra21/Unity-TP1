using System;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float damage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed + Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if(otherHealth != null)
        {
            otherHealth.TakeDamage(damage);   
        }

        Destroy(gameObject);
    }
}
