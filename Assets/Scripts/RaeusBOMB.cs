using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// war crimes were commited by Rae Industries
///
///
/// Peterson N. : they threatened to kill me I had to make this monstrosity
/// 
/// </summary>
public class RaeusBOMB : MonoBehaviour
{
  private Collider2D[] hitColliders = null;

  [SerializeField][Range(50000f, 150000f)] private float explosionPower = 75000f;
  [SerializeField][Range(75f, 750f)] private float explosionRadius = 200f;
  [SerializeField] private float explosionDelay = 2.5f;
  [SerializeField] private float respawnDelay = 2.5f;
  [SerializeField] private GameObject particles; 

  private bool raeusGoingThroughIt = false;

  private bool openState = false;
  private void Start()
  {

  }


  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      openState = !openState;
      particles.gameObject.SetActive(openState);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.GetComponent<BallMovement>() && !raeusGoingThroughIt)
    {
      raeusGoingThroughIt = true;
      //Debug.Log("Raeus: I must fufill my duty I MUST EXPLODE!!!");
      StartCoroutine(DelayThenExplode());
    }
  }

  private IEnumerator DelayThenExplode()
  {
    yield return new WaitForSeconds(explosionDelay);
    RaeusExplodes();
    yield return new WaitForSeconds(respawnDelay);
    //play particle effect to show it respawning 
    //show ball 
    raeusGoingThroughIt = false;

  }

  private void RaeusExplodes()
  {
   // Debug.Log("Raeus: I EXPLODED!!! ");
    hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

    foreach (Collider2D col in hitColliders)
    {
      BallMovement ball = col.GetComponent<BallMovement>();
      if (!ball) return;
      
      
        Vector2 distanceVector = col.transform.position - transform.position;

        if (distanceVector.magnitude <= 0) {return; } //this is so we dont get a divide by zero error 

        float explosionForce = explosionPower / distanceVector.magnitude;
        var rb = col.gameObject.GetComponent<Rigidbody2D>();
        if(!rb) return;
        rb.AddForce(distanceVector.normalized * explosionPower);


    }

  }

  private void OnDrawGizmos()
  {
    Gizmos.DrawWireSphere(transform.position, explosionRadius);
  }
}
