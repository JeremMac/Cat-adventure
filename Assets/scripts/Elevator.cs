using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform downSwitch;
    public Transform upperSwitch;
    public Transform downPos;
    public Transform upperPos;

    public float speed;
    bool isElevatorDown;

    private Animator downSAnimator;
    private Animator upperSAnimator;


    void Update()
    {
        StartElevator();
    }

    void Start()
    {
        downSAnimator = downSwitch.GetComponent<Animator>();
        upperSAnimator = upperSwitch.GetComponent<Animator>();
    }

    void StartElevator()
    {
        // for the down switch
        if (Vector2.Distance(player.position, downSwitch.position) < 0.5f && Input.GetKeyDown("e"))
        {
            if (transform.position.y <= downPos.position.y)
            {
                isElevatorDown = true;
            }
            else if (transform.position.y >= upperPos.position.y)
            {
                isElevatorDown = false;
            }
        }
        if (isElevatorDown)
        {
            downSAnimator.Play("leverUp");
        }
        else
        {
            downSAnimator.Play("leverDown");
        }
    
        //for the upper switch
        if (Vector2.Distance(player.position, upperSwitch.position) < 0.5f && Input.GetKeyDown("e"))
        {
            if (transform.position.y <= downPos.position.y)
            {
                isElevatorDown = true;
            }
            else if (transform.position.y >= upperPos.position.y)
            {
                isElevatorDown = false;
            }
        }
        if (isElevatorDown)
        {
            upperSAnimator.Play("upperUp");
        }
        else
        {
            upperSAnimator.Play("upperDown");
        }

        if (isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }
    }
}
