using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedTube : MonoBehaviour
{
    public GameObject fractured;

    void OnCollisionEnter(Collision collision)
    {
        
            Instantiate(fractured, transform.position, Quaternion.identity);
            Destroy(gameObject);
        
    }

}

   
    



