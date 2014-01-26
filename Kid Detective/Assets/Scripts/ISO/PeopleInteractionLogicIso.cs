using UnityEngine;
using System.Collections.Generic;

public class PeopleInteractionLogicIso : MonoBehaviour {

    public bool spotted = false;
    //public bool active = false;
    public static bool useButtons = false;

    /*
    public Texture2D NPC;
    public GameObject[] Player;
    private Texture2D PlayerPortait;

    public List<int> DialogInstances = new List<int>();
   
    private List<string> NPCdialog = new List<string>();
    private List<string> playerDialog = new List<string>();
    private int NPCDialogNumber = 0;
    private int playerDialogNumber = 0;*/

    

    public Texture2D Punch;
    public Texture2D Kiss;
    public Texture2D Bribe;
    public Texture2D Ask;

    void Start()
    {
        /*Player = GameObject.FindGameObjectsWithTag("Player");
        //PlayerPortait = Player[0].GetComponent<Player>().Portrait;

        //NPC DIALOG
        iniParser NPCparser = new iniParser(IniFiles.NPC_DIALOG);
        for (int i = 0; i < NPCparser.GetNumberKeyUnderSubGroup(this.name); i++)
        {
           NPCdialog.Add(NPCparser.Get(this.name, this.name + i.ToString()));
        }

        //PLAYER DIALOG
        iniParser playerParser = new iniParser(IniFiles.PLAYER_DIALOG);
        for (int i = 0; i < playerParser.GetNumberKeyUnderSubGroup(this.name); i++)
        {
            playerDialog.Add(playerParser.Get(this.name, this.name + i.ToString()));
        }*/

    }


    // Use this for initialization
    void Update()
    {
        Raycasting();
    }

    void Raycasting()
    {
        spotted = Physics2D.OverlapCircle(transform.localPosition, 1.0f, 1 << LayerMask.NameToLayer("Player"));
    }

    void OnGUI()
    {
        if (spotted && active)
        {
            PlayerControllerPokemon.inDialog = true;
            GUI.BeginGroup(new Rect(Screen.width - 400, Screen.height - 245, 400, 300)); //Bottom Right - Player Dialog

            if (useButtons)
            {

                if (GUI.Button(new Rect(35, 170, 60, 60), Punch))
                {
                   // int index = 1;

                   // LoadNewInstance(index);
                    //active = false;
                    //PlayerControllerPokemon.inDialog = false;
                }

                if (GUI.Button(new Rect(105, 170, 60, 60), Ask))
                {
                    //active = false;
                  //  int index = 2;

                   // LoadNewInstance(index);
                    // PlayerControllerPokemon.inDialog = false;
                }
                if (GUI.Button(new Rect(175, 170, 60, 60), Kiss))
                {
                    //active = false;
                   // int index = 3;

                    //LoadNewInstance(index);
                    // PlayerControllerPokemon.inDialog = false;
                }
                if (GUI.Button(new Rect(245, 170, 60, 60), Bribe))
                {
                    //active = false;
                   // int index = 4;

                    //LoadNewInstance(index);
                    // PlayerControllerPokemon.inDialog = false;
                }
            }
            GUI.EndGroup();        

        }
    }
    /*
    void LoadNewInstance(int index)
    {
        int numberBefore = 0;
        int temp = DialogInstances[index];

        for (int i = 0; i < index; i++)
        {
            numberBefore += DialogInstances[i];
            Debug.Log("Number before: " + numberBefore.ToString());
        }

        for (int i = 0; i < temp; i++)
        {
            NPCDialogNumber = numberBefore + i;
            Debug.Log(NPCDialogNumber.ToString());
        }
    }*/
}

/*
void OnGUI () {
    GUI.Box (new Rect (0,0,100,50), "Top-left");
    GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
    GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
    GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom right");
}
*/