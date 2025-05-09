using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
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

        for (int index = 0; index < FruitScoreCountText.Length; index++) HeartScoreCountText[index].text = "Hearts: " + scoreManager.heart_Count;

        for (int index = 0; index < TimerCountText.Length; index++) TimerCountText[index].text = ": " + time_script.seconds;
    }
}
