using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float HP;

    private bool isOnGround;

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        //movement = Camera.main.transform.TransformDirection(movement);
        transform.Translate(movement.x, 0, movement.z);

        //IF SHIFT KEY OR RIGHT CLICK IS PRESSED
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            // GET THE CHANGE IN DISTANCE REQUIRED TO DASH (AKA DIRECTION)
            float deltaX = Input.GetAxis("Horizontal");
            float deltaZ = Input.GetAxis("Vertical");

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
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
            isOnGround = false;
        }

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
}
