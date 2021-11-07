using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text[] namesTxt;
    public Image thirdPlaceImg;
    public string a, b, c;
   

    
    void Update()
    {
        namesTxt[0].text = a;
        namesTxt[1].text = b;
        namesTxt[2].text = c;
    }
}
