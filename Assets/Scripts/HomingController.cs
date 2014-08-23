using UnityEngine;
using System.Collections;

public class HomingController : MonoBehaviour 
{
    public Transform Target;

    private NavMeshAgent NavAgent;
    private bool IsChasing = false;
    public GameObject[] Tanks;

    void Start()
    {
        StartCoroutine(ConstantSearch());
        NavAgent = GetComponent<NavMeshAgent>();
        Invoke("StartChase", 3);
    }

	// Update is called once per frame
	void Update () 
    {
        if (IsChasing)
        {
            try
            {
                NavAgent.SetDestination(Target.position);
            }
            catch
            {
                Debug.LogWarning("Something is wrong with the target!/Possible dead!");
            }
        }
    }

    void StartChase()
    {
        rigidbody.velocity = new Vector3(0, 0, 0);
        IsChasing = true;
    }


    IEnumerator ConstantSearch()
    {
        do
        {
            Target = FindClosestPlayer().transform;
            yield return new WaitForSeconds(0.1f);
        }
        while (true);
    }

    GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = GameObject.Find("Map");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
