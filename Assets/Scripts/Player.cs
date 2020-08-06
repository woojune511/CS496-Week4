using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* Check if game object is on ground */
    private bool onGround;

    /* Value for pressure jumping */
    private float jumpPressure;

    /* Minimum Jump Value */
    private float minJump;

    /* Maximum jump value */
    private float maxJumpPressure;

    /* Rigidbody Object for moving and jumping */
    private Rigidbody rigidbody;

    /* Jump Animation */
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;   
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        /* Fall */
        if(rigidbody.position.y < -2)
        {
            rigidbody.transform.position = new Vector3(-6, 4, 4);
        }
        /* For debugging purposes: moving the body */
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 4);
        }
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * 4);
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(Vector3.back * Time.deltaTime * 4);
        }
        
        if(onGround)
        {
            /* Holding Jump Button */
            if(Input.GetButton("Jump"))
            {
                if(jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }
                animator.SetFloat("JumpPressure", jumpPressure + minJump);
                /* For dynamic animation */
                animator.speed = 1f + (jumpPressure/10f);
            }
            /* Not holding jump button */
            else
            {
                if(jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    rigidbody.velocity = new Vector3(jumpPressure / 1.5f, jumpPressure, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                    animator.SetFloat("JumpPressure", 0f);
                    animator.SetBool("onGround", onGround);
                    /* For dynamic animation */
                    animator.speed = 1f;
                }
            }
        }
    }

    /* Check if player touches "ground" */
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            onGround = true;
            animator.SetBool("onGround", onGround);
        }
    }   


}
