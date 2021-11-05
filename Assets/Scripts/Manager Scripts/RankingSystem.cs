using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    public int currentCheckPoint=1, lapCount;

    public float distance;
    private Vector3 checkPoint;

    public float counter;
    public int rank;
    void Start()
    {
        currentCheckPoint = 1;
        checkPoint = GameObject.Find("CheckPoint" + currentCheckPoint).transform.position;
    }

    
    void Update()
    {
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position,checkPoint);
        counter = lapCount * 1000 + currentCheckPoint * 100 + distance;
    }

    private void OnTriggerEnter(Collider target )
    {
        if (target.tag == "CheckPoint")
        {
            currentCheckPoint = target.GetComponent<CurrentCheckPoint>().currentCheckNumber;
            checkPoint = GameObject.Find("CheckPoint" + currentCheckPoint).transform.position;
        }

        if (target.tag == "Finish")
        {
            lapCount += 1;
            currentCheckPoint = 1;
        }
    }
}
