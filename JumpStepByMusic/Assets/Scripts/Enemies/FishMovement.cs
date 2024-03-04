using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private bool _testOnStart;
    [SerializeField] private float _timeIntervalForTheTest;
    [SerializeField] private float _jumpSize;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _returnSpeed;

    private void Start()
    {
        if (_testOnStart)
        {
            StartCoroutine(Test());
        }
    }
    private void Update()
    {
        
    }
    public void Jump()
    {
        //movimento do peixe
        Debug.Log("Peixe saltando!"); 
    }
    IEnumerator Test()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            Jump(); 
        }
    }
}
