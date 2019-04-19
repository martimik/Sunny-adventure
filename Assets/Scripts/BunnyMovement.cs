using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BunnyMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public GameObject respawn;
    public Animator animator;
    public float runSpeed = 40f;
    public GameObject deathParticle;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isTriggered = false;
    int nextLevel;
    public int lastLevel = 3;

    void OnDisable()
    {
        PlayerPrefs.SetInt("NextLevel", nextLevel + 1);
    }

    void OnEnable()
    {
        nextLevel = PlayerPrefs.GetInt("NextLevel");
    }

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish" && !isTriggered)
        {
            isTriggered = true;
            if (nextLevel > lastLevel)
            {
                SceneManager.LoadScene("EndScreen");
            }
            else
            {
                SceneManager.LoadScene("Level-" + nextLevel);
            }
        }
    }

    void Death()
    {
        Instantiate(deathParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);

        // Respawn
        this.gameObject.transform.position = respawn.transform.position;
    }
}
