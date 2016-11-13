using UnityEngine;
using System.Collections;

public class LookAtOrigin : MonoBehaviour {

	// Use this for initialization
	void Update () {
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(new Vector3(0, 0, 0), transform.position);


        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.x - b.x, a.z - b.z) * Mathf.Rad2Deg;
    }
}
