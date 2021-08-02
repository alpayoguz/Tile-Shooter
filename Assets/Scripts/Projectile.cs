using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    float projectileSpeed = 10f;
    public LayerMask collisionMask;
    float damage = 1f;

    float projectileLifeTime = 2f;
    float skinWidth = .1f;



    private void Start()
    {
        Destroy(gameObject, projectileLifeTime);
        CheckIfProjectileInside();
    }



    public void SetSpeed(float currentSpeed)
    {
        projectileSpeed = currentSpeed;
    }


  




    public void ProjectileTransform()
    {
        float moveDistance = projectileSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistance);
        CheckCollision(moveDistance);

    }



    private void Update()
    {
        ProjectileTransform();
    }




    void CheckCollision(float moveDistance)
    {
        Ray projectileRay = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        

        if(Physics.Raycast(projectileRay, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }

    }

    void CheckIfProjectileInside()
    {
        float sphereRadius = .1f;
        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, sphereRadius, collisionMask);
        if(initialCollisions.Length > 0)
        {
            OnHitObject(initialCollisions[0]);
        }

    }


    void OnHitObject(RaycastHit hit)
    {
        IDamagable damagableObject = hit.collider.GetComponent<IDamagable>();
        if(damagableObject != null)
        {
            damagableObject.TakeHit(damage, hit);
        }
        
        Destroy(gameObject);

    }


    void OnHitObject(Collider cldr)
    {
        IDamagable damagableObject = cldr.GetComponent<IDamagable>();
        if(damagableObject != null)
        {
            damagableObject.TakeDamage(damage);
        }

        Destroy(gameObject);
        

    }

   

    

    


}
