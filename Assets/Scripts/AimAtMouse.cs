using UnityEngine;
using System.Collections;

public class AimAtMouse : MonoBehaviour
{
    private GameObject gunObject;
    private Transform gunTransform;

    void Start()
    {
        //GET REFERENCE TO GUN OBJECT TRANSFORM
        gunObject = GameObject.FindWithTag("Gun");
        if (gunObject != null)
        {
            gunTransform = gunObject.transform;
        }
    }

    void Update()
    {
        //GET MOUSE POSITION AND SET IT TO THE MIDDLE OF THE MOUSE CURSOR
        Vector3 mousePos = Input.mousePosition;
        mousePos.y = mousePos.y - 16;

        //CREATE A RAY FROM CAMERA TO MOUSE
        Ray rayCameraToMouse = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit = new RaycastHit();

        //CAST RAY FROM CAMERA TO MOUSE
        if (Physics.Raycast(rayCameraToMouse, out hit, 100))
        {
            //GET THE ANGLE BETWEEN BOTH POINTS
            float angle = AngleBetweenTwoPoints(new Vector2(gunTransform.position.x, gunTransform.position.z), new Vector2(hit.point.x, hit.point.z));

            //ROTATE IN THE DIRECTION OF THE MOUSE (OFFSET 90 FOR PROPER FORWARD AXIS)
            transform.rotation = Quaternion.Euler(new Vector3(0f, angle + 180, 0f));
        }

    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.x - b.x, a.y - b.y) * Mathf.Rad2Deg;
    }
}