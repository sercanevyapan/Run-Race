using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] checkPoints;

    [HideInInspector]
    public int currentCheckPoint=1;

    // Start is called before the first frame update
    void Awake()
    {
        checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        currentCheckPoint = 1;
    }

    // Update is called once per frame
    void Start()
    {
        foreach (GameObject cp in checkPoints)
        {
            cp.AddComponent<CurrentCheckPoint>();
            cp.GetComponent<CurrentCheckPoint>().currentCheckNumber = currentCheckPoint;
            cp.name = "CheckPoint" + currentCheckPoint;
            currentCheckPoint++;
        }
    }
}
