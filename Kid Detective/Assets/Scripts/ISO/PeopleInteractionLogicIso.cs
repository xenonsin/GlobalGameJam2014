using UnityEngine;
using System.Collections.Generic;

public class PeopleInteractionLogicIso : MonoBehaviour {

    public bool spotted = false;
    public bool useButtons = false;
    public bool active = true;

    /*
    public Texture2D NPC;
    public GameObject[] Player;
    private Texture2D PlayerPortait;

    public List<int> DialogInstances = new List<int>();
   
    private List<string> NPCdialog = new List<string>();
    private List<string> playerDialog = new List<string>();
    private int NPCDialogNumber = 0;
    private int playerDialogNumber = 0;*/

    



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
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log ("Button Works");
            //Raycast fro screen
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.transform.tag == "People")
                {
                    Debug.Log("Hit!");
                    PlayerControllerPokemon.inDialog = true;
                    spotted = true;
                    var enemyscript = hit.transform.GetComponent<ClickMofo>();
                    enemyscript.active = true;
                }

                if (hit.transform.tag == "Door")
                {
                    var enemyscript = hit.transform.GetComponent<MofoDoor>();
                    enemyscript.active = true;
                }
            }
        }

        Raycasting();
    }

    void Raycasting()
    {
        spotted = Physics2D.OverlapCircle(transform.localPosition, 1.0f, 1 << LayerMask.NameToLayer("Player"));
 
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