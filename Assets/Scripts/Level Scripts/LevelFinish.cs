using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    public Text[] rankText;
    void Update()
    {
        rankText[0].text = GameManager.instance.firstPlace;
        rankText[1].text = GameManager.instance.secondPlace;
        rankText[2].text = GameManager.instance.thirdPlace;
    }
}
