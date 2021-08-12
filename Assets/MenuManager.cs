using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public string menuTitle;
    public int titleTextSize;
    public string[] menuOptions;
    public int menuTextSize;
    public int lineHeight = 50;

    // Start is called before the first frame update
    void Start()
    {
        var panel = GameObject.Find("MainMenuPanel");
        var text = GameObject.Find("SampleText");
        var eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
        var numLines = menuOptions.Length + 2;
        var totalHeight = numLines * lineHeight;

        var rect = text.GetComponent<RectTransform>();
        rect.localPosition += Vector3.up * (numLines - 1) * 25;

        for (var i = 1; i <= menuOptions.Length; i++) {
            var newText = Instantiate(text, rect.position, rect.rotation, rect.parent);
            var tmpro = newText.GetComponent<TMP_Text>();
            tmpro.text = menuOptions[i - 1];
            newText.GetComponent<RectTransform>().localPosition += Vector3.down * (i + 1) * 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
