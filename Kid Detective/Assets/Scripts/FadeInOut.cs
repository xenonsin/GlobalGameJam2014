
// simple fading script
// A texture is stretched over the entire screen. The color of the pixel is set each frame until it reaches its target color.


using UnityEngine;
using System.Collections;


public class FadeInOut : MonoBehaviour
{
    public bool fade = false;
    private float tParam = 0f;
    public Texture2D blackTexture;
    private float fadeOutFadeValue = 0;
    private float fadeInFadeValue = 1;

    private float fadeSpeed = 1f;

    // initialize the texture, background-style and initial color:
    void Awake()
    {
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(0, 0, blackTexture.width, blackTexture.height), blackTexture);

        if (fade)
        {
            if (fadeOutFadeValue < 1.5f)
            {
                fadeOutFadeValue += Mathf.Clamp01(Time.deltaTime / 5);

                GUI.color = new Color(0, 0, 0, fadeOutFadeValue);
                GUI.Label(new Rect(0, -10, blackTexture.width, blackTexture.height), blackTexture);
            }
        }
        else
        {
            if (fadeInFadeValue > 0)
            {
                fadeInFadeValue -= Mathf.Clamp01(Time.deltaTime / 5);

                GUI.color = new Color(0, 0, 0, fadeInFadeValue);
                GUI.Label(new Rect(0, -10, blackTexture.width, blackTexture.height), blackTexture);
            }
        }
            

            

    }

    

}