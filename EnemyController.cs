using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] GameObject nodesRoot;
    [SerializeField] float patrolSpeed = 3f, chaseSpeed = 6f, stoppingDistance = 0.75f;
    float speed;
    Animator animator;

    Transform[] nodes;
    int index = 0; // current node
    Transform target;

    int state = 0; // 0 = Patrol

    void Start() {

        animator = GetComponentInChildren<Animator>();
        nodes = new Transform[nodesRoot.transform.childCount];
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i] = nodesRoot.transform.GetChild(i);
        }
        target = nodes[index];
        speed = patrolSpeed;
        animator.SetFloat("Speed", 0);


    }

    void Update() {

        if (state == 0) {
            Patrol();
        } else if (state == 1) {
            Attack();
        }

        // Smooth rotation
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, patrolSpeed * 10 * Time.deltaTime);

        // Move forward
        transform.position += transform.forward * Time.deltaTime * patrolSpeed;
    }

    void Attack() {
        // If we are close to the player reset the game
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= 2f) {
            
        }
    }

    void Patrol() {
        // If we are close to the node, set a new target
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= stoppingDistance) {
            index = (index + 1) % nodes.Length;
            target = nodes[index];
        }
    }

    public void OnSight(Transform other) {
        target = other.transform;
        speed = chaseSpeed;
        state = 1;
        animator.SetFloat("Speed", 1);
    }
}
