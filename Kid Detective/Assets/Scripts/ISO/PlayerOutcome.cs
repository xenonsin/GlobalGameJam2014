using UnityEngine;
using System.Collections;

public class PlayerOutcome : MonoBehaviour {

    public static int outCome = 0;

	// Use this for initialization
	void Start () {
        iniParser parser = new iniParser();
        parser.Set("Mom", "m1",  "You're an Asshole, son.","");
        parser.Set("Mom", "m2", "I'm Sorry.", "");
        parser.Set("Grandma", "g1", "Asshole.", "");
        parser.Save(IniFiles.DIALOG);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
