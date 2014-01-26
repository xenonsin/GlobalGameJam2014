using UnityEngine;
using System.Collections;

public class Judgement : MonoBehaviour {

    public GameObject Dog;
    public GameObject Uncle;
    public GameObject Grandma;
    public GameObject Grandpa;
    public GameObject Aunt;



	// Use this for initialization
	void Start () {
    if(Player.punchedDog)
        Dog.SetActive(true);
    else
        Dog.SetActive(false);

    if(Player.punchedUncle)
        Uncle.SetActive(true);
    else
        Uncle.SetActive(false);

    if(Player.punchedGrandma)
        Grandma.SetActive(true);
    else
        Grandma.SetActive(false);

    if(Player.punchedGrandpa)
        Grandpa.SetActive(true);
    else
        Grandpa.SetActive(false);

    if(Player.punchedAunt)
        Aunt.SetActive(true);
    else
        Aunt.SetActive(false);


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
