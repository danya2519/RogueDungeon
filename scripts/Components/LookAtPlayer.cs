using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool lookNow = true;
    [SerializeField] private bool axisYOnly = false;
    public GameObject target;
    void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

    }
    private void Update()
    {
        if (lookNow)
        {
            if(!axisYOnly)
                transform.LookAt(target.transform.position);
            else
                transform.LookAt(new Vector3(target.transform.position.x,transform.position.y, target.transform.position.z));
        }
    }
    public void LookAtP()
    {
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
    }
}
