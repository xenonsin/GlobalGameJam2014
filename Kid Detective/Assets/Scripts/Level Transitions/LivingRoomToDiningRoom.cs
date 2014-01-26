using UnityEngine;
using System.Collections;

public class LivingRoomToDiningRoom : MonoBehaviour {


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Player.talkedToGrandma && this.GetComponent<MofoDoor>().active)
            Application.LoadLevel("Dining Room");
    }
}
