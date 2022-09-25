using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float velocity = 4;
    [SerializeField] Transform prefabFirePlayer;
    [SerializeField] TMPro.TextMeshProUGUI counterText;
    public static int lives { get; set; }
    public static int points { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        lives = 3;
        points = 0;
        counterText.text = "Lives left: " + lives;
    }

    // Update is called once per frame
    private void Update()
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

        if (Input.GetButtonDown("Jump"))
        {
            Transform fire = Instantiate(prefabFirePlayer, transform.position,
                Quaternion.identity);
            Physics2D.IgnoreCollision(fire.GetComponent<Collider2D>(),
                GetComponent<Collider2D>());
        }

        if (lives == 0)
            Menu.GameOver();
        else if(points == 60)      
            StartCoroutine(WaitForWinScene(2.0f));       

        counterText.text = "Lives left: " + lives;
    }

    private IEnumerator WaitForWinScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Menu.ShowWinScene();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")     
            lives--;
            
    }
}
