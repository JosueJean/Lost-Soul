using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class fantomAnim : MonoBehaviour
{
    public Rigidbody rb;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("plateform"))
        {
            isGrounded = false;
        }
    }
}
