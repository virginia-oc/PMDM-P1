using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForLevel1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForLevel1()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Level1");
    }
}
