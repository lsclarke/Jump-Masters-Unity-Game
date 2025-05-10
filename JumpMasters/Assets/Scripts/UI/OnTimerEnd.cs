using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OnTimerEnd : MonoBehaviour
{
    public GameObject lose_screen;
    public GameObject player;
    public PlayerMovement player_move;

    public AudioSource audioSource;

    public void ShowScreen()
    {
         lose_screen.SetActive(true);
         Destroy(player);
         player_move.enabled = false;
    }
    public void Continue()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }
}
