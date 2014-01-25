using UnityEngine;
using System.Collections;

public class PeopleInteractionLogicIso : MonoBehaviour {

    private bool spotted = false;
    private bool active = true;

    public Texture2D NPC;
    public Texture2D Player;


    // Use this for initialization
    void Update()
    {
        Raycasting();
    }

    void Raycasting()
    {
        spotted = Physics2D.OverlapCircle(transform.localPosition, 2.0f, 1 << LayerMask.NameToLayer("Player"));
    }
    /*
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
    }*/

    void OnGUI()
    {
        if (spotted && active)
        {
            PlayerControllerPokemon.inDialog = true;
            GUI.BeginGroup(new Rect(Screen.width / 2 - (Screen.width / 2), Screen.height / 2 - (Screen.height / 2), Screen.width, Screen.height));
            GUI.Label(new Rect(Screen.width - NPC.width, 0, NPC.width, NPC.height), NPC); //Top Right - NPC Portrait
            GUI.Box(new Rect(0, 0, 300, 200), "YOU ASSHOLE"); //Top Left - NPC Dialog

            GUI.Label(new Rect(0, Screen.height - Player.height, Player.width, Player.height), Player); //Botto Left - Player Portrait
            GUI.BeginGroup(new Rect(Screen.width - 300, Screen.height - 200, 300, 200)); //Bottom Right - Player Dialog
            GUI.Box(new Rect(0, 0, 300, 200), "NO YOU!");
            if(GUI.Button(new Rect(50,50,100,100), "Punch"))
            {
                active = false;
                PlayerControllerPokemon.inDialog = false;
            }
            if (GUI.Button(new Rect(150, 50, 100, 100), "Interrogate"))
            {
                active = false;
                PlayerControllerPokemon.inDialog = false;
            }
            GUI.EndGroup();
            GUI.EndGroup();
            
        }
    }
}

/*
void OnGUI () {
    GUI.Box (new Rect (0,0,100,50), "Top-left");
    GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
    GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
    GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom right");
}
*/