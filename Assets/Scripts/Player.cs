using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private Animation thisAnimation;
    public float velocity = 1;
    private Rigidbody rb;
    public int Scorecount = 0;
    public Text Scoretext;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
        Scorecount = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocity;
            thisAnimation.Play();
        }

        if(transform.position.y <= -4 || transform.position.y >= 4)
        {
            SceneManager.LoadScene("GameOver Scene");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("GameOver Scene");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            Scorecount += 1;
            Scoretext.text = "SCORE: " + Scorecount;
        }
    }
}
