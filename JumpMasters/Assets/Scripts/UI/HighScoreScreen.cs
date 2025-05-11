using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Audio;
public class HighScoreScreen : MonoBehaviour
{
    public ScoreManager scoreManager;


    public TextMeshProUGUI[] HeartScoreCountText;

    public TextMeshProUGUI[] FruitScoreCountText;

    public TextMeshProUGUI[] TimerCountText;
    public Timer time_script;

    public void ChangeLevel()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        for (int index = 0; index < FruitScoreCountText.Length; index++) FruitScoreCountText[index].text = ": " + scoreManager.fruit_Count;

        for (int index = 0; index < FruitScoreCountText.Length; index++) HeartScoreCountText[index].text = ": " + scoreManager.heart_Count;

        for (int index = 0; index < TimerCountText.Length; index++) TimerCountText[index].text = ": " + time_script.seconds;
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
