using UnityEngine;
using System.Collections;

public class LivingRoomToPorch : MonoBehaviour {

    public bool spotted = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        spotted = Physics2D.OverlapCircle(transform.localPosition, 1.0f, 1 << LayerMask.NameToLayer("Player"));

        if (spotted)
            Application.LoadLevel("Porch");
    }
}
