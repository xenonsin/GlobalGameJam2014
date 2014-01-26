using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Texture2D Portrait;
    public static int outCome = 0;

    public static bool obtainedKiss = false;
    public static bool obtainedBribe = false;

    public GameObject chocos;
    public static bool choco = false;

    public static bool talkedToDog = false;
    public static bool talkedToUncle = false;
    public static bool talkedToGrandma = false;
    public static bool talkedToGrandpa = false;
    public static bool talkedToAunt = false;
    public static bool talkedToDad = false;
    public static bool talkedToMom = false;

    public static int howManyPunched = 0;

    public static bool punchedDog = false;
    public static bool punchedUncle = false;
    public static bool punchedGrandma = false;
    public static bool punchedGrandpa = false;
    public static bool punchedAunt = false;
    public static bool punchedDad = false;
    public static bool punchedMom = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (choco)
        {
            chocos.SetActive(true);
        }
        else
        {
            chocos.SetActive(false);
        }
	
	}
}
