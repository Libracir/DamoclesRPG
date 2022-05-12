using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }  
    }

    public void Show(string text, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText txt = GetFloatingText();

        txt.text.text = text;
        txt.text.fontSize = fontSize;
        txt.text.color = color;
        txt.go.transform.position = Camera.main.WorldToScreenPoint(position);
        txt.motion = motion;
        txt.duration = duration;

        txt.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.text = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
