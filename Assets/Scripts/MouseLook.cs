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

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(playerPosition);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle + 90, 0f));

    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        Debug.Log(Mathf.Atan2(a.x - b.x, a.y - b.y));
        return Mathf.Atan2(a.x - b.x, a.y - b.y) * Mathf.Rad2Deg;
    }
}