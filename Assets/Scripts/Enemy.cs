using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float velocityX = 2;
    [SerializeField] float velocityY = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            velocityX * Time.deltaTime,
            velocityY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EdgeX")       
            velocityX *= -1;

        if (other.tag == "EdgeY")
            velocityY *= -1;
    }
}
