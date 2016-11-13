using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 playerPosition;

    void Start()
    {

    }

    void Update()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerPosition = playerObject.transform.position;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.y = mousePos.y - 16;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit = new RaycastHit();

        //If Right mouse button is pressed.
        if (Physics.Raycast(mouseRay, out hit, 100))
        {
            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(new Vector2(playerPosition.x, playerPosition.z), new Vector2(hit.point.x, hit.point.z));

            //Ta Daaa
            transform.rotation = Quaternion.Euler(new Vector3(0f, angle + 90, 0f));
        }

    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.x - b.x, a.y - b.y) * Mathf.Rad2Deg;
    }
}