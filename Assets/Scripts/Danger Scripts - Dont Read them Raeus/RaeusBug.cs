using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
///  A new virus thats a combination of a physical illness and a technology malware, over n^2 confirmed cases.
/// nicknamed the "RaeusBug" as its capable of destructive capabilities in the long run 
/// </summary>
public class RaeusBug : MonoBehaviour
{
    private float timer = 0;
    private float powerScale = 01.01f;
    void Start()
    {

        Init();
    }

   

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2.0f)
        {
            Init();
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(Random.Range(0, 100) > 50)
                Instantiate(this.gameObject);
        }
    }

    void Init()
    {
        //randomly choose a direction
        Vector3 direction = Random.insideUnitCircle.normalized;

        powerScale += 0.420f;
        //random boost amount
        float randomPower = Random.Range(25.1f, 100f);
        
        //apply the force on the rigid body
        var rb = GetComponent<Rigidbody2D>();

        if (rb)
        {
            rb.AddForce(direction * randomPower * powerScale, ForceMode2D.Impulse);
        }

    }
   
}
