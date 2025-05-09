using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI[] FruitScoreCountText;
    public int fruit_Count = 0;

    public TextMeshProUGUI[] OrbScoreCountText;
    public int orb_Count = 0;

    public TextMeshProUGUI[] HeartScoreCountText;
    public int heart_Count;

    public GameObject[] Orbs = new GameObject[3];
    public GameObject[] Hearts = new GameObject[3];

    public PlayerHealth player_health;

    public Timer clock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int getHeart()
    {
        return heart_Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int index = 0; index < FruitScoreCountText.Length; index++) FruitScoreCountText[index].text = "X: " + fruit_Count;

        for (int index = 0; index < FruitScoreCountText.Length; index++) OrbScoreCountText[index].text = "Orbs : " + orb_Count;

        for (int index = 0; index < FruitScoreCountText.Length; index++) HeartScoreCountText[index].text = "Hearts: " + heart_Count;


        if (orb_Count > 0) Orbs[orb_Count-1].SetActive(true);

        if (player_health.Health > 3) player_health.Health = 3;

        heart_Count = player_health.Health;

        if(heart_Count <= 0)
        {
            Hearts[0].SetActive(false);
            Hearts[1].SetActive(false);
            Hearts[2].SetActive(false);

            clock.StopTimer();
        }

        if (heart_Count == 1)
        {
            Hearts[0].SetActive(true);
            Hearts[1].SetActive(false);
            Hearts[2].SetActive(false);
        }
        if (heart_Count == 2)
        {
            Hearts[0].SetActive(true);
            Hearts[1].SetActive(true);
            Hearts[2].SetActive(false);
        }

        if (heart_Count == 3) {
            Hearts[0].SetActive(true);
            Hearts[1].SetActive(true);
            Hearts[2].SetActive(true);
        }

        
    }
}
