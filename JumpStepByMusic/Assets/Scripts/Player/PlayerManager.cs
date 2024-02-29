using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public new GameObject camera;
    public GameObject explosion;
    Transform lastSave;
    private int sal = 0;
    private int mortes = 0;
    AudioSource audioSource;
    public AudioClip respawFX;
    public AudioClip finishFX;
    public AudioClip salFX;
    Rigidbody rb;
    static public float MoveSmoot;

    private void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);

        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(camera);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "sal")
        {
            sal++;
            print("Sal Coletado: " + sal);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(salFX, 1.0f);
        }
        if (other.gameObject.tag == "spawnpoint")
        {
            lastSave = other.gameObject.transform;
        }
        if (other.gameObject.tag == "finish")
        {
            audioSource.PlayOneShot(finishFX, 1.0f);

            Destroy(camera);
            SceneManager.LoadScene("Final");
            transform.position = new Vector3(0f, 0f, 0f);

            // SceneManager.LoadScene("Fase2"); 
            // transform.position = new Vector3(0f, 0f, 0f); 
        }
        if (other.gameObject.tag == "finish2")
        {
            SceneManager.LoadScene("Fase3");
            transform.position = new Vector3(0f, 0f, 0f);
        }
        if (other.gameObject.tag == "finish3")
        {
            SceneManager.LoadScene("Fase4");
            transform.position = new Vector3(0f, 0f, 0f);
        }
        if (other.gameObject.tag == "finish4")
        {
            SceneManager.LoadScene("Fase5");
            transform.position = new Vector3(0f, 0f, 0f);
        }
        if (other.gameObject.tag == "finish5")
        {
            SceneManager.LoadScene("Fase6");
            transform.position = new Vector3(0f, 0f, 0f);
        }
        if (other.gameObject.tag == "finish6")
        {
            Destroy(camera);
            SceneManager.LoadScene("Final");
            transform.position = new Vector3(0f, 0f, 0f);
        }
        if (other.gameObject.tag == "final")
        {
            SceneManager.LoadScene("Menu");
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "enemy")
        {
            audioSource.PlayOneShot(respawFX, 0.7f);

            mortes++;
            print("Mortes: " + mortes);

            Instantiate(explosion, transform.position, Quaternion.identity);
            this.transform.position = lastSave.position;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "almondega")
        {
            audioSource.PlayOneShot(respawFX, 0.7f);

            mortes++;
            print("Mortes: " + mortes);

            Instantiate(explosion, transform.position, Quaternion.identity);
            this.transform.position = lastSave.position;
        }
    }
}