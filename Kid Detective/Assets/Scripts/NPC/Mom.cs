using UnityEngine;
using System.Collections;

public class Mom : MonoBehaviour {

    bool hasChoco = false;

    public Texture2D NPC;
    public GameObject[] Player;
    private Texture2D PlayerPortait;

    private bool NPCisTalking = true;
    public bool PlayerisTalking = false;

    public GUIStyle NPCFont;
    public GUIStyle PlayerFont;
    public GUIStyle NPCSpeechBubble;
    public GUIStyle PlayerSpeechBubble;

	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectsWithTag("Player");
        PlayerPortait = Player[0].GetComponent<Player>().Portrait;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (this.GetComponent<PeopleInteractionLogicIso>().spotted)
        {
            Debug.Log("HELLO");
            GUI.BeginGroup(new Rect(Screen.width / 2 - (Screen.width / 2), Screen.height / 2 - (Screen.height / 2), Screen.width, Screen.height));
            GUI.Label(new Rect(Screen.width - NPC.width, 0, NPC.width, NPC.height), NPC); //Top Right - NPC Portrait
            if (NPCisTalking)
            {
                GUI.BeginGroup(new Rect(0, 0, 400, 200));//Top Left - NPC Dialog

                GUI.Box(new Rect(50, 0, 300, 150), "", NPCSpeechBubble);
                GUI.Label(new Rect(50, 10, 300, 200), "Hi", NPCFont);
                GUI.EndGroup();
            }

            GUI.Label(new Rect(0, Screen.height - PlayerPortait.height, PlayerPortait.width, PlayerPortait.height), PlayerPortait); //Botto Left - Player Portrait
            GUI.BeginGroup(new Rect(Screen.width - 400, Screen.height - 245, 400, 300)); //Bottom Right - Player Dialog

            if (PlayerisTalking)
            {
                GUI.BeginGroup(new Rect(35, 0, 300, 200));//Top Left - PLayer Dialog
                GUI.Box(new Rect(0, 0, 300, 150), "", PlayerSpeechBubble);
                GUI.Label(new Rect(0, 10, 300, 200), "Hi2", PlayerFont);
                GUI.EndGroup();
            }

            GUI.EndGroup();
            GUI.EndGroup();
        }
    }
}
