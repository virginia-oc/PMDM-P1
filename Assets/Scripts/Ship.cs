using System.Collections;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float velocity = 4;
    [SerializeField] Transform prefabFirePlayer;
    [SerializeField] TMPro.TextMeshProUGUI counterText;
    [SerializeField] Transform prefabExplosion;
    public static int lives { get; set; }
    public static int points { get; set; }
    private int gameOverFlag = 0;

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
            GetComponent<AudioSource>().Play();
            Transform fire = Instantiate(prefabFirePlayer, transform.position,
                Quaternion.identity);
            Physics2D.IgnoreCollision(fire.GetComponent<Collider2D>(),
                GetComponent<Collider2D>());
        }

        if (lives == 0 && gameOverFlag == 0)
        {
            gameOverFlag = 1;
            Transform explosion = Instantiate(prefabExplosion,
                transform.position, Quaternion.identity);
            
            StartCoroutine(WaitForGameOver(1.0f));
        }
        else if(points == 60)      
            StartCoroutine(WaitForWinScene(2.0f));       

        counterText.text = "Lives left: " + lives;
    }

    private IEnumerator WaitForWinScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Menu.ShowWinScene();
    }

    private IEnumerator WaitForGameOver(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Menu.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "FireEnemy")     
            lives--;    
    }
}
