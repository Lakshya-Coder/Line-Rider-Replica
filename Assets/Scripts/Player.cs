using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(Constants.START_BUTTON))
            rb.bodyType = RigidbodyType2D.Dynamic;
    }
} // class
