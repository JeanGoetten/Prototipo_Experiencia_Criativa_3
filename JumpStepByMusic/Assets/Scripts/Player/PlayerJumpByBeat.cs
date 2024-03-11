using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerJumpByBeat : MonoBehaviour
{
    private Transform pos;
    public float speed = 1.0f;
    float x, y, z;
    private bool verifyGDC;
    public float stepCooldown = 1.0f;
    public float jumpForce;
    Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip waterSplashSFX;
    private Animator anim;
    private bool doubleStep; 

    public float doubleJumpInrease = 1.0f;

    public float animJumpTime = 1.0f;
    void Start()
    {
        pos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        x = 0.0f;
        z = 0.0f;
        verifyGDC = true;
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        //audioSource.PlayOneShot(start, 0.7F);

        doubleStep = false;
    }

    void Update()
    {
        y = transform.position.y;
        float step = speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            A();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            D();
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), step);

    }
    public void A()
    {
        if (verifyGDC)
        {
            if (doubleStep)
            {
                x--;
                Jump(1);
                StartCoroutine(GCD());
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                anim.SetBool("jump", true);
                StartCoroutine(SetJumpAninFalse(animJumpTime));
            }
            else
            {
                x -= 2;
                Jump(doubleJumpInrease);
                StartCoroutine(GCD());
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                anim.SetBool("jump", true);
                StartCoroutine(SetJumpAninFalse(animJumpTime));
            }
            
        }
    }
    public void D()
    {
        if (verifyGDC)
        {
            if(doubleStep)
            {
                x++;
                Jump(1);
                StartCoroutine(GCD());
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                anim.SetBool("jump", true);
                StartCoroutine(SetJumpAninFalse(animJumpTime));
            }
            else
            {
                x += 2;
                Jump(doubleJumpInrease);
                StartCoroutine(GCD());
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                anim.SetBool("jump", true);
                StartCoroutine(SetJumpAninFalse(animJumpTime));
            }
        }
    }
    public void DoubleStep()
    {
        if (doubleStep)
        {
            doubleStep = false;
        }
        else
        {
            doubleStep = true;
        }
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator GCD()
    {
        verifyGDC = false;
        yield return new WaitForSecondsRealtime(stepCooldown);
        verifyGDC = true;
    }
    void Jump(float x)
    {
        rb.AddForce(new Vector3(0f, jumpForce*x, 0.0f));
    }
    IEnumerator SetJumpAninFalse(float animJumpTime)
    {
        audioSource.PlayOneShot(jump, 0.7F);
        yield return new WaitForSeconds(animJumpTime);
        anim.SetBool("jump", false);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Deathzone")
        {
            StartCoroutine(CDRespawn());
        }
        else if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(CDRespawn()); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            audioSource.PlayOneShot(waterSplashSFX, 0.7F);
        }
        if (other.gameObject.tag == "End")
        {
            NextLevel();
        }
    }
    IEnumerator CDRespawn()
    {
        yield return new WaitForSeconds(2);
        Restart();
    }
}