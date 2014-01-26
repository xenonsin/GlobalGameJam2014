using UnityEngine;
using System.Collections;

public class BathroomScript : MonoBehaviour
{

    private bool useButtons = false;
    private int count = 0;
    private int scene = 0;

    public Texture2D NPC;
    public GameObject[] Players;
    private Texture2D PlayerPortait;
    private string npcText;
    private string playerText;

    private bool NPCisTalking = true;
    public bool PlayerisTalking = false;

    public GUIStyle NPCFont;
    public GUIStyle PlayerFont;
    public GUIStyle NPCSpeechBubble;
    public GUIStyle PlayerSpeechBubble;


    // Use this for initialization
    void Start()
    {

        Players = GameObject.FindGameObjectsWithTag("Player");
        PlayerPortait = Players[0].GetComponent<Player>().Portrait;

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Mouse());

        MotherTree();

        if (!this.GetComponent<PeopleInteractionLogicIso>().spotted)
            transform.Translate(new Vector2(3 * Time.deltaTime, 0));
    }

    void OnGUI()
    {
        if (this.GetComponent<PeopleInteractionLogicIso>().spotted && this.GetComponent<PeopleInteractionLogicIso>().active)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), ""); //Background
            GUI.BeginGroup(new Rect(Screen.width / 2 - (Screen.width / 2), Screen.height / 2 - (Screen.height / 2), Screen.width, Screen.height));
            GUI.Label(new Rect(Screen.width - NPC.width, 0, NPC.width, NPC.height), NPC); //Top Right - NPC Portrait
            if (NPCisTalking)
            {
                GUI.BeginGroup(new Rect(0, 0, 400, 200));//Top Left - NPC Dialog

                GUI.Box(new Rect(50, 0, 300, 150), "", NPCSpeechBubble);
                GUI.Label(new Rect(0, 10, 200, 50), npcText, NPCFont);
                GUI.EndGroup();
            }

            GUI.Label(new Rect(0, Screen.height - PlayerPortait.height, PlayerPortait.width, PlayerPortait.height), PlayerPortait); //Botto Left - Player Portrait
            GUI.BeginGroup(new Rect(Screen.width - 400, Screen.height - 245, 400, 300)); //Bottom Right - Player Dialog

            if (PlayerisTalking)
            {
                GUI.BeginGroup(new Rect(35, 0, 300, 200));//Top Left - PLayer Dialog
                GUI.Box(new Rect(0, 0, 300, 150), "", PlayerSpeechBubble);
                GUI.Label(new Rect(0, 10, 200, 50), playerText, PlayerFont);
                GUI.EndGroup();

            }

            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

    void MotherTree()
    {

        //Scene 0 = Default
         if (scene == 0 && count == 0)
        {
            npcText = "HOLD IT! WHAT ARE YOU DOING HERE! CAN'T YOU SEE I'M BUSY?!";
            useButtons = true;
        }
         if (scene == 0 && count == 1)
         {
             PlayerisTalking = true;
             playerText = "umm..";
         }
         if (scene == 0 && count == 2)
         {
             PlayerisTalking = false;
             npcText = "Come with me.";
         }
         if (scene == 0 && count == 3)
         {
             this.GetComponent<PeopleInteractionLogicIso>().active = false;
             this.GetComponent<PeopleInteractionLogicIso>().enabled = false;
             PlayerControllerPokemon.inDialog = false;
             Application.LoadLevel("Judgement");
         }

        //Scene 1 = Punch
        if (scene == 1 && count == 0)
        {
            PlayerisTalking = false;
            npcText = "You insolent brat!";
        }

        if (scene == 1 && count == 1)
        {
            this.GetComponent<PeopleInteractionLogicIso>().active = false;
            this.GetComponent<PeopleInteractionLogicIso>().enabled = false;
            PlayerControllerPokemon.inDialog = false;
            Player.talkedToAunt = true;
        }

    }

    IEnumerator Mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            yield return new WaitForSeconds(3);
        }


    }
}