using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : MonoBehaviour {

    [SerializeField] Animator[] animator;

    GameObject player;
    int state = 0; // 0 = Waiting | 1 = Player is inside the trigger | 2 = Animation
    float t = 0;

    void Awake() {

    }

    void Update() {
        if (state == 1) {
            if (Input.GetButtonDown("Fire1")) {
                Animator playerAnimator = player.GetComponent<Animator>();
                playerAnimator.SetTrigger("Activate");
                state = 2;
            }
        } else if (state == 2) {
            t += Time.deltaTime;
            if (t >= 0.75f) { // We wait for the animation (move the arm to the swtich ends)

                for (int i = 0; i < animator.Length; i++) {
                    animator[i].SetTrigger("Activate");
                }
                state = 3;
            }
        } else if (state == 3) {
            t = 0;
            
        }
    }

    void OnTriggerEnter(Collider other) {
        if (state == 0 && other.CompareTag("Player")) {
            player = other.gameObject;
            state = 1;
        } 
    }

    void OnTriggerExit(Collider other) {
        if (state != 3 && other.CompareTag("Player")) {
            state = 0;
        }
    }
}
