using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;

    private float originalPlayerPositionX;
    private float originalPlayerPositonZ;
    private Vector3 originalCameraPosition;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            originalPlayerPositionX = playerObject.GetComponent<PlayerController>().transform.position.x;
            originalPlayerPositonZ = playerObject.GetComponent<PlayerController>().transform.position.z;
        }

        originalCameraPosition = transform.position;

    }

    void Update()
    {
        Vector3 newPosition = new Vector3(
            originalCameraPosition.x + (player.transform.position.x - originalPlayerPositionX),
            Mathf.Clamp(originalCameraPosition.y - (player.transform.position.z - originalPlayerPositonZ), 6, 26),
            Mathf.Clamp(originalCameraPosition.z + (player.transform.position.z - originalPlayerPositonZ) * 2, -40, 3));

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);

        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
    }
}