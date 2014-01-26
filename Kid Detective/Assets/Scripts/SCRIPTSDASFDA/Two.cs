using UnityEngine;
using System.Collections;

public class Two : MonoBehaviour {

    public float speed = 3.0f;
    public float target = 7.0f;
    public string level;
    public bool greater = false;
    public bool lesser = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector2(speed * Time.deltaTime, 0));

        if (greater)
        {
            if (transform.position.x > target)
            {
                Application.LoadLevel(level);
            }
        }
        if (lesser)
        {
            if (transform.position.x < target)
            {
                Application.LoadLevel(level);
            }
        }

	
	}
}
