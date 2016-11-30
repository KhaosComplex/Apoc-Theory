using UnityEngine;
using System.Collections;

public class SlamController : MonoBehaviour {
    [SerializeField] private Transform rotator;
    [SerializeField] private Transform end;
    [SerializeField] private Transform holder;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitTime;

    [SerializeField] private float damage;

    private GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        holder.transform.LookAt(new Vector3(playerObject.transform.position.x, holder.transform.position.y, playerObject.transform.position.z));
    }
	
	// Update is called once per frame
	void Update () {
        if (waitTime > 0)
            waitTime -= Time.fixedDeltaTime;
        else
            rotator.transform.rotation = Quaternion.RotateTowards(rotator.transform.rotation, end.rotation, moveSpeed * Time.deltaTime);
        if (Mathf.Approximately(rotator.rotation.eulerAngles.x, end.rotation.eulerAngles.x))
            Destroy(holder.gameObject, 0.5f);
	}

    void OnTriggerEnter(Collider other)
    {
        //IF PLAYER GETS HIT, HAVE PLAYER LOSE HEALTH
        if (other.gameObject.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().takeDamage(damage);
        }
    }
}
