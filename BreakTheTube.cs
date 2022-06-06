using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTheTube : MonoBehaviour
{
    public GameObject model_portalTube;
    public GameObject TLine;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            model_portalTube.gameObject.SetActive(true);
            TLine.gameObject.SetActive(true);
           
        }
    }

}
