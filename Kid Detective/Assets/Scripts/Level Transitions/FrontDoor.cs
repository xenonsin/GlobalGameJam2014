using UnityEngine;
using System.Collections;

public class FrontDoor : MonoBehaviour {

    //public bool spotted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //spotted = Physics2D.OverlapCircle(transform.localPosition, 1.0f, 1 << LayerMask.NameToLayer("Player"));

        if (Player.talkedToDog && this.GetComponent<MofoDoor>().active)
            Application.LoadLevel("Living Room");
	}
}
