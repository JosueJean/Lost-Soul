using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovPlayer : MonoBehaviour
{
    public float jumpForce = 10f; // Force du saut du joueur
    private bool isGrounded; // Variable pour vérifier si le joueur est au sol
    public float margeVersLaGauche = 2.0f; // Marge vers la gauche par rapport à la caméra
    private Camera mainCamera; // Référence à la caméra

    // Start is called before the first frame update
    void Start()
    {
        // Trouver la caméra par le tag
        mainCamera = GameObject.FindGameObjectWithTag("CameraMouvement").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Saut avec la flèche du haut
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Suivre la caméra avec une marge vers la gauche
        if (mainCamera != null)
        {
            float cameraLeftEdge = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;
            float playerX = Mathf.Max(transform.position.x, cameraLeftEdge + margeVersLaGauche);
            transform.position = new Vector3(playerX, transform.position.y, transform.position.z);
        }
    }

    // Vérification du sol
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ObjetDead"))
        {
            // Recommencer le niveau en rechargeant la scène
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
