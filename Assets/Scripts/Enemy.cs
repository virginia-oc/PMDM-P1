using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float velocityX = 2;
    [SerializeField] float velocityY = 2;
    [SerializeField] Transform prefabFireEnemy;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        float pause = UnityEngine.Random.Range(2.0f, 6.0f);
        yield return new WaitForSeconds(pause);

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
        if (other.tag == "EdgeX" || other.tag == "EdgeCenter")       
            velocityX *= -1;
        else if (other.tag == "EdgeY")
            velocityY *= -1;
    }
}
