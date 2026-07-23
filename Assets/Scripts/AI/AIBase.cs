using System;
using System.Collections;
using game.Stats;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIBase : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;

    [NonSerialized]
    public bool isAttacking, IsChanneling;
    Player player;
    AIController controller;
    NavMeshAgent agent;
    Animator anim;
    Vector3 velocity;
    public GameObject body;
    public EntityStats stats;
    public Resource health;
    
    bool canChase = true, canAttack = true, canChannel = true;

    void Awake()
    {
        player = FindFirstObjectByType<Player>();
        controller = FindFirstObjectByType<AIController>();

        rb = GetComponent<Rigidbody>();
        anim = body.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = stats.speed;
        agent.updatePosition = false;

        health = new Resource(0, stats.health, stats.health);
        stats.health.AddObserver(health);
    }

    void Update()
    {
        if(player == null) return;

        CheckAttack();

        AttemptChannel();

        if(IsChanneling)
        {
            Channel();
        }
    }
    void FixedUpdate()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if(player == null || !canChase) return;

        agent.SetDestination(player.transform.position);

        transform.position = Vector3.SmoothDamp(transform.position, agent.nextPosition, ref velocity, 0.1f);
    }
    #region Attacking
    void CheckAttack()
    {
        if(!canAttack) return;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if(dist <= stats.attackRange && !isAttacking)
        {
            TriggerAttack();
        }
    }

    public void TriggerAttack()
    {
        isAttacking = true;
        anim.SetTrigger("Attack");
    }

    public void ResetAttack()
    {
        Debug.Log("Resetting Attack");
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(stats.attackCooldown);
        isAttacking = false;
    }

    #endregion

    #region Channeling
    void AttemptChannel()
    {
        if(!controller.CanChannelAttack() || !canChannel || isAttacking) return;


        if(ShouldChannel() && !IsChanneling)
        {
            IsChanneling = true;
            canAttack = false;
            canChannel = false;
            canChase = false;

            controller.NotifyChannelStart();
            agent.isStopped = true;
        }
        else if(canChannel)
        {
            canChannel = false;
            StartCoroutine(ChannelCooldown());
        }
    }

    virtual public void Channel()
    {
        Debug.Log("Channeling Attack");
    }

    virtual public void ChannelAttack()
    {
      
        
    }

    bool ShouldChannel()
    {
        float roll = UnityEngine.Random.Range(0f, 100f);
        return roll <= stats.channelChance;
    }

     IEnumerator ChannelCooldown()
    {
        yield return new WaitForSeconds(stats.channelDelay);
        canChannel = true;
    }

    #endregion
    
}
