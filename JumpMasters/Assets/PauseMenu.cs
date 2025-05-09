using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool mPaused = false;
    public GameObject menu;

    private void Paused()
    {   
        mPaused = true;
        Time.timeScale = 0f;
        menu.SetActive(mPaused);
    }

    private void UnPaused()
    {
        mPaused = false;
        Time.timeScale = 1f;
        menu.SetActive(mPaused);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (!mPaused)
            {
                Invoke("Paused", 0f);
            }
            else
            {
                Invoke("UnPaused", 0f);
            }
        }
    }
}
