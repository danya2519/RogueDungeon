using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class NavMeshBaker : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(2);
        
          
        }

    }

