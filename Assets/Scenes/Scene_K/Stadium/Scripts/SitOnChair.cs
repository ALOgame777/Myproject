using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitOnChair : MonoBehaviour
{
    public Transform seatPostion;
    private bool isNearChair;

    void Update()
    {
        if(isNearChair && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = seatPostion.position;
            transform.rotation = seatPostion.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Chair"))
        {
            isNearChair = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Chair"))
        {
            isNearChair = false;
        }
    }
}

