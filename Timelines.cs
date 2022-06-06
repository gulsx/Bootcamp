using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timelines : MonoBehaviour
{
    public GameObject firstTimelineSpaceship;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("firstConSpaceship"))
        {
            firstTimelineSpaceship.SetActive(true);
        }
    }
}
