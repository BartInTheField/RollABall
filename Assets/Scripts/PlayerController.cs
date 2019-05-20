using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    public event Action OnPickUpCollision;

    private new Rigidbody rigidbody;
    private float moveHorizontal;
    private float moveVertical;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float moveHorizontal, float moveVertical)
    {
        this.moveHorizontal = moveHorizontal;
        this.moveVertical = moveVertical;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag("Pick Up"))
        {
            otherGameObject.SetActive(false);
            OnPickUpCollision?.Invoke();
        }
    }
}