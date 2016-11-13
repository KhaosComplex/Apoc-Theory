using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float JumpSpeed;
    public float dashDistance;

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

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            float deltaX = Input.GetAxis("Horizontal");
            float deltaZ = Input.GetAxis("Vertical");
            if (!(deltaX == 0 && deltaZ == 0)) {
                float hyp = Mathf.Pow(Mathf.Pow(deltaX, 2f) + Mathf.Pow(deltaZ, 2f), .5f);
                float mod = dashDistance / hyp;
                transform.position = new Vector3(transform.position.x + (deltaX * mod), transform.position.y, transform.position.z + (deltaZ * mod));
            }
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
