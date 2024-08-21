using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEnemys : MonoBehaviour
{
    private Animator myAnim;
    private GameObject target;
    [SerializeField] private GameObject projectile;
    private Vector3 moveDirection;
    [SerializeField] private int bulletSpeed;
    public float Timer = 6.28f;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Timer > 5.28 && Timer < 5.30)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            moveDirection = target.transform.position.normalized;
            print(moveDirection);
            newProjectile.GetComponent<EnemyBullets>().Setup(bulletSpeed, moveDirection);
        }
        if(Timer <= 0)
        {
            Timer = 6.28f;
        }
        Timer -= Time.deltaTime;
    }
}
