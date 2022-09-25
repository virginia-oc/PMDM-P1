using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float velocityX = 0;
    [SerializeField] float velocityY = 2f;
    [SerializeField] Transform prefabFireEnemy;
    private float VoY = 2f; //Initial velocity in OY
    private float VoX = -2f; //Initial velocity in OX
    private double collisionsY = 0;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        float pause = UnityEngine.Random.Range(2.0f, 6.0f);
        yield return new WaitForSeconds(pause);

        GetComponent<AudioSource>().Play();

        Transform fireEnemy = Instantiate(prefabFireEnemy,
            transform.position, Quaternion.identity);

        Physics2D.IgnoreCollision(fireEnemy.GetComponent<Collider2D>(), 
            GetComponent<Collider2D>());

        StartCoroutine(Shot());
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(
            velocityX * Time.deltaTime,
            velocityY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EdgeX")
        {
            Menu.GameOver();
        }
        else if (other.tag == "EdgeCenter")
        {
            velocityX = 0;
            velocityY = (float) (VoY * Math.Pow(-1, collisionsY));
        }   
        else if (other.tag == "EdgeY")
        {
            collisionsY++;
            velocityX = VoX;
            velocityY = 0;         
        }
    }
}
