using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControllerG1 : MonoBehaviour {



    int state = 0; // 0 = Patrol
    [SerializeField] Transform path;
    Transform[] nodes;
    int index = 0;
    [SerializeField] float patrolSpeed = 1.5f, chaseSpeed = 6f;
    float currentSpeed = 0;

    Transform target; // A dónde tengo que ir. Esto va cambiando
    Transform player;

    Animator animator;
    SightG1 sightG1;

    void Awake() {
        animator = GetComponentInChildren<Animator>();
        sightG1 = GetComponentInChildren<SightG1>();
    }

    void Start() {

        nodes = new Transform[path.childCount];
        for (int i = 0; i < path.childCount; i++) {
            nodes[i] = path.GetChild(i);
        }

        target = nodes[0];
        currentSpeed = patrolSpeed;
    }

    void Update() {

        if (state == 0) {

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 0.5f) {
                index = (index + 1) % nodes.Length;
                target = nodes[index];
            }
        } else if (state == 1) {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 2.5f) {
                SceneManager.LoadScene("Main G1");
            }
        }

        // Smooth look at. Ref: https://forum.unity.com/threads/smooth-look-at.26141/
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, currentSpeed * Time.deltaTime * 10);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;
    }

    public void PlayerSpoted(Transform other) {
        if (state == 0) {
            player = other;
            target = player;
            currentSpeed = chaseSpeed;
            animator.SetFloat("Speed", 1);
            state = 1;
            
        }
    }

    public void Damage() {
        animator.SetTrigger("Dead");
        state = 2;
        currentSpeed = 0;
        Destroy(sightG1.gameObject);
    }
}
