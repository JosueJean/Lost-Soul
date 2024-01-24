using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovPlayer : MonoBehaviour
{
    public float jumpForce = 10f; // Force du saut du joueur
    private bool isGrounded; // Variable pour v�rifier si le joueur est au sol
    public float margeVersLaGauche = 2.0f; // Marge vers la gauche par rapport � la cam�ra
    private Camera mainCamera; // R�f�rence � la cam�ra

    // Start is called before the first frame update
    void Start()
    {
        // Trouver la cam�ra par le tag
        mainCamera = GameObject.FindGameObjectWithTag("CameraMouvement").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Saut avec la fl�che du haut
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Suivre la cam�ra avec une marge vers la gauche
        if (mainCamera != null)
        {
            float cameraLeftEdge = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;
            float playerX = Mathf.Max(transform.position.x, cameraLeftEdge + margeVersLaGauche);
            transform.position = new Vector3(playerX, transform.position.y, transform.position.z);
        }
    }

    // V�rification du sol
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ObjetDead"))
        {
            // Recommencer le niveau en rechargeant la sc�ne
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.collider.CompareTag("Plateform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Plateform"))
        {
            isGrounded = false;
        }
    }
}
