using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Para acceder al sprite y cambiar la opacidad
    private int hitCount = 0; // Contador de impactos
    public GameObject bulletPrefab; // Prefab de la bala para detectar la colisión

    void Start()
    {
        // Obtener el SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisiona es una bala
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitCount++;

            if (hitCount == 1)
            {
                // Primer impacto: reducir opacidad al 50%
                ChangeOpacity(0.5f);
            }
            else if (hitCount == 2)
            {
                // Segundo impacto: destruir el objeto
                Destroy(gameObject);
            }
        }
    }

    // Función para cambiar la opacidad del sprite
    void ChangeOpacity(float opacity)
    {
        // Obtener el color actual del sprite
        Color spriteColor = spriteRenderer.color;
        // Cambiar la opacidad manteniendo el color original
        spriteColor.a = opacity;
        // Asignar el color modificado al sprite
        spriteRenderer.color = spriteColor;
    }
}
