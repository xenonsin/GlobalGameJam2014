﻿using UnityEngine;
using System.Collections;

public class Dad : MonoBehaviour
{

    private bool useButtons = false;
    private int count = 0;
    public int scene = 0;

    public Texture2D Daddy;
    public Texture2D Dog;
    public Texture2D Uncle;
    public Texture2D Grandma;
    public Texture2D Grandpa;
    public Texture2D Aunt;

    public GameObject[] Players;
    private Texture2D PlayerPortait;
    private string npcText;
    private string playerText;
    private Texture2D npcPortrait;

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
        npcPortrait = Daddy;

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Mouse());

        MotherTree();

    }

    void OnGUI()
    {
        if (this.GetComponent<PeopleInteractionLogicIso>().spotted && this.GetComponent<PeopleInteractionLogicIso>().active)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), ""); //Background
            GUI.BeginGroup(new Rect(Screen.width / 2 - (Screen.width / 2), Screen.height / 2 - (Screen.height / 2), Screen.width, Screen.height));
            GUI.Label(new Rect(Screen.width - npcPortrait.width, 0, npcPortrait.width, npcPortrait.height), npcPortrait); //Top Right - NPC Portrait
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
        if (scene == 0 && count == 0)
        {
            PlayerisTalking = false;
            npcText = "What were you thinking?";
            useButtons = false;
        }

        //
        if (Player.punchedDog && scene == 0 && count == 1)
        {
            
            npcText = "!!!!!!!!!!!!";
            npcPortrait = Dog;
        }
        else if (scene == 0 && count == 1)
        {
            npcText = "That bathroom was occupied!";
            npcPortrait = Daddy;
        }
        //

        //
        if (Player.punchedUncle && scene == 0 && count == 2)
        {
            npcText = "She hit me out of nowhere!";
            npcPortrait = Uncle;
        }
        else if (scene == 0 && count == 2)
        {
            npcText = "Luckily, I was about finished...";
            npcPortrait = Daddy;
        }
        //

        //
        if (Player.punchedGrandma && scene == 0 && count == 3)
        {
            npcText = "She's just trouble!";
            npcPortrait = Grandma;
        }
        else if (scene == 0 && count == 3)
        {
            npcText = "You could of caught me mid bombardment...";
            npcPortrait = Daddy;
        }
        //

        //
        if (Player.punchedGrandpa && scene == 0 && count == 4)
        {
            npcText = "She knocked me out!";
            npcPortrait = Grandpa;
        }
        else if (scene == 0 && count == 4)
        {
            npcText = "That would have been terrible...";
            npcPortrait = Daddy;
        }
        //

        //
        if (Player.punchedAunt && scene == 0 && count == 5)
        {
            npcText = "I was being harrassed!";
            npcPortrait = Aunt;
        }
        else if (scene == 0 && count == 5)
        {
            npcPortrait = Daddy;
            npcText = "The horrors you would have seen...";
        }
        //

        //
        if (Player.howManyPunched > 4 && scene == 0 && count == 6)
        {
            npcPortrait = Daddy;
            npcText = "Alright, everyone please calm down. Everything is under control. You’re in big trouble, missy. Come with me.";
        }
        else if (scene == 0 && count == 6)
        {
            npcPortrait = Daddy;
            npcText = "Anyway, what do you need?";
            useButtons = true;
        }
        //

        //
        if (Player.howManyPunched > 4 && scene == 0 && count == 7)
        {
            this.GetComponent<PeopleInteractionLogicIso>().active = false;
            PlayerControllerPokemon.inDialog = false;
            transform.Translate(new Vector2(-3 * Time.deltaTime, 0));

            if (transform.position.x < -7)
            {
                Application.LoadLevel("Main Menu");
            }
        }

        else if (scene == 0 && count == 7)
        {
        }
        //


        //Scene 1 = Punch

        if (scene == 1 && count == 0)
        {
            PlayerisTalking = false;
            npcText = "What do you think you’re doing? Come here.";
            useButtons = false;
        }

        if (scene == 1 && count == 1)
        {
            this.GetComponent<PeopleInteractionLogicIso>().active = false;
            this.GetComponent<PeopleInteractionLogicIso>().enabled = false;
            PlayerControllerPokemon.inDialog = false;
            transform.Translate(new Vector2(-3 * Time.deltaTime, 0));

            if (transform.position.x < -7)
            {
                Application.LoadLevel("Main Menu");
            }
        }

        /*
        */
        

        //Scene 2 = Ask

        if (scene == 2 && count == 0)
        {
            PlayerisTalking = true;
            playerText = "I heard you're the boss, Tell me where is Charlie.";
            useButtons = false;
        }
        if (scene == 2 && count == 1)
        {
            PlayerisTalking = false;
            npcText = "Charlies gone missing? I heard about that. But there’s nothing I can do, you’re going to have to talk to the real boss, she’s in the kitchen.";
        }
        if (scene == 2 && count == 2) //Fade to black
        {
            this.GetComponent<PeopleInteractionLogicIso>().active = false;
            PlayerControllerPokemon.inDialog = false;
            Player.talkedToDad = true;

            Application.LoadLevel("Dining Room");
        }

        


        //Scene 3 = Kiss
        if (Player.choco && scene == 3 && count == 0)
        {
            PlayerisTalking = false;
            npcText = "Oh thats disgusting you’re getting chocolate all over me!";
            useButtons = true;

        }
        else if (scene == 3 && count == 0)
        {
            PlayerisTalking = false;
            npcText = "What’s the matter with you?";
            useButtons = true;
        }
        

        //Scene 4 = Bribe
        if (scene == 4 && count == 0)
        {
            PlayerisTalking = true;
            playerText = "Here, for your troubles.";
            useButtons = true;
        }

        if (scene == 4 && count == 1)
        {
            PlayerisTalking = false;
            npcText = "Why don’t you use that for yourself!";
            useButtons = true;
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