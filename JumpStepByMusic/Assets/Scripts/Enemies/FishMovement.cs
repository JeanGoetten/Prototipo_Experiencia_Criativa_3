using System;
using UnityEngine;
using UnityEngine.Events;

public class FishMovement : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void Jump()
    {
        anim.SetTrigger("jump");  
    }
}