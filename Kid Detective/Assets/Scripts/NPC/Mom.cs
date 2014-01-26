using UnityEngine;
using System.Collections;

public class Mom : MonoBehaviour {

   // bool continues = false;

    bool hasChoco = false;
    private bool useButtons = false;
    private int count = 0;
    public int scene = 0;

    public Texture2D NPC;
    public GameObject[] Player;
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

    private bool canPunch = true;
    private bool canKiss = true;
    private bool canBribe = true;
    private bool canAsk = true;


	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectsWithTag("Player");
        PlayerPortait = Player[0].GetComponent<Player>().Portrait;
	
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(Mouse());

        MotherTree();
	
	}

    void OnGUI()
    {
        if (this.GetComponent<PeopleInteractionLogicIso>().spotted && this.GetComponent<PeopleInteractionLogicIso>().active)
        {
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
                }

                if (canAsk && GUI.Button(new Rect(105, 170, 60, 60), Ask))
                {
                    scene = 2;
                    count = 0;
                    canAsk = false;
                }
                if (canKiss && GUI.Button(new Rect(175, 170, 60, 60), Kiss))
                {
                    scene = 3;
                    count = 0;
                    canKiss = false;
                }
                if (canBribe && GUI.Button(new Rect(245, 170, 60, 60), Bribe))
                {
                    scene = 4;
                    count = 0;
                    canBribe = false;
                }
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
            npcText = "Hello, what do you need dear?";
            useButtons = true;
        }

        //Scene 1 = Punch
        if (scene == 1 && count == 0)
        {
            npcText = "Ow! You scamp!  George!";
        }
        if (scene == 1 && count == 1)
        {
            this.GetComponent<PeopleInteractionLogicIso>().active = false;
            PlayerControllerPokemon.inDialog = false;
        }



        //Scene 2 = Ask
        if (scene == 2 && count == 0)
       {
            PlayerisTalking = true;
            playerText = "Have you seen Charlie?  She’s only two years old.  It’s a matter of life and death.";
   
       }

        if (scene == 2 && count == 1)
        {
           PlayerisTalking = false;
           npcText = "Dear, I am quite busy cleaning up the boys’ mess here.  Let’s do this some other time, huh?";
        }

        //Scene 3 = Kiss
        if (scene == 3 && count == 0)
        {
            //PlayerisTalking = true;
            npcText = "Oh! That is so unsanitary, dear!  Don’t you have anything to wipe yourself up with?";

        }

        //Scene 4 = Bribe
        if (scene == 4 && count == 0)
        {
            PlayerisTalking = true;
            playerText = "Here, will this help you? ";

        }
        if (scene == 4 && count == 1)
        {
            PlayerisTalking = false;
            npcText = "Why, yes, I do believe so.  What a dear.  Hm, you would actually want to talk to Cathy.  Follow me.";

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
