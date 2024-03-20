using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DarkMode : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private UnityEvent _trigger;
    [SerializeField] private Collider _collider;

    public static bool darkModeisActive = true;

    private Animator selfAnim; 

    private void Awake()
    {
        selfAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        darkModeisActive = true;
        _collider.enabled = true;

    }

    private void Update()
    {
        if (darkModeisActive)
        {
            _collider.enabled = true;
        }
        else
        {
            _collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            selfAnim.SetBool("pressed", true);
            audioSource.pitch = -1;

            _trigger.Invoke();

            darkModeisActive = false;
            LightMode.lightModeisActive = true;
        }
    }
}
