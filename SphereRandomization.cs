using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRandomization : MonoBehaviour {

    Renderer renderer;
    float cooldown = 1.5f, time = 0;

    void Start() {

        renderer = GetComponent<Renderer>();
        time = cooldown;
    }

    void Update() {

        if (time >= cooldown && Input.GetButtonDown("Fire1")) {

            float r = Random.Range(0.2f, 0.8f);
            float g = Random.Range(0.2f, 0.8f);
            float b = Random.Range(0.2f, 0.8f);

            Color randomColor = new Color(r,g,b);
            renderer.material.color = randomColor;

            float scaleMultiplier = Random.Range(0.5f, 2f);
            transform.localScale = Vector3.one * scaleMultiplier;

            time = 0;
        }

        time += Time.deltaTime;
    }
}
