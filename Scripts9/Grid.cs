using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grid : MonoBehaviour {

    public Text countText;

    public Image image;

    public void Init(int count, Color color)
    {
        countText.text = count.ToString();
        image.color = color;
    }
}
