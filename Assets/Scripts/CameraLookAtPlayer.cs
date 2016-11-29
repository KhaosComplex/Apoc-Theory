
using UnityEngine;
using System.Collections;

public class CameraLookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float clampMinY;
    [SerializeField] private float clampMaxY;
    [SerializeField] private float clampMinZ;
    [SerializeField] private float clampMaxZ;
    [SerializeField] private float meleeRange;
    [SerializeField] private float meleeRangeCameraBoostY;
    [SerializeField] private float meleeRangeCameraBoostZ;

    private float startingPlayerPositionX;
    private float startingPlayerPositionZ;
    private Vector3 startingCameraPosition;

    void Start()
    {
        //SAVE THE STARTING POSITIONS SO WE CAN REFERENCE THEM LATER IN OUR CAMERA TRANSFORMS
        startingPlayerPositionX = player.transform.position.x;
        startingPlayerPositionZ = player.transform.position.z;
        startingCameraPosition = transform.position;
    }

    void Update()
    {
        float x, y, z;
        bool isInMeleeRange = false;

        //CHECK IF WE'RE IN MELEE RANGE FIRST
        float distanceBetweenPlayerAndTarget = Vector3.Distance(player.transform.position, target.transform.position);

        if (distanceBetweenPlayerAndTarget <= meleeRange)
        {
            //TELL OUR ROTATION SCRIPT THAT WE'RE GOING TO LOOK AT THE TARGET INSTEAD
            isInMeleeRange = true;

            //UPDATE CAMERA POSITION FOR MELEE RANGE
            x = startingCameraPosition.x + (player.transform.position.x - startingPlayerPositionX);
            y = Mathf.Clamp(startingCameraPosition.y - (player.transform.position.z - startingPlayerPositionZ) * meleeRangeCameraBoostY, clampMinY, clampMaxY);
            z = Mathf.Clamp(startingCameraPosition.z + (player.transform.position.z - startingPlayerPositionZ) * 2 * meleeRangeCameraBoostZ, clampMinZ, clampMaxZ);

        }
        else
        {
            //UPDATE CAMERA POSITION FOR NON-MELEE RANGE
            x = startingCameraPosition.x + (player.transform.position.x - startingPlayerPositionX);
            y = Mathf.Clamp(startingCameraPosition.y - (player.transform.position.z - startingPlayerPositionZ), clampMinY, clampMaxY);
            z = Mathf.Clamp(startingCameraPosition.z + (player.transform.position.z - startingPlayerPositionZ) * 2, clampMinZ, clampMaxZ);
        }

        //SET THE CAMERA POSITION SMOOTHLY
        Vector3 newCameraPosition = new Vector3(x, y, z);
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * moveSpeed);


        //SET CAMERA LOOK AT ROTATION DEPENDENT ON RANGE
        if (isInMeleeRange)
        {
            //SET CAMERA TO LOOK AT TARGET SMOOTHLY
            Vector3 relativePosToTarget = target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePosToTarget);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);

        }
        else
        {
            //SET CAMERA TO LOOK AT PLAYER SMOOTHLY
            Vector3 relativePosToPlayer = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePosToPlayer);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }
    }
}