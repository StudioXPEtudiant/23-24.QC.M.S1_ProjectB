using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour {

    [Header("AI Settings")]
    [Space]
    public float lookRadius = 10f;
    public float wanderRadius = 20f;
    public float cooldown = 1.5f;
    public float wanderTimer;
    
    private float timer;
    
    private bool canAttack = true;
    private bool isWandring = false;
    
    public Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        canAttack = true;
        
        timer = wanderTimer;
    }

    void Update ()
    {
        // Get the distance to the player
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the radius
        //if (distance <= lookRadius)

        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit, lookRadius));
        {
            if (hit.collider != null && hit.transform.position == target.transform.position)
            {
                
                // Move towards the player
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    // Attack

                    if (target.GetComponent<PlayerHealth>() && canAttack)
                    {
                        target.GetComponent<PlayerHealth>().health -= 1;

                        print("player attacked");

                        StartCoroutine(Cooldown());
                    }

                    //FaceTarget();
                }
            }
            else
            {
                timer += Time.deltaTime;
 
                if (timer >= wanderTimer) {
                    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                    agent.SetDestination(newPos);
                    timer = 0;
                }
            }
        }
    }

    public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layerMask) {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
           
        randomDirection += origin;
           
        NavMeshHit navHit;
        
        UnityEngine.AI.NavMesh.SamplePosition (randomDirection, out navHit, distance, layerMask);
           
        return navHit.position;
    }

    IEnumerator Cooldown()
    {
        canAttack = false;

        yield return new WaitForSeconds(cooldown);

        canAttack = true;
    }
    
    // Point towards the player
    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    void TurnToAngle(Quaternion lookRotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }

}