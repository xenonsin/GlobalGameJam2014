using UnityEngine;
using System.Collections;

public class Three : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(-3 * Time.deltaTime, 0));

        if (transform.position.x < -7)
        {
            Application.LoadLevel("Four");
        }
	
	}
}
