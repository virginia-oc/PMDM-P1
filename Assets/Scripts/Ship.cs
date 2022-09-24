using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float velocity = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float deltaX = horizontal * velocity * Time.deltaTime;
        float deltaY = vertical * velocity * Time.deltaTime;

        if (transform.position.x + deltaX > 6 || 
            transform.position.x + deltaX < -6)
            deltaX = 0;
        
        if (transform.position.y + deltaY > 4.5 ||
            transform.position.y + deltaY < -4.5)       
            deltaY = 0;
        
        transform.Translate(deltaX, deltaY, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}