using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private GameObject[] runners;

    List<RankingSystem> sortArray = new List<RankingSystem>();

   

    private void Awake()
    {
        runners = GameObject.FindGameObjectsWithTag("Runner");
    }

    void Start()
    {
        
        for (int i = 0; i < runners.Length; i++)
        {
            sortArray.Add(runners[i].GetComponent<RankingSystem>());
            print(runners[i].gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculatingRank();

    }

    private void CalculatingRank()
    {
        sortArray = sortArray.OrderBy(x => x.counter).ToList();
        sortArray[0].rank = 3;
        sortArray[1].rank = 2;
        sortArray[2].rank = 1;
    }

    
}
