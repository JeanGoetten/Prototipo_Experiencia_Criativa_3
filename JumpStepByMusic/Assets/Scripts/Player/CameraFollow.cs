using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform camTransform;
    Transform playerTransform;
    public float followspeed;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        camTransform = Camera.main.transform;
    }

    void Update()
    {

        Vector3 targetPosition = new Vector3(playerTransform.position.x, camTransform.position.y, camTransform.position.z);

        camTransform.position = Vector3.Lerp(camTransform.position, targetPosition, Time.deltaTime * followspeed);
    }
}
