using UnityEngine;
using System.Collections;

public class OpeningSceneScript : MonoBehaviour {

    private bool faded = false;
    private bool startGame = false;
    private float tParam = 0f;
    private float speed = 0.15f;

    public Texture2D blackTexture;
    public Texture2D start;
    float alphaFadeValue = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (tParam < 1)
            {
                tParam += Time.deltaTime * speed; //This will increment tParam based on Time.deltaTime multiplied by a speed multiplier
                transform.position = new Vector3(0, Mathf.Lerp(9, -4, tParam), -10);
            }
        }

        if (transform.position == new Vector3(0,-4,-10))
        {
            faded = true;

        }

        if (alphaFadeValue > 1.5f)
        {
            Application.LoadLevel("Porch");
        }

    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2, 300, 200));

        if (!startGame)
        {

            if (GUI.Button(new Rect(60, 10, 100, 50), start))
            {
                startGame = true;
                //Application.LoadLevel("Load");
            }
            /*
            if (GUI.Button(new Rect(60, 80, 100, 50), "Quit Game"))
            {
                Debug.Log("QUIT!");

                Application.Quit();
            }*/
        }

        GUI.EndGroup();

        if (faded)
        {
            alphaFadeValue += Mathf.Clamp01(Time.deltaTime / 5);

            GUI.color = new Color(0, 0, 0, alphaFadeValue);
            GUI.Label(new Rect(0, -10, blackTexture.width, blackTexture.height), blackTexture);

            Debug.Log(alphaFadeValue);

            
        }
    }

}
