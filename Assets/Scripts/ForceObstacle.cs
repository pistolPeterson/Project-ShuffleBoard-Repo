using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceObstacle : MonoBehaviour
{
    [SerializeField][Range(25000f, 100000f)] private float forcePower = 66000f;
    [SerializeField] private Transform directionThingy;

    private void OnTriggerStay2D(Collider2D other)
    {
    return;
        if (!other.GetComponent<BallMovement>()) return;
        float distanceToBall = Vector3.Distance(transform.position, other.gameObject.transform.position);

        float appliedForce = forcePower / (distanceToBall * distanceToBall);

        Vector3 direction = directionThingy.position - other.gameObject.transform.position ;

        other.GetComponent<Rigidbody2D>().AddForce((direction * appliedForce), ForceMode2D.Impulse);
    }
}
