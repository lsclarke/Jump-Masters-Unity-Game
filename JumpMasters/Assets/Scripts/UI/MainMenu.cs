using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator animator;
    public void Play()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("Play", true);
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
