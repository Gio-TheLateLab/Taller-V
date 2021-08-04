using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapG1 : MonoBehaviour {

    Collider collider;
    ParticleSystem ps;

    void Awake() {
        collider = GetComponent<Collider>();
        ps = GetComponentInChildren<ParticleSystem>();
        collider.enabled = false;
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            Activate();
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Enemy")) {
            other.GetComponent<EnemyControllerG1>().Damage();
        }
        
    }

    public void Activate() {
        print("Activate trap");
        collider.enabled = true;
        Invoke("Deactivate", 1f);
        ps.Play();
    }

    void Deactivate() {
        collider.enabled = true;
    }
}
