using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Componente: Blinking
 * Permite que una luz cambie su intensidad respecto al tiempo
 * Esto busca llamar la atención del jugador */

public class Blinking : MonoBehaviour {

    float t = 0;

    // Esto nos permite controlar la intesidad (A) y el periodo (T)
    [SerializeField] float A = 1, T = 0.5f;
    Light light;

    void Awake() {
        // Obtenemos el componente luz que lo tiene el mismo objeto
        light = GetComponent<Light>();
    }

    void Update() {

        // Utilizamos una función senoidal (M.A.S) para controlar la luz
        float y = A * ((Mathf.Sin(2 * Mathf.PI * t / T)) + 1.25f);
        light.intensity = y;

        t += Time.deltaTime;
    }
}
