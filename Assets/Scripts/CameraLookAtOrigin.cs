using UnityEngine;
using System.Collections;

public class CameraLookAtOrigin : MonoBehaviour {

	// Use this for initialization
	void Update () {
        //FIND THE ANGLE BETWEEN THE ORIGIN AND THE CAMERA
        float angle = AngleBetweenTwoPoints(new Vector3(0, 0, 0), transform.position);


        //ROTATE CAMERA TOWARDS ORIGIN
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.x - b.x, a.z - b.z) * Mathf.Rad2Deg;
    }
}
