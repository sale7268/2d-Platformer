using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float height;
    public float jumpForce;
    private Rigidbody rb;
    private bool grounded;
    private Vector3 jump;
    public GameObject Coins;
    public GameObject Points;
    public int currentCoins = 0;
    public int currentPoints = 0;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, height, 0f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal");
        translation = (Input.GetKey(KeyCode.LeftShift)) ? translation * 5 : translation;

        animator.SetFloat("Speed", Mathf.Abs(translation));


        if (CanJump())
            TriggerJump();

        //translation *= Time.deltaTime;

        //transform.Translate(0, 0, translation*speed);
        float y = (translation < 0) ? 270 : 90;
        Vector3 input = new Vector3(0, y, 0);
        transform.eulerAngles = input;
    }

    private void OnCollisionStay()
    {
        grounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Water(Clone)")
        {
            Debug.Log("Avoid water Ethan, you didn't learn to swim......LO5ER");
        }
        if(collision.gameObject.name == "QuestionMark(Clone)")
        {
            currentCoins++;
            currentPoints += 100;
            Coins.GetComponent<TextMeshProUGUI>().text = currentCoins.ToString();
            Points.GetComponent<TextMeshProUGUI>().text = currentPoints.ToString();
        }
        if (collision.gameObject.name == "Brick(Clone)")
        {
            currentPoints += 100;
            Points.GetComponent<TextMeshProUGUI>().text = currentPoints.ToString();
            Debug.Log("Brick Destroyed, implementation of that coming soonzzz");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Finish(Clone)")
        {
            Debug.Log("You Finished...... But at what cost?..... Thanos, is that you?");
        }
    }

    private bool CanJump()
    {
        return Input.GetButton("Jump") && grounded;
    }

    private void TriggerJump()
    {
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        grounded = false;
    }
}
