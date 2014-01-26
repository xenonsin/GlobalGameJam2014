using UnityEngine;
using System.Collections;

public class Uncle : MonoBehaviour
{

    private bool useButtons = false;
    private int count = 0;
    public int scene = 0;

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

    public Texture2D Punch;
    public Texture2D Kiss;
    public Texture2D Bribe;
    public Texture2D Ask;

    public AudioClip PunchSound;
    public AudioClip KissSound;
    public AudioClip BribeSound;
    public AudioClip AskSound;

    private bool canPunch = true;
    private bool canAsk = true;
    private bool canKiss = true;
    private bool canBribe = true;

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

    }

    void OnGUI()
    {
        if (this.GetComponent<ClickMofo>().active)
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

            if (useButtons)
            {

                if (canPunch && GUI.Button(new Rect(35, 170, 60, 60), Punch))
                {
                    scene = 1;
                    count = 0;
                    canPunch = false;
                    audio.PlayOneShot(PunchSound);
                }

                if (canAsk && GUI.Button(new Rect(105, 170, 60, 60), Ask))
                {
                    scene = 2;
                    count = 0;
                    canAsk = false;
                    audio.PlayOneShot(AskSound);
                }
                if (Player.obtainedKiss && canKiss && GUI.Button(new Rect(175, 170, 60, 60), Kiss))
                {
                    scene = 3;
                    count = 0;
                    canKiss = false;
                    audio.PlayOneShot(KissSound);
                }
                if (Player.obtainedBribe && canBribe && GUI.Button(new Rect(245, 170, 60, 60), Bribe))
                {
                    scene = 4;
                    count = 0;
                    canBribe = false;
                    audio.PlayOneShot(BribeSound);
                }
            }

            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

    void MotherTree()
    {

        //Scene 0 = Default
        if (Player.talkedToUncle)
        {
            this.GetComponent<ClickMofo>().active = false;
            PlayerControllerPokemon.inDialog = false;
        }
        else if (scene == 0 && count == 0)
        {
            npcText = "Whatchu want?";
            useButtons = true;
        }

        //Scene 1 = Punch
        if (scene == 1 && count == 0)
        {
            npcText = "Oww! What the blazes?";
            useButtons = false;
        }
        if (scene == 1 && count == 1)
        {
            Player.punchedUncle = true;
            this.GetComponent<ClickMofo>().active = false;
            PlayerControllerPokemon.inDialog = false;
            Player.talkedToUncle = true;
        }



        //Scene 2 = Ask
        if (scene == 2 && count == 0)
        {
            PlayerisTalking = true;
            playerText = "Do you know where I can find Charlie?";
            useButtons = false;
        }

        if (scene == 2 && count == 1)
        {
            PlayerisTalking = false;
            npcText = "Oh I didn’t know you were invited. Listen, you want in?  Show some respect to my mother and give her a kiss.";
        }

        if (scene == 2 && count == 2)
        {
            PlayerisTalking = true;
            playerText = "What about Charlie?";

        }

        if (scene == 2 && count == 3)
        {
            PlayerisTalking = false;
            npcText = "Never heard of ‘im. Just pay your respects to Mother.";
            Player.obtainedKiss = true; // Player unlocks Kiss

        }
        if (scene == 2 && count == 4)
        {
            NPCisTalking = false;
            PlayerisTalking = true;
            playerText = "I have gained the ability to kiss!";
        }

        if (scene == 2 && count == 5)
        {
            this.GetComponent<ClickMofo>().active = false;
            PlayerControllerPokemon.inDialog = false;
            Player.talkedToUncle = true;
        }

        //Scene 3 = Kiss
        if (scene == 3 && count == 0)
        {
            //PlayerisTalking = true;
            //npcText = "";

        }

        //Scene 4 = Bribe
        if (scene == 4 && count == 0)
        {
            //PlayerisTalking = true;
            //playerText = "Here, will this help you? ";

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