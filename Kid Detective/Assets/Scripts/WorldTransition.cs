using UnityEngine;
using System.Collections;

public class WorldTransition : MonoBehaviour {

    public static bool good;

    public GameObject[] goodGOS;
    public GameObject[] badGOS;
    public GameObject[] peopleGOS;

	// Use this for initialization
	void Start () {

        good = false;

        goodGOS = GameObject.FindGameObjectsWithTag("Good");
        badGOS = GameObject.FindGameObjectsWithTag("Bad");
        peopleGOS = GameObject.FindGameObjectsWithTag("People");

	}
	
	// Update is called once per frame
	void Update () {

        if (good)
        {
            foreach (var go in goodGOS)
            {
                if (go != null)
                    go.SetActive(true);

            }

            foreach (var go in badGOS)
            {
                if (go != null)
                    go.SetActive(false);

            }
            foreach (var go in peopleGOS)
            {
                if (go != null)
                    go.SetActive(false);

            }

        }
        else
        {
            foreach (var go in goodGOS)
            {
                if (go != null)
                    go.SetActive(false);

            }

            foreach (var go in badGOS)
            {
                if (go != null)
                    go.SetActive(true);

            } 
            
            foreach (var go in peopleGOS)
            {
                if (go != null)
                    go.SetActive(true);

            }
        }
	
	}
}
