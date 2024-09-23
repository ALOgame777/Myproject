using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaAnimation : MonoBehaviour
{
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }


    [PunRPC]
    void SetTrigger(string parameter)
    {
        anim.SetTrigger(parameter);
    }
}
