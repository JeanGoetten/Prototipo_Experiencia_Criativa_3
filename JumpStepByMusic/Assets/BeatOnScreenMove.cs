using UnityEngine.UI;
using UnityEngine;

public class BeatOnScreenMove : MonoBehaviour
{
    [SerializeField] private GameObject beatOnScreen;
    private int beatCounter = 0;
    private float x = 150f;
    [SerializeField] private float stepIncrement = 200f;

    [SerializeField] private GameObject imgBeatBar;
    [SerializeField] private Color color01;
    [SerializeField] private Color color02;
    private bool colorChanged;

    private void Start()
    {
        
        colorChanged = false;
    }

    public void MoveBeatOnScreen()
    {
        beatCounter++;
        if(beatCounter < 8)
        {
            x += stepIncrement; 
            beatOnScreen.transform.position = new Vector3(x, beatOnScreen.transform.position.y, beatOnScreen.transform.position.z); 
        }
        else
        {
            beatCounter = 0; 
            x = 150f; 
            beatOnScreen.transform.position = new Vector3(x, beatOnScreen.transform.position.y, beatOnScreen.transform.position.z);
        }
    }
    public void ChangeColor()
    {
        if(colorChanged)
        {
            imgBeatBar.GetComponent<Image>().color = color01;
            colorChanged = false;
            Debug.Log("Color 1"); 
        }
        else
        {
            imgBeatBar.GetComponent<Image>().color = color02;
            colorChanged = true;
            Debug.Log("Color 2");
        }
    }
}
