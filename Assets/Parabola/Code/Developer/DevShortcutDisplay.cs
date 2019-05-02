using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class DevShortcutDisplay : MonoBehaviour
{

    [SerializeField] bool HiddenByDefault;
    [SerializeField] KeyCode Reveal;

    [Header("Design")]
    [SerializeField]
    Font HighlightFont;
    [SerializeField] Font DefaultFont;

    [Header("Shortcuts")]
    public List<DevShortcutItem> Shortcuts = new List<DevShortcutItem>();

    Rect windowRect = new Rect(80, 55, 250, 240);
    List<string> shortcutString;

    void Start()
    {
        shortcutString = new List<string>();
        foreach (DevShortcutItem item in Shortcuts)
        {
            shortcutString.Add(Reveal + " + '" + item.Key + "' to " + item.Description);
        }
    }

    void OnGUI()
    {
        GUI.backgroundColor = Color.black;

        if (!HiddenByDefault || Input.GetKey(Reveal))
        {
            GUI.skin.font = DefaultFont;
            windowRect = GUILayout.Window(0, windowRect, CreateWindow, "Shortcuts");
        }
    }

    void CreateWindow(int windowID)
    {
        for (int i = 0; i < Shortcuts.Count; i++)
        {
            if (Input.GetKey(Shortcuts[i].Key))
            {
                GUI.skin.font = HighlightFont;
                GUILayout.Label(shortcutString[i]);

                Shortcuts[i].Event.Invoke();
            }
            else
            {
                GUI.skin.font = DefaultFont;
                GUILayout.Label(shortcutString[i]);
            }
        }

    }

}

[Serializable]
public struct DevShortcutItem
{
    public KeyCode Key;
    public string Description;
    public UnityEvent Event;
}