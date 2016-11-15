using UnityEngine;
using System.Collections;

public class CameraLookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float clampMinY;
    [SerializeField] private float clampMaxY;
    [SerializeField] private float clampMinZ;
    [SerializeField] private float clampMaxZ;

    private float startingPlayerPositionX;
    private float startingPlayerPositonZ;
    private Vector3 startingCameraPosition;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            startingPlayerPositionX = playerObject.GetComponent<PlayerController>().transform.position.x;
            startingPlayerPositonZ = playerObject.GetComponent<PlayerController>().transform.position.z;
        }

        startingCameraPosition = transform.position;

    }

    void Update()
    {
        Vector3 newCameraPosition = new Vector3(
            startingCameraPosition.x + (player.transform.position.x - startingPlayerPositionX),
            Mathf.Clamp(startingCameraPosition.y - (player.transform.position.z - startingPlayerPositonZ), clampMinY, clampMaxY),
            Mathf.Clamp(startingCameraPosition.z + (player.transform.position.z - startingPlayerPositonZ) * 2, clampMinZ, clampMaxZ));

        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * moveSpeed);

        Vector3 relativePosToPlayer = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePosToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
    }
}