using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTimerEnd : MonoBehaviour
{
    public GameObject lose_screen;
    public GameObject player;
    public PlayerMovement player_move;
    public void ShowScreen()
    {
         lose_screen.SetActive(true);
         Destroy(player);
         player_move.enabled = false;
    }
    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
