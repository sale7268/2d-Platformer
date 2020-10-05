using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EthanBlendController : MonoBehaviour
{
    private Animator animator;

    private float move = 1;

    public float amplify = 20;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        move = (Input.GetKey(KeyCode.LeftShift)) ? move * amplify : move;

        animator.SetFloat("Speed", Mathf.Abs(move));

        float y = (move < 0) ? 270 : 90;
        Vector3 input = new Vector3(0, y, 0);
        transform.eulerAngles = input;
    }
}
