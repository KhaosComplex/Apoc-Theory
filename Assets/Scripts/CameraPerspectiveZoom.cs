
using UnityEngine;
using System.Collections;

public class CameraPerspectiveZoom : MonoBehaviour
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
    [SerializeField]
    private float meleeRange;
    [SerializeField]
    private float DELTA_COEFFICIENT_Y;
    [SerializeField]
    private float MELEE_RANGE_DELTA_COEFFICIENT_Y;
    [SerializeField]
    private float MELEE_RANGE_DELTA_COEFFICIENT_Z;

    private float startingPlayerPositionX;
    private float startingPlayerPositionZ;
    private Vector3 startingCameraPosition;
    private Quaternion startingCameraRotation;

    void Start()
    {
        //SAVE THE STARTING POSITIONS SO WE CAN REFERENCE THEM LATER IN OUR CAMERA TRANSFORMS
        startingPlayerPositionX = player.transform.position.x;
        startingPlayerPositionZ = player.transform.position.z;
        startingCameraPosition = transform.position;
        startingCameraRotation = transform.rotation;
    }

    void Update()
    {
        float x, y, z;

        //CHECK IF WE'RE IN MELEE RANGE FIRST
        /*float distanceBetweenPlayerAndTarget = Vector3.Distance(player.transform.position, target.transform.position);

        if (distanceBetweenPlayerAndTarget <= meleeRange)
        {
            //UPDATE CAMERA POSITION FOR MELEE RANGE
            x = startingCameraPosition.x + (player.transform.position.x - startingPlayerPositionX);
            y = Mathf.Clamp(startingCameraPosition.y - (player.transform.position.z - startingPlayerPositionZ) * DELTA_COEFFICIENT_Y * MELEE_RANGE_DELTA_COEFFICIENT_Y, clampMinY, clampMaxY);
            z = Mathf.Clamp(startingCameraPosition.z + (player.transform.position.z - startingPlayerPositionZ) * MELEE_RANGE_DELTA_COEFFICIENT_Z, clampMinZ, clampMaxZ);

            //SET CAMERA TO LOOK AT TARGET SMOOTHLY
            Vector3 relativePosToTarget = target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePosToTarget);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }
        else
        {
            //UPDATE CAMERA POSITION FOR NON-MELEE RANGE
            x = startingCameraPosition.x + (player.transform.position.x - startingPlayerPositionX);
            y = Mathf.Clamp(startingCameraPosition.y - (player.transform.position.z - startingPlayerPositionZ) * DELTA_COEFFICIENT_Y, clampMinY, clampMaxY);
            z = Mathf.Clamp(startingCameraPosition.z + (player.transform.position.z - startingPlayerPositionZ), clampMinZ, clampMaxZ);

            transform.rotation = Quaternion.Lerp(transform.rotation, startingCameraRotation, Time.deltaTime * moveSpeed);
        }*/

        //UPDATE CAMERA POSITION FOR NON-MELEE RANGE
        x = startingCameraPosition.x + (player.transform.position.x - startingPlayerPositionX);
        y = Mathf.Clamp(startingCameraPosition.y - (player.transform.position.z - startingPlayerPositionZ) * DELTA_COEFFICIENT_Y, clampMinY, clampMaxY);
        z = Mathf.Clamp(startingCameraPosition.z + (player.transform.position.z - startingPlayerPositionZ), clampMinZ, clampMaxZ);

        transform.rotation = Quaternion.Lerp(transform.rotation, startingCameraRotation, Time.deltaTime * moveSpeed);

        //SET THE CAMERA POSITION SMOOTHLY
        Vector3 newCameraPosition = new Vector3(x, y, z);
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * moveSpeed);
    }

    public void shakeCamera()
    {
        GetComponent<AudioSource>().Play();
        iTween.ShakePosition(this.transform.parent.gameObject, new Vector3(1, 0, 0), 1);
    }
}