using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public event Action<int> OnCountChanged;

    private int count;

    private void Start()
    {
        count = 0;
        playerController.OnPickUpCollision += IncreaseCount;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerController.Move(moveHorizontal, moveVertical);
    }

    private void IncreaseCount()
    {
        count++;
        OnCountChanged?.Invoke(count);
    }
}