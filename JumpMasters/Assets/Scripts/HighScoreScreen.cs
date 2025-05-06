using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
