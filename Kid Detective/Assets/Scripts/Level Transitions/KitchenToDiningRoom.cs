using UnityEngine;
using System.Collections;

public class KitchenToDiningRoom : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<MofoDoor>().active)
            Application.LoadLevel("Dining Rooms");
    }
}
