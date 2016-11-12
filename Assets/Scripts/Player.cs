using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float JumpSpeed;
    public float dashSpeed;

    private bool onGround;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = Camera.main.transform.TransformDirection(movement);
        transform.Translate(movement.x, 0, movement.z);

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * JumpSpeed);
                onGround = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position = new Vector3(transform.position.x + (horizontal * dashSpeed), transform.position.y, transform.position.z + (vertical * dashSpeed));
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    void FixedUpdate ()
    {

    }
}
