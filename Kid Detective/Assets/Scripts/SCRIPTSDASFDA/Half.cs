using UnityEngine;
using System.Collections;

public class Half : MonoBehaviour {

    public AudioClip angelic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        audio.PlayOneShot(angelic);

        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("One");
        }
	
	}
}
