using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;

    private float playerTransformX;
    private float playerTransformZ;
    private Vector3 positionToBeAt;

    void Start ()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerTransformX = playerObject.GetComponent<Player>().transform.position.x;
            playerTransformZ = playerObject.GetComponent<Player>().transform.position.z;
        }
        positionToBeAt = transform.position;

    }

    void Update ()
    {
        Vector3 newPosition = new Vector3(positionToBeAt.x + target.transform.position.x - playerTransformX, positionToBeAt.y - (target.transform.position.z - playerTransformZ), positionToBeAt.z + target.transform.position.z - playerTransformZ);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
        positionToBeAt = newPosition;

        Vector3 relativePos = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        //transform.LookAt(target.transform);
        playerTransformX = target.transform.position.x;
        playerTransformZ = target.transform.position.z;
    }
}