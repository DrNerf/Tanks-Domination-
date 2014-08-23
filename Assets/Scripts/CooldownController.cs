using UnityEngine;
using System.Collections;

public class CooldownController : MonoBehaviour 
{
    public ShootingController ParentTank;
    public bool IsBigBang = false;
    public GameObject BigBang;

    void OnDestroy()
    {
        ParentTank.Cooldown = false;

        if (IsBigBang)
        {
            Instantiate(BigBang, transform.position, Quaternion.identity);
        }
    }
}
