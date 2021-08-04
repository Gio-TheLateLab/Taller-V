using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightG1 : MonoBehaviour {

    EnemyControllerG1 enemyController;
    Renderer renderer;

    void Awake() {
        enemyController = GetComponentInParent<EnemyControllerG1>();
        renderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            enemyController.PlayerSpoted(other.transform);
            renderer.material.color = Color.red;
        }
    }
}
