﻿
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform childPlayerTransform;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashImmunity;
    [SerializeField] private float HP;
    [SerializeField] private float gravity;
    [SerializeField] private float hitStunDuration;
    [SerializeField] private float hitStunMult;
    [SerializeField] private float meleeSwitchRange;
    [SerializeField] private float meleeRate;
    [SerializeField] private float meleeDamage;
    [SerializeField] private GameObject bossObject;
    //[SerializeField] private float xPositionConstraintPositive;
    //[SerializeField] private float xPositionConstraintNegative;
    //[SerializeField] private float yPositionConstraintPositive;
    //[SerializeField] private float yPositionConstraintNegative;
    [SerializeField] private float zPositionConstraintPositive;
    //[SerializeField] private float zPositionConstraintNegative;
    private float gravityRate = 1f;

    private float maxHP;
    private bool hitStun;
    private bool isGrounded;
    private float distToGround;
    private CharacterController characterController;
    private float hitStunTime;
    private float nextDash;
    private Vector3 playerPoint;
    private Vector3 bossPoint;
    private float distanceToBoss;
    private bool inMelee = false;
    private float nextMelee = 0.5f;
    private GameObject meleeBoxObject;
    private bool dashImmune;
    private float endDashImmune;
    private CameraPerspectiveZoom mainCamera;

    void Start()
    {
        maxHP = HP;
        characterController = GetComponent<CharacterController>();
        characterController.detectCollisions = false;
        distToGround = GetComponent<Collider>().bounds.extents.y;
        hitStunTime = hitStunDuration;
        //bossObject = GameObject.FindWithTag("Boss");
        meleeBoxObject = GameObject.FindWithTag("MeleeBox");
        mainCamera = Camera.main.GetComponent<CameraPerspectiveZoom>();
    }

    void Update()
    {
        if (hitStun)
        {
            hitStunTime -= Time.deltaTime;
            if (hitStunTime <= 0.0f)
            {
                hitStun = false;
                hitStunTime = hitStunDuration;
                movementSpeed = movementSpeed * hitStunMult;
            }
        }

        //MAKE SURE TO CHECK AND SEE IF THE PLAYER SHOULD NO LONGER BE IMMUNE
        if (Time.timeSinceLevelLoad >= endDashImmune)
        {
            dashImmune = false;
        }

        //GET THE CHARACTER CONTROLLER AND DIRECTION OF MOVEMENT IN RELATION TO SPEED
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        //CREATE THE MOVEMENT DIRECTION VECTOR
        Vector3 moveDirection = new Vector3(horizontalMovement, 0, verticalMovement);
        moveDirection *= movementSpeed;
        moveDirection = transform.TransformDirection(moveDirection);

        //ROTATE THE PLAYER MODEL IN THE DIRECTION THE PLAYER IS MOVING
        if (horizontalMovement != 0 || verticalMovement != 0)
            childPlayerTransform.rotation = Quaternion.LookRotation(moveDirection);

        //IF SHIFT KEY OR RIGHT CLICK IS PRESSED
        if (Time.timeSinceLevelLoad > nextDash)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButton("Fire2") || Input.GetAxis("Dash") != 0)
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

                    //FINALLY, MOVE THE PLAYER AT THAT RATE IN THAT DIRECTION
                    characterController.Move(new Vector3((deltaX * rate), 0, (deltaZ * rate)));

                    //MAKE SURE THE PLAYER IS DMG IMMUNE
                    dashImmune = true;

                    //SET THE IMMUNITY TIME INTO EFFECT
                    endDashImmune = Time.timeSinceLevelLoad + dashImmunity;

                    //LASTLY SET OUR DASH COOLDOWN INTO EFFECT
                    nextDash = Time.timeSinceLevelLoad + dashCooldown;            
                }
            }
        }

        RaycastHit hit;
        //AS LONG AS PLAYER IS IN THE AIR CONSTANTLY CHECK TO SEE IF HE HAS GROUNDED
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, distToGround + 0.1f))
        {
            if (hit.collider.CompareTag("ClickCollider"))
                isGrounded = false;
            else
                isGrounded = true;
        }
        else
            isGrounded = false;

        //IF PLAYER IS ON THE GROUND
        if (isGrounded)
        {
            //AND SPACE IS PRESSED
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Jump") != 0)
            {
                gravityRate = jumpSpeed;
                moveDirection.y = gravityRate;
                isGrounded = false;
            }
        }

        //MOVE THE PLAYER
        characterController.Move(moveDirection * Time.deltaTime);

        //MELEE DISTANCE CALCULATIONS
        playerPoint = gameObject.GetComponent<Collider>().ClosestPointOnBounds(bossObject.transform.position);
        bossPoint = bossObject.gameObject.GetComponent<Collider>().ClosestPointOnBounds(gameObject.transform.position);

        distanceToBoss = Vector3.Distance(playerPoint, bossPoint);

        //MELEE CHECKS
        /*if (inMelee == false && distanceToBoss <= meleeSwitchRange)
        {
            GameObject.FindWithTag("Gun").GetComponent<PlayerShooter>().setMelee(true);
            inMelee = true;
        }
        if (inMelee == true && distanceToBoss > meleeSwitchRange)
        {
            GameObject.FindWithTag("Gun").GetComponent<PlayerShooter>().setMelee(false);
            inMelee = false;
        }*/

        //MELEE DAMAGE
        if (inMelee)
        {
            if (Input.GetButton("Fire1") && Time.timeSinceLevelLoad > nextMelee)
            {
                nextMelee = Time.timeSinceLevelLoad + meleeRate;
                if (meleeBoxObject.GetComponent<MeleeController>().doesDamage() == true)
                    bossObject.GetComponent<BossController>().takeDamage(meleeDamage);
            }
        }

        //checkConstraints();

    }

    void FixedUpdate()
    {
        //APPLY GRAVITY ONLY IF IN THE AIR
        if (isGrounded) gravityRate = 0;
        else gravityRate += gravity;

        Vector3 gravityVector = new Vector3(0, gravityRate, 0);

        characterController.Move(gravityVector * Time.deltaTime);
    }

    public float getHP()
    {
        return HP;
    }

    public float getMaxHP()
    {
        return maxHP;
    }

    public void setHP(float newHP)
    {
        HP = newHP;
    }

    public void takeDamage(float damage)
    {
        if (HP != 0 && !dashImmune)
        {
            GetComponent<AudioSource>().Play();
            HP = HP - damage;
            if (HP < 0)
                HP = 0;
        }
        if (hitStun == false)
        {
            hitStun = true;
            movementSpeed = movementSpeed / hitStunMult;
        }
    }

    public void killPlayer()
    {
        HP = 0;
    }

    public bool isInMelee()
    {
        return inMelee;
    }

    /*private void checkConstraints()
    {
        if (transform.position.x > xPositionConstraintPositive)
        {
            transform.position = new Vector3(xPositionConstraintPositive, transform.position.y, transform.position.z);
        }
        if (transform.position.x < xPositionConstraintNegative)
        {
            transform.position = new Vector3(xPositionConstraintNegative, transform.position.y, transform.position.z);
        }
        if (transform.position.y > yPositionConstraintPositive)
        {
            transform.position = new Vector3(transform.position.x, yPositionConstraintPositive, transform.position.z);
        }
        if (transform.position.y < yPositionConstraintNegative)
        {
            transform.position = new Vector3(transform.position.x, yPositionConstraintNegative, transform.position.z);
        }
        if (transform.position.z > zPositionConstraintPositive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPositionConstraintPositive);
        }
        if (transform.position.z < zPositionConstraintNegative)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPositionConstraintNegative);
        }
    }*/

}