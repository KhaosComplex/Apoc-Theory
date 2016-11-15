
using UnityEngine;
using System.Collections;

public class CameraLookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float clampMinY;
    [SerializeField]
    private float clampMaxY;
    [SerializeField]
    private float clampMinZ;
    [SerializeField]
    private float clampMaxZ;

    private float startingPlayerPositionX;
    private float startingPlayerPositionZ;
    private Vector3 startingCameraPosition;

    void Start()
    {
        startingPlayerPositionX = player.transform.position.x;
        startingPlayerPositionZ = player.transform.position.y;
        startingCameraPosition = transform.position;
    }

    void Update()
    {
        Vector3 newCameraPosition = new Vector3(
            startingCameraPosition.x + (player.transform.position.x - startingPlayerPositionX),
            Mathf.Clamp(startingCameraPosition.y - (player.transform.position.z - startingPlayerPositionZ), clampMinY, clampMaxY),
            Mathf.Clamp(startingCameraPosition.z + (player.transform.position.z - startingPlayerPositionZ) * 2, clampMinZ, clampMaxZ));


        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * moveSpeed);

        Vector3 relativePosToPlayer = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePosToPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
    }
}