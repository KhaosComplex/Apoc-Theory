﻿
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float dashDistance;
    [SerializeField]
    private float HP;
    private float gravity;

    private bool isOnGround;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
    }

    void Update()
    {
        //GET THE CHARACTER CONTROLLER AND DIRECTION OF MOVEMENT IN RELATION TO SPEED
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        //CREATE THE MOVEMENT DIRECTION VECTOR
        Vector3 moveDirection = new Vector3(horizontalMovement, 0, verticalMovement);
        moveDirection *= movementSpeed;
        moveDirection = transform.TransformDirection(moveDirection);

        //IF SHIFT KEY OR RIGHT CLICK IS PRESSED
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            // GET THE CHANGE IN DISTANCE REQUIRED TO DASH (AKA DIRECTION)
            float deltaX = horizontalMovement;
            float deltaZ = verticalMovement;

            // AS LONG AS BOTH DISTANCES AREN'T 0
            if (!(deltaX == 0 && deltaZ == 0))
            {
                //GET THE HYPOTENUSE OF THE TWO DISTANCES
                float hyp = Mathf.Pow(Mathf.Pow(deltaX, 2f) + Mathf.Pow(deltaZ, 2f), .5f);
                //FIGURE OUT THE APPROPIATE RATE TO APPLY TO DELTAX/Y TO TRAVEL THE DASH DISTANCE IN THE PROPER DIRECTION
                float rate = dashDistance / hyp;

                //FINALLY, SET THE POSITION
                transform.position = new Vector3(transform.position.x + (deltaX * rate), transform.position.y, transform.position.z + (deltaZ * rate));
            }
        }

        //IF PLAYER IS ON THE GROUND AND SPACE IS PRESSED
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //moveDirection.y = jumpSpeed;
            isOnGround = false;
        }

        if (isOnGround) gravity = 0;
        else gravity += -9.81f;

        //moveDirection.y = gravity;

        //Debug.Log(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);

    }

    void OnCollisionEnter(Collision other)
    {
        //WHEN THE PLAYER HITS THE GROUND MAKE SURE THE GAME KNOWS
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    public float getHP()
    {
        return HP;
    }

    public void setHP(float newHP)
    {
        HP = newHP;
    }

    public void takeDamage(float damage)
    {
        HP = HP - damage;
    }
}