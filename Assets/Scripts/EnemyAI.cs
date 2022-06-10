using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] float turnSpeed = 5f; 
    [SerializeField] EnemyHealth health;
    [SerializeField] EnemyAttack enemyAttack;
    [Tooltip("In sec")][SerializeField] float enemyAttackTime = 1;
    [SerializeField] Animator animator;
    
    PlayerHealth target;
    float distanceToTarget = Mathf.Infinity;
    bool canAttack = true;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
        Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
    }
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        EngageTarget();
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            if(canAttack)
            {
                StartCoroutine(AttackTarget());
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    IEnumerator AttackTarget()
    {
        canAttack = false;
        enemyAttack.AttackHitEvent();
        animator.SetBool("isAttacking",true);
        yield return new WaitForSeconds(enemyAttackTime);
        animator.SetBool("isAttacking", false);
        canAttack = true;
    }
}
