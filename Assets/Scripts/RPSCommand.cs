using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class RPSCommand : ICommand
{
    private GameObject _button;
    private string _turnName;
    private string _previousturnName;
    public static int priorityCounter;
    public static List<string> buttonNames = new List<string>();

    public RPSCommand(string turnName, GameObject button)
    {
        this._button = button;
        this._turnName = turnName;
    }

    public void Execute()
    {
        _previousturnName = _button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
        _button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _turnName;
        priorityCounter++;
        _button.transform.GetChild(1).GetComponentInChildren<TMPro.TextMeshProUGUI>().text = priorityCounter.ToString();
        buttonNames.Add(_turnName);
        Debug.Log("_turnName : " + _turnName);
    }

    public void Undo()
    {
        _button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _previousturnName;
        buttonNames.Remove(_previousturnName);
        Debug.Log("_previousturnName : " + _previousturnName);
    }
}
