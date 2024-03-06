using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatOnScreenMove : MonoBehaviour
{
    [SerializeField] private GameObject beatOnScreen;
    private int beatCounter = 0;
    private float x = 150f;

    private void Start()
    {
        //beatOnScreen.transform.position = new Vector3(x, beatOnScreen.transform.position.y, beatOnScreen.transform.position.z);
    }

    public void MoveBeatOnScreen()
    {
        beatCounter++;
        if(beatCounter < 16)
        {
            x += 106.6666666666667f; 
            beatOnScreen.transform.position = new Vector3(x, beatOnScreen.transform.position.y, beatOnScreen.transform.position.z); 
        }
        else
        {
            beatCounter = 0; 
            x = 150f; 
            beatOnScreen.transform.position = new Vector3(x, beatOnScreen.transform.position.y, beatOnScreen.transform.position.z);
        }
    }
}
