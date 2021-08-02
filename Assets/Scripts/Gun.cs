using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    [SerializeField] Transform projectileSpawnPos;
    public Projectile projectile;
    public float msBetweenShots = 100f;
    public float projectileFirstVelocity = 35f;
    float nextShootTime;


    


    public void Shoot()
    {


        if(Time.time > nextShootTime )
        {
            nextShootTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, projectileSpawnPos.position, projectileSpawnPos.rotation) as Projectile;
            newProjectile.SetSpeed(projectileFirstVelocity);

        }

    }


}
