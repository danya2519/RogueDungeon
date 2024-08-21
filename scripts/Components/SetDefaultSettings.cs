using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultSettings : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float bulletspeed;
    [SerializeField] private float shotspeed;
    [SerializeField] private GameObject bullet;
    void Start()
    {
        StartCoroutine(Wait());

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        CharacterControllerC.speedMove = speed;
        Attack.damage = damage;
        Attack.speed = bulletspeed;
        Attack.shootSpeed = shotspeed;
        Attack.projectile = bullet;
    }
}
