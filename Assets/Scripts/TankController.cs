using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour 
{
    public bool IsBlueTank;
    public float FwdSpeed = 0.03f;
    public float BwdSpeed = 0.02f;
    public float RotateSpeed = 0.05f;
    public Renderer RightChain;
    public Renderer LeftChain;
    public float ChainSpeed = 0.01f;

    public Transform Bwd;
    public Transform Fwd;

    public bool CanFwd = true;
    public bool CanBwd = true;

    public string FwdKey;
    public string BwdKey;
    public string RightKey;
    public string LeftKey;

	// Update is called once per frame
	void Update () 
    {

        if (Input.GetKey(FwdKey))
        {
            if (CanFwd)
            {
                MoveChains();
                transform.position = Vector3.Lerp(transform.position, Fwd.position, Time.deltaTime * FwdSpeed);
            }
        }
        if (Input.GetKey(LeftKey))
        {
            MoveChains();
            transform.Rotate(Vector3.up * RotateSpeed * -1);
        }
        if (Input.GetKey(BwdKey))
        {
            if (CanBwd)
            {
                MoveChains();
                transform.position = Vector3.Lerp(transform.position, Bwd.position, Time.deltaTime * BwdSpeed);
            }
        }
        if (Input.GetKey(RightKey))
        {
            MoveChains();
            transform.Rotate(Vector3.up * RotateSpeed);
        }

	}

    void MoveChains()
    {
        Vector2 TempRight = RightChain.material.GetTextureOffset("_MainTex");
        TempRight.y -= ChainSpeed;
        RightChain.material.SetTextureOffset("_MainTex", TempRight);
        Vector2 TempLeft = LeftChain.material.GetTextureOffset("_MainTex");
        TempLeft.y -= ChainSpeed;
        LeftChain.material.SetTextureOffset("_MainTex", TempLeft);
    }

    void OnDestroy()
    {
        try
        {
            if (IsBlueTank)
            {
                Camera.main.GetComponent<GameMaster>().EndRoundBlue();
            }
            else
            {
                Camera.main.GetComponent<GameMaster>().EndRoundRed();
            }
        }
        catch
        {
            Debug.LogWarning("NULLREFERENCE EXCEPTION // Nothing too special!");
        }
    }
}
