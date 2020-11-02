using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    //private variables
    GameObject coinObject;
    private int count;
    
    //public variables
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    //Updates count text with current data, displays win text
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       // coinObject.transform();
    }
}
