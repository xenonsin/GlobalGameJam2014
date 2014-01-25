using UnityEngine;
using System.Collections;

public class PlayerInteraction2D : MonoBehaviour {

    public bool spotted = false;

    public GameObject arrow;

    public Texture2D textureToDisplay;


    // Use this for initialization
    void Update()
    {
        Raycasting();
        Behaviors();
    }

    void Raycasting()
    {
        spotted = Physics2D.OverlapCircle(transform.localPosition, 2.0f, 1 << LayerMask.NameToLayer("Player"));
    }

    void Behaviors()
    {
        if (spotted)
        {
            arrow.SetActive(true);
        }
        else
        {
            arrow.SetActive(false);
        }
    }
}
