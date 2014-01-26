using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
    
    Player.outCome = 0;

    Player.obtainedKiss = false;
    Player.obtainedBribe = false;

    Player.choco = false;

    Player.talkedToDog = false;
    Player.talkedToUncle = false;
    Player.talkedToGrandma = false;
    Player.talkedToGrandpa = false;
    Player.talkedToAunt = false;
    Player.talkedToDad = false;
    Player.talkedToMom = false;
    Player.talkedToKathy = false;

    Player.howManyPunched = 0;

    Player.punchedDog = false;
    Player.punchedUncle = false;
    Player.punchedGrandma = false;
    Player.punchedGrandpa = false;
    Player.punchedAunt = false;
    Player.punchedDad = false;
    Player.punchedMom = false;

    WorldTransition.good = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
