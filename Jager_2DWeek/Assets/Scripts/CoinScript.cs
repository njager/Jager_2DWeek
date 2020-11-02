using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //variables
    GameObject coinObject;
    public int count;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    //Updates count text with current data, displays win text
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 19)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
       // coinObject.transform();
    }
}
