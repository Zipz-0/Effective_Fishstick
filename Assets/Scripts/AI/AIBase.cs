using UnityEngine;
using UnityEngine.AI;

public class AIBase : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    Player player;
    NavMeshAgent agent;
    Vector3 velocity;
    public Stats stats;

    void Awake()
    {
        player = FindObjectOfType<Player>();

        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.speed;
        agent.updatePosition = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if(player == null) return;

        agent.SetDestination(player.transform.position);

        transform.position = Vector3.SmoothDamp(transform.position, agent.nextPosition, ref velocity, 0.1f);
    }
}
