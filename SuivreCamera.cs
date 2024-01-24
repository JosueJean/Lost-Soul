using UnityEngine;

public class SuivreCamera : MonoBehaviour
{
    public string tagCamera = "CameraMouvement"; // Spécifiez le tag de votre caméra ici
    private Transform cameraTransform;

    private void Start()
    {
        // Recherchez la caméra en fonction du tag spécifié.
        GameObject cameraObject = GameObject.FindGameObjectWithTag(tagCamera);

        if (cameraObject != null)
        {
            cameraTransform = cameraObject.transform;
        }
        else
        {
            Debug.LogError("Aucune caméra avec le tag spécifié n'a été trouvée.");
        }
    }

    private void Update()
    {
        // Assurez-vous que l'image d'arrière-plan suit la position de la caméra en X et en Y.
        if (cameraTransform != null)
        {
            transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, transform.position.z);
        }
    }
}
