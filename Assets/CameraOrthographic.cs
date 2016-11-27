
using UnityEngine;
using System.Collections;

public class CameraOrthographic : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject target;
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
        //SAVE THE STARTING POSITIONS SO WE CAN REFERENCE THEM LATER IN OUR CAMERA TRANSFORMS
        startingPlayerPositionX = player.transform.position.x;
        startingPlayerPositionZ = player.transform.position.y;
        startingCameraPosition = transform.position;
    }

    void Update()
    {
        float x, y, z;

        //CHECK IF WE'RE IN MELEE RANGE FIRST
        float distanceBetweenPlayerAndTarget = Vector3.Distance(player.transform.position, target.transform.position);

        //UPDATE CAMERA POSITION FOR NON-MELEE RANGE
        x = startingCameraPosition.x;
        y = startingCameraPosition.y;
        z = startingCameraPosition.z;

        //SET THE CAMERA POSITION SMOOTHLY
        Vector3 newCameraPosition = new Vector3(x, y, z);
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * moveSpeed);
    }
}