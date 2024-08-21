using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    private float speed;
    private Vector3 moveDirection;
    [SerializeField] private string ignoreTag;

    private void Update()
    {
        transform.Translate(new Vector3(moveDirection.x, 0, moveDirection.z) * speed * Time.deltaTime);
    }
    public void Setup(float speed, Vector3 moveDirection)
    {
        this.speed = speed;  
        this.moveDirection = moveDirection;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ignoreTag && collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }
            Destroy(gameObject);
        }
    }
}
