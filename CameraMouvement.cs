using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public float vitesseMouvement = 8.0f; // Vitesse de déplacement de la caméra vers la droite

    void Update()
    {
        // Déplacement de la caméra vers la droite
        transform.Translate(Vector3.right * vitesseMouvement * 3 * Time.deltaTime);
    }
}
