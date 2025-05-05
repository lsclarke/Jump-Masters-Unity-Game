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
    public int fruit_Count;

    public TextMeshProUGUI[] OrbScoreCountText;
    public int orb_Count;

    public TextMeshProUGUI[] HeartScoreCountText;
    public int heart_Count;

    public GameObject[] Orbs = new GameObject[3];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int index = 0; index < FruitScoreCountText.Length; index++) FruitScoreCountText[index].text = "X: " + fruit_Count;

        for (int index = 0; index < FruitScoreCountText.Length; index++) OrbScoreCountText[index].text = "Orbs : " + orb_Count;

        for (int index = 0; index < FruitScoreCountText.Length; index++) HeartScoreCountText[index].text = "Hearts: " + heart_Count;

        switch (orb_Count)
        {
            case 3:
                break;
        }
    }
}
