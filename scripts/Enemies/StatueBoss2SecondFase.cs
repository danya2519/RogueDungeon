using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatueBoss2SecondFase : MonoBehaviour
{
    [SerializeField] private GameObject holeInGround;
    [SerializeField] private GameObject wave;
    [SerializeField] private GameObject CrystalTornado;
    public Action currentAction;
    private Enemy enemyComp;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    private HealthComponent HC;
    private bool isAttacking;
    void Start()
    {
        enemyComp = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        HC = GetComponent<HealthComponent>();
        StartCoroutine(Jump());
    }

    void Update()
    {
        if(currentAction == Action.Run)
        {
            enemyComp.enabled = true;
            navMeshAgent.enabled = true;
        }
        else
        {
            enemyComp.enabled = false;
            navMeshAgent.enabled = false;
            if (!isAttacking)
            {
                StartCoroutine(currentAction.ToString());
            }
        }
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && currentAction == Action.Run)
        {
            currentAction = Action.Smash;
        }
    }


    IEnumerator Smash()
    {
        animator.SetTrigger("Punch");
        isAttacking = false;
        holeInGround.SetActive(true);
        if(HC.GetHealth() < 500)
        {
            wave.SetActive(true);
        }
        yield return new WaitForSeconds(4);
        currentAction = Action.Run;
        isAttacking = true;
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(6);

    }

    public enum Action 
    { 
        Run,
        Smash,
        Jump,
        RotateToPlayer,
        TornadeInCentre,
    }
}


