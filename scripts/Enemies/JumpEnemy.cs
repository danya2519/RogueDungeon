using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
    private GameObject target;
    private ShootFallBullets shootComp;
    [SerializeField] private GameObject partickle;
    [SerializeField] private int loopParticles = 10;
    private Rigidbody rigb;
    private bool jumpUp = false;
    void Start()
    {
        StartCoroutine(WaitFromStart());
        shootComp = GetComponent<ShootFallBullets>();
        rigb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator WaitFromStart()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Jump());
        yield return new WaitForSeconds(4);
        StartCoroutine(WaitFromStart());
    }
    IEnumerator Jump()
    {
        rigb.useGravity = false;
        jumpUp = true;
        yield return new WaitForSeconds(2.75f);
        jumpUp = false;
        rigb.useGravity = true;
        transform.position = target.transform.position + new Vector3(0, 15, 0);
        yield return new WaitForSeconds(1.5f);
        shootComp.Shoot(loopParticles);
        Instantiate(partickle, transform);
    }
    private void Update()
    {
        if (jumpUp && transform.position.y < 15)
        {
            rigb.velocity = transform.up * 10;
        }
        else
        {
            rigb.velocity = transform.up * -10;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }

        }
    }
}
