using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator animator;
    public AudioSource audioSource;
    public void Play()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("Play", true);
        audioSource.Play();
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GithubLink()
    {
        Application.OpenURL("https://github.com/lsclarke");
    }

    public void LinkedInLink()
    {
        Application.OpenURL("https://www.linkedin.com/in/lenardclarke/");
    }

    public void ItchLink()
    {
        Application.OpenURL("https://novalen.itch.io/");
    }

  
}
