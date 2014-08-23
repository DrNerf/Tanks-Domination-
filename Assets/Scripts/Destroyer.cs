using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour 
{
    public float Time;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, Time);
	}
}
