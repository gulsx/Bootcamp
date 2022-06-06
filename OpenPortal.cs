using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    public GameObject portal;

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag.Equals("Trail"))
        {
            Instantiate(portal, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

}

