using UnityEngine;

public class SuivreCamera : MonoBehaviour
{
    public string tagCamera = "CameraMouvement"; // Sp�cifiez le tag de votre cam�ra ici
    private Transform cameraTransform;

    private void Start()
    {
        // Recherchez la cam�ra en fonction du tag sp�cifi�.
        GameObject cameraObject = GameObject.FindGameObjectWithTag(tagCamera);

        if (cameraObject != null)
        {
            cameraTransform = cameraObject.transform;
        }
        else
        {
            Debug.LogError("Aucune cam�ra avec le tag sp�cifi� n'a �t� trouv�e.");
        }
    }

    private void Update()
    {
        // Assurez-vous que l'image d'arri�re-plan suit la position de la cam�ra en X et en Y.
        if (cameraTransform != null)
        {
            transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, transform.position.z);
        }
    }
}
