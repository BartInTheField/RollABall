using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI winText;

    private void Start()
    {
        InitText();
        gameManager.OnCountChanged += SetCountText;
    }

    private void InitText()
    {
        winText.text = "";
        SetCountText(0);
    }

    private void SetCountText(int count)
    {
        countText.text = "Count: " + count;

        if (count >= 8)
        {
            winText.text = "You win!";
        }
    }
}