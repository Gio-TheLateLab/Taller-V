using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerG2 : MonoBehaviour {

    [SerializeField] Transform[] nodes;
    Transform target;
    [SerializeField] float speed = 3f;

    int state = 0; // 0 = Patrol
    int index = 0;

    void Start() {

        target = nodes[index];
    }

    void Update() {

        if (state == 0) {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 0.5f) {

                index = (index + 1) % nodes.Length;
                target = nodes[index];
            }
        }

        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * speed * Time.deltaTime);

        transform.position += speed * transform.forward * Time.deltaTime;


    }
}
