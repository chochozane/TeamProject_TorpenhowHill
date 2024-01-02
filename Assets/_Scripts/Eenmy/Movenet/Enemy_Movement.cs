using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float detectionRange = 10.0f;
    public Transform player;

    protected virtual void Move()
    {
        if (player != null)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);


            if (distanceToPlayer <= detectionRange)
            {

                Vector3 directionToPlayer = (player.position - transform.position).normalized;


                transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
            }
        }
    }
}
