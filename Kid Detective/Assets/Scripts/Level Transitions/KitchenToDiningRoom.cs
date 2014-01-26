using UnityEngine;
using System.Collections;

public class KitchenToDiningRoom : MonoBehaviour {

    public bool spotted = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        spotted = Physics2D.OverlapCircle(transform.localPosition, 1.0f, 1 << LayerMask.NameToLayer("Player"));

        if (Player.talkedToDad && spotted)
            Application.LoadLevel("Dining Rooms");
    }
}
