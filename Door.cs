using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Animator _doorAnim;

    private void OnTriggerEnter(Collider other)
    {
        _doorAnim.SetBool("doorOpen", true);
    }

    private void OnTriggerExit(Collider other)  
    {
        _doorAnim.SetBool("doorOpen", false);
    }

    public void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }
}
