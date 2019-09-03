using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTextController : MonoBehaviour
{
    public Text scrollText;
    public float scrollSpeed;
    public float posX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posX -= scrollSpeed * Time.deltaTime;
        scrollText.rectTransform.position = new Vector3(posX, 1195f, 0f);
        if (scrollText.rectTransform.position.x <= -140f)
        {
            posX = 883f;
        }
    }
}
