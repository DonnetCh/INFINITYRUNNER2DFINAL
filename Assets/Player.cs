using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    public bool isGrounded;
    private GameManager gm;
    public Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();   
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal == Input.GetAxisRaw("Horizontal"))
        {
            animator.SetTrigger("Run");
        }
        rb.AddForce (new Vector2(horizontal * speed, rb.velocity.y));
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jump);
            isGrounded = false;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            animator.SetTrigger("Hold");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // gm.HighScore();
            
            PlayerPrefs.GetInt("Score", 0);
            SceneManager.LoadScene(0);
        }
    }
}
