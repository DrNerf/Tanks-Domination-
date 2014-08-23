using UnityEngine;
using System.Collections;

public class BigBangController : MonoBehaviour 
{
    public float ShrapnelsCount = 50;
    public float ShrapnelSpeed = 5;
    public GameObject Shrapnel;
    public GameObject BigBangExplosion;
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(StartExploding());
        Instantiate(BigBangExplosion, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.up * 30);
	}

    IEnumerator StartExploding()
    {
        for (int i = 0; i < ShrapnelsCount; i++)
        {
            GameObject TempShrapnel = Instantiate(Shrapnel, transform.position, Quaternion.identity) as GameObject;
            TempShrapnel.rigidbody.AddForce(transform.forward * ShrapnelSpeed);
            yield return new WaitForSeconds(0.08f);
        }
    }
}
