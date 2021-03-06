﻿using UnityEngine;
using System.Collections;

public class CameraLookAtBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;

    private float playerTransformX;
    private float playerTransformZ;
    private Vector3 positionToBeAt;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerTransformX = playerObject.GetComponent<PlayerController>().transform.position.x;
            playerTransformZ = playerObject.GetComponent<PlayerController>().transform.position.z;
        }
        positionToBeAt = transform.position;

    }

    void Update()
    {
        Vector3 newPosition = new Vector3(positionToBeAt.x + (player.transform.position.x - playerTransformX), positionToBeAt.y - (player.transform.position.z - playerTransformZ), positionToBeAt.z + (player.transform.position.z - playerTransformZ) * 2);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveSpeed);
        positionToBeAt = newPosition;
        //Vector3 bossMod = new Vector3(boss.transform.position.x, boss.transform.position.y, boss.transform.position.z - 10); doesn't do anything yet


        Vector3 relativePos = boss.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        //transform.LookAt(target.transform);
        playerTransformX = player.transform.position.x;
        playerTransformZ = player.transform.position.z;
    }
}