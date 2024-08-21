using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private int damage;
    private float speed;
    private Vector3 moveDirection;
    [SerializeField] private string ignoreTag;
    private bool createdNotByPlayer;


    private void Start()
    {
        if(ignoreTag == "Player")
        {
            speed = Attack.speed;
            damage = Attack.damage;
        }
    }

    /*private void Awake()
    {
            
    }*/

    private void Update()
    {
        if(moveDirection== Vector3.zero)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            transform.Translate(new Vector3(moveDirection.x, 0, moveDirection.z) * speed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

       
            if (collision.gameObject.TryGetComponent<HealthComponent>(out HealthComponent healthComponent) &&
                collision.gameObject.tag != ignoreTag)
            {
                healthComponent.ChangeHealth(-damage);
                Destroy(gameObject, 0.05f);
            }
            
        
    }

    public void Setup(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
        
    }   
    
    public void Setup(float speed, int damage, Vector3 moveDirection)
    {
        this.speed = speed;
        this.damage = damage;
        //Setup(speed , damage);  
        this.moveDirection = moveDirection;
        transform.rotation = Quaternion.identity;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
    public void SetDamage(int value)
    {
        damage = value;
    }
}
