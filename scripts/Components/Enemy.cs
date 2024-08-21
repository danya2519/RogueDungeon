using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private GameObject Target;
    

    private NavMeshAgent agent;
    private Animator animator;
    private float rotationSpeed;
    private float distanceToPlayer;
    [SerializeField] private float atackRadius = 2;
    private bool needAnimator = false;
    private bool attackCoolDown = true;

    private void Awake()
    {
        Target = GameObject.FindWithTag("Player");
    }
    private void Start()
    {
        print(Target);
        agent = GetComponent<NavMeshAgent>();
        if (needAnimator)
        {
            animator = GetComponent<Animator>();
        }
            

    }
    private void Update()
    {       
        distanceToPlayer = Vector3.Distance(Target.transform.position, agent.transform.position);

        MoveToTarget();
        if (distanceToPlayer < atackRadius && attackCoolDown)
        {
            if (needAnimator)
            {
                animator.SetTrigger("Attack");
            }
            StartCoroutine(wait());
        }
       
    }


 
    private void MoveToTarget() 
    {
        agent.SetDestination(Target.transform.position);
    }
    
    IEnumerator wait()
    {
        attackCoolDown = false;
        if (distanceToPlayer < 2)
        {
            if (Target.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }
        }
        yield return new WaitForSeconds(1f);
        attackCoolDown = true;
    }
  

    
}
