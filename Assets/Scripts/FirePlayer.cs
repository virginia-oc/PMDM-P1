using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    [SerializeField] float velocity = 6;
    [SerializeField] Transform prefabExplosion;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EdgeX")
            Destroy(gameObject);
        else if (collision.tag == "Enemy" || collision.tag == "FireEnemy")
        {
            Transform explosion = Instantiate(prefabExplosion,
                collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion.gameObject, 1f);
            Destroy(collision.gameObject);

            if (collision.tag == "Enemy")
                Ship.points += 10;
        }
    }
}
