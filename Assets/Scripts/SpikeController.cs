using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private Transform end;
    [SerializeField] private float timeToWait;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float timeToDelete;

    private float timeToMove;
    private GameObject playerObject;

    private float originalPositionY;
    private bool delete;
    private bool hasntHurtPlayer;


    void Start()
    {
        timeToMove = Time.timeSinceLevelLoad + timeToWait;
        originalPositionY = transform.position.y;
        hasntHurtPlayer = true;

        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //DELETE THE OBJECT ONCE IT'S FINISHED AND THE TIME HAS PASSED TO REMOVE IT
        if (delete && Time.timeSinceLevelLoad >= timeToDelete)
        {
            Destroy(this.gameObject);
        }

        //MAKE SURE TO PREPARE FOR DELETION AFTER FINISHED SPIKING
        if (transform.position.y >=  end.position.y && !delete)
        {
            delete = true;
            timeToDelete = Time.timeSinceLevelLoad + timeToDelete;
        }

        //SPIKE UP AS SOON AS ENOUGH TIME HAS PASSED
        if (Time.timeSinceLevelLoad >= timeToMove && !delete)
        {
            transform.position = Vector3.MoveTowards(model.transform.position, end.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //ONLY HURT THE PLAYER ONCE THE SPIKE IS MOVING
        if (Time.timeSinceLevelLoad >= timeToMove)
        {
            //IF PLAYER GETS HIT, HAVE PLAYER LOSE HEALTH
            if (other.gameObject.tag.Equals("Player") && hasntHurtPlayer)
            {
                playerObject.GetComponent<PlayerController>().takeDamage(damage);
                hasntHurtPlayer = false;
            }
        }
    }

}
