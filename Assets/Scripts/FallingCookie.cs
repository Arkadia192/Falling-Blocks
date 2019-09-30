using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCookie : MonoBehaviour {

    public float speed = 7f;
	
	void Update () {

        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 0.5)
        {
            Destroy(gameObject);
        }
	}
}
