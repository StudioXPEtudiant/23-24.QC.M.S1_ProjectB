using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float lookRadius = 10f;
    public float cooldown = 2.5f;
    
    
    private bool canAttack = true;
    
    public Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        canAttack = true;
    }

    void Update ()
    {
        // Get the distance to the player
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the radius
        if (distance <= lookRadius)
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
                
                FaceTarget();
            }
        }
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

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}