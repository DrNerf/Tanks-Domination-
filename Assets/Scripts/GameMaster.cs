using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
    public GUISkin Skin;
    public int PerkDropRate = 3;
    public List<GameObject> Perks;

    public int BlueScore = 0;
    public int RedScore = 0;

    private bool WinningColor;

    void Start()
    {
        BlueScore = PlayerPrefs.GetInt("BlueScore");
        RedScore = PlayerPrefs.GetInt("RedScore");
        StartCoroutine(DropPerks());
    }

    void OnGUI()
    {
        GUI.skin = Skin;

        GUI.Box(new Rect(10, 10, 125, 150), "Score");
        GUILayout.BeginArea(new Rect(30, 10, 125, 150));
        GUILayout.BeginVertical();
        GUILayout.Space(50);
        GUI.contentColor = Color.blue;
        GUILayout.Label("Blue : " + BlueScore);
        GUI.contentColor = Color.red;
        GUILayout.Label("Red : " + RedScore);
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    IEnumerator DropPerks()
    {
        do
        {
            int temp = Random.Range(0, 6);
            Vector3 SpawnPos = new Vector3(Random.Range(-5, 5), 2, Random.Range(-5, 5));
            switch (temp)
            {
                case 0:
                    Instantiate(Perks[0], SpawnPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Perks[0], SpawnPos, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Perks[1], SpawnPos, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Perks[1], SpawnPos, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Perks[2], SpawnPos, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Perks[2], SpawnPos, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(Perks[3], SpawnPos, Quaternion.identity);
                    break;
                default:
                    Debug.Log("Something went wrong with the perk spawning");
                    break;
            }
            yield return new WaitForSeconds(PerkDropRate);
        } while (true);
    }

    public void EndRoundBlue()
    {
        WinningColor = true;
        Invoke("EndRound", 4);
    }

    public void EndRoundRed()
    {
        WinningColor = false;
        Invoke("EndRound", 4);
    }

    void EndRound()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        if (gos.Length != 0)
        {
            if (WinningColor)
            {
                int temp = PlayerPrefs.GetInt("RedScore");
                PlayerPrefs.SetInt("RedScore", temp += 1);
            }
            else
            {
                int temp = PlayerPrefs.GetInt("BlueScore");
                PlayerPrefs.SetInt("BlueScore", temp += 1);
            }
        }
        Application.LoadLevel(1);
    }
}
