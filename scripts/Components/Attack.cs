using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    public static GameObject projectile;
    public GameObject bomb;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public float projectileLifeTime;

    private FixedJoystick fixedJoystick;

    public static int damage;
    public static float speed;
    public static float shootSpeed;

    [SerializeField] private LayerMask shootMask;
  


    private float timer = 0;

    private Animator animator;

    private void Start()
    {
        fixedJoystick = GameObject.FindGameObjectWithTag("RightJoystick").GetComponent<FixedJoystick>();
        animator = GetComponentInChildren<Animator>();
    }
    private void ProjectileSpawn(Vector3 moveDirection)
    {
        GameObject newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.transform.rotation);
        if (newProjectile.TryGetComponent<Bullets>(out Bullets b))
        {
            newProjectile.GetComponent<Bullets>().Setup(speed, damage, moveDirection);
        }
        Destroy(newProjectile, projectileLifeTime);
    }
    private void HandleAnimation()
    {
        animator.SetTrigger("Attack");
    }
    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
        {
            UseBomb();
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        timer += Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        if(ES3.Load<bool>("isJoy"))
        {
            Vector3 moveDirection = new Vector3(fixedJoystick.Horizontal, 0, fixedJoystick.Vertical);
            if (moveDirection != Vector3.zero && timer > shootSpeed)
            {
                ProjectileSpawn(moveDirection);
                timer = 0;
            }
        }
        else if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, shootMask))
        {
           
            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0) && timer > shootSpeed)
            {
                //HandleAnimation();
                //print(timer);
                print(shootSpeed);
                Vector3 moveDirection = (raycastHit.point - spawnPoint.transform.position).normalized;
                ProjectileSpawn(moveDirection);
                timer = 0;
            }
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            UseCard();
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            ES3.Save<bool>("isJoy", !ES3.Load<bool>("isJoy"));
        }





    }

    public void ChangeMoveSpeed(float amount)
    {
        CharacterControllerC.speedMove += amount;
    }

    public void UseActiveItem()
    {
        GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<ActiveItemStatsUp>().UseItem();
    }
    public void ChargeActiveItem()
    {
        GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<ActiveItemStatsUp>().ChargeUp();
    }
    public void UseCard()
    {
        GameObject.FindGameObjectWithTag("CardsObj").GetComponent<CardOrPills>().UseCard();
    }
    public void UseBomb()
    {
        if(CKBMeneger.bombs >= 1)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            CKBMeneger.bombs--;
        }
    }
}
