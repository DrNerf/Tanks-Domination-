using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour 
{
    public float ScrollTextureSpeed = 0.1f;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 temp = renderer.material.GetTextureOffset("_MainTex");
        temp.x += ScrollTextureSpeed;
        temp.y += ScrollTextureSpeed;
        renderer.material.SetTextureOffset("_MainTex", temp);
	
	}
}
