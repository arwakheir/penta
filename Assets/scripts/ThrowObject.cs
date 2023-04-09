using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public float throwForce = 500f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Throw();
        }
    }

    void Throw()
    {
        rb.AddForce(transform.right * throwForce);
    }
}
