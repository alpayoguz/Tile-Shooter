using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    Gun equippedGun;

    [SerializeField] Transform enemyGunPos;
    [SerializeField] Gun startingGun;


    private void Start()
    {
        if(startingGun != null)
        {
            EquippedGun(startingGun);
  

        }
    }


    void EquippedGun(Gun gun)
    {


          
           
           equippedGun =  Instantiate(gun, enemyGunPos.position, enemyGunPos.rotation) as Gun;
           equippedGun.transform.parent = enemyGunPos;

        

    }










}
