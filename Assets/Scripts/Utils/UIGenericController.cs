using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class UIGenericController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI = null;

    //Cached Components
    TextMeshProUGUI TextUI => textUI;

    private void Start()
    {
        if (textUI == null) GetComponent<TextMeshProUGUI>();
        ListenForUIChange();
    }

    protected abstract void ListenForUIChange();
    public void UpdateUI(string text)
    {
        textUI.text = text;
    }
}
