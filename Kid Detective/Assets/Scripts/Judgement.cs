﻿using UnityEngine;
using System.Collections;

public class Judgement : MonoBehaviour {

    public GameObject Dog;
    public GameObject Uncle;
    public GameObject Grandma;
    public GameObject Grandpa;
    public GameObject Aunt;



	// Use this for initialization
	void Start () {
  
        if (Player.punchedUncle)
        {
            Uncle.SetActive(true);
            Player.howManyPunched++;
        }
        else
            Uncle.SetActive(false);

        if (Player.punchedGrandma)
        {
            Grandma.SetActive(true);
            Player.howManyPunched++;
        }
        else
            Grandma.SetActive(false);

        if (Player.punchedGrandpa)
        {
            Grandpa.SetActive(true);
            Player.howManyPunched++;
        }
        else
            Grandpa.SetActive(false);

        if (Player.punchedAunt)
        {
            Aunt.SetActive(true);
            Player.howManyPunched++;
        }
        else
            Aunt.SetActive(false);


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
