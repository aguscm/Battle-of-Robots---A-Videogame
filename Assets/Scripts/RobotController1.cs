using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController1 : MonoBehaviour
{
    public KeyCode ButtonWalk;
    public KeyCode ButtonWalkBackwards;
    public KeyCode ButtonAttack;
    public KeyCode ButtonDefend;

    public bool canMove = true;
    public float speed = 2f;
    private Animator animator;
    private Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        if (canMove)
        {
            //Walking
            if (Input.GetKey(ButtonWalk))
            {
                animator.SetBool("Walk", true);
                animator.SetBool("WalkBackwards", false);
                Walk(true);
                //animator.SetTrigger("Walk");

            }
            else if (Input.GetKey(ButtonWalkBackwards))
            {

                animator.SetBool("WalkBackwards", true);
                animator.SetBool("Walk", false);
                Walk(false);
                //animator.SetTrigger("WalkBackwards");
            }
            else
            {
                animator.SetBool("WalkBackwards", false);
                animator.SetBool("Walk", false);
            }

            //Fighting
            if (Input.GetKeyDown(ButtonAttack))
            {
                animator.SetTrigger("Attack");

            }
            else if (Input.GetKeyDown(ButtonDefend))
            {
                animator.SetTrigger("Defend");
            }
        }
    }

    private void Walk(bool Forward)
    {
        var direction = 1;
        if (!Forward)
        {
            direction = -1;
        }

        Vector3 tempVect = new Vector3(0, 0, direction);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + tempVect);
    }
}
