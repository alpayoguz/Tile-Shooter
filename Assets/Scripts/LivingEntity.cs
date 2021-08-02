using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IDamagable
{
    // fields about health and death
    public float startingHealth;
    protected float health;
    public bool dead;


    // event for death
    public event Action OnDeath;


   
   

    Spawner spawner;
    protected virtual void Start()
    {
        
        health = startingHealth;
       

        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        




    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        TakeDamage(damage);

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Die();
        }

    }


    protected void Die()
    {
        
       
        dead = true;    
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }


   


}
