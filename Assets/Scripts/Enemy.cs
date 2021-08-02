using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{

    enum EnemyState { Idle, Chasing, Attack}


    EnemyState currentState;


    NavMeshAgent pathFinder;
    Transform targetPos;


    Material enemySkin;
    Color enemyOriginalColor;

    float timeBetweenAttacks = 2f;
    float nextAttackTime;
    float distanceThreshold = .5f;
    float damage = 1f;


    float enemyCollisionRadius;
    float playerCollisionRadius;

    LivingEntity playerEntitiy;
    bool isPlayerAlive;

    protected override void Start()
    {
        base.Start();
        pathFinder = GetComponent<NavMeshAgent>();

        enemySkin = GetComponent<Renderer>().material;
        enemyOriginalColor = enemySkin.color;

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            currentState = EnemyState.Chasing;
            isPlayerAlive = true;
            targetPos = GameObject.FindGameObjectWithTag("Player").transform;
            playerEntitiy = targetPos.GetComponent<LivingEntity>();
            playerEntitiy.OnDeath += OnPlayerDeath;
            enemyCollisionRadius = GetComponent<CapsuleCollider>().radius;
            playerCollisionRadius = targetPos.GetComponent<CapsuleCollider>().radius;
            StartCoroutine(UpdatePath());
        }

        
    }

    private void Update()
    {
        
        if(isPlayerAlive)
        {
            if (Time.time > nextAttackTime)
            {


                float sqrOffset = (transform.position - targetPos.position).sqrMagnitude;
                if (sqrOffset < Mathf.Pow(distanceThreshold + playerCollisionRadius + enemyCollisionRadius, 2))
                {
                    nextAttackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }

        }

    }



    void OnPlayerDeath()
    {
        isPlayerAlive = false;
        currentState = EnemyState.Idle;
    }


    IEnumerator Attack()
    {

        currentState = EnemyState.Attack;
        pathFinder.enabled = false;

        Vector3 originalPos = transform.position;
        Vector3 dirTotarget = (targetPos.position - transform.position).normalized;
        Vector3 attackPos = targetPos.position - dirTotarget * (playerCollisionRadius);


        float attackSpeed = 3f;
        float percent = 0;

        bool hasDamageApplied = false;


        enemySkin.color = Color.red;
        while(percent <= 1 )
        {


            if (percent >= 0.5f && hasDamageApplied == false)
            {
                hasDamageApplied = true;
                playerEntitiy.TakeDamage(damage);
            }


            percent += Time.deltaTime * attackSpeed;

            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPos,attackPos , interpolation);
            yield return null;

        }
        enemySkin.color = enemyOriginalColor;

        
        currentState = EnemyState.Chasing;
        pathFinder.enabled = true;


    }


    IEnumerator UpdatePath(){  
       float refreshRate = .5f;

        while (isPlayerAlive){

            Vector3 dirToTarget = (targetPos.position - transform.position).normalized;


            Vector3 fixedPos = targetPos.position - dirToTarget * (playerCollisionRadius + enemyCollisionRadius + distanceThreshold/2);

            if (!dead && currentState == EnemyState.Chasing)
            {
                pathFinder.SetDestination(fixedPos);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }



}
