using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
    public GUISkin Skin;
    public AudioSource Music;

    void Start()
    {
        Music = gameObject.GetComponent<AudioSource>();
    }

    void OnGUI()
    {
        GUI.skin = Skin;
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 200, 95), "");
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 200, 95));
        GUILayout.BeginVertical();
        GUILayout.Space(15);
        if (GUILayout.Button("Dominate")) 
        {
            Application.LoadLevel(1);
            PlayerPrefs.SetInt("BlueScore", 0);
            PlayerPrefs.SetInt("RedScore", 0);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();

        Music.volume = GUI.HorizontalSlider(new Rect(Screen.width - 110, Screen.height - 30, 100, 25), Music.volume, 0, 1);
    }
	
}
