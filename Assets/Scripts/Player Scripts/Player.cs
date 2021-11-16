using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator animator;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }
    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < maxVelocity)
                forceX = speed;

            animator.SetBool("Walk", true);
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
                forceX = -speed;

            animator.SetBool("Walk", true);
            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));

    }
}
