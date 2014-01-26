using UnityEngine;
using System.Collections;

public class BedRoomToKitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<MofoDoor>().active)
            Application.LoadLevel("Kitchen");
	
	}
}
