using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public float vitesseMouvement = 8.0f; // Vitesse de d�placement de la cam�ra vers la droite

    void Update()
    {
        // D�placement de la cam�ra vers la droite
        transform.Translate(Vector3.right * vitesseMouvement * 3 * Time.deltaTime);
    }
}
