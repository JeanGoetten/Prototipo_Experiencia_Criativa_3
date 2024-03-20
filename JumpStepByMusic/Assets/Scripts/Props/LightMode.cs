using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LightMode : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private UnityEvent _trigger;
    [SerializeField] private Collider _collider; 

    public static bool lightModeisActive = false;

    private Animator selfAnim;

    private void Awake()
    {
        selfAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        lightModeisActive = false;
        _collider.enabled = false;

    }

    private void Update()
    {
        if (lightModeisActive)
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
        if (other.gameObject.tag == "Player")
        {
            selfAnim.SetBool("pressed", true);
            audioSource.pitch = 1;

            _trigger.Invoke();

            lightModeisActive = false;
            DarkMode.darkModeisActive = true;
        }
    }
}
