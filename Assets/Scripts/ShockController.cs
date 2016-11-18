using UnityEngine;
using System.Collections;

public class ShockController : MonoBehaviour {
    [SerializeField] private Transform end;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stretchSpeed;
    [SerializeField] private float waitTime;
	
	// Update is called once per frame
	void Update () {
        if (waitTime > 0)
            waitTime -= Time.fixedDeltaTime;
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, end.position, moveSpeed * Time.deltaTime);

            transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, end.localScale.x, stretchSpeed * Time.deltaTime),
                Mathf.MoveTowards(transform.localScale.y, end.localScale.y, stretchSpeed * Time.deltaTime),
                Mathf.MoveTowards(transform.localScale.z, end.localScale.z, stretchSpeed * Time.deltaTime));
        }
        if(transform.position == end.position)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
	}
}
