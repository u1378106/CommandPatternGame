using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void Rock()
    {
        audioManager.PlayMouseClickSound();
        ICommand click = new RPSCommand(this.GetComponentInChildren<TMPro.TextMeshProUGUI>().text, this.gameObject);

        click.Execute();
        RPSCommandManager.instance.AddCommand(click);
    }

    public void Paper()
    {
        audioManager.PlayMouseClickSound();
        ICommand click = new RPSCommand(this.GetComponentInChildren<TMPro.TextMeshProUGUI>().text, this.gameObject);

        click.Execute();
        RPSCommandManager.instance.AddCommand(click);
    }

    public void Scissor()
    {
        audioManager.PlayMouseClickSound();
        ICommand click = new RPSCommand(this.GetComponentInChildren<TMPro.TextMeshProUGUI>().text, this.gameObject);

        click.Execute();
        RPSCommandManager.instance.AddCommand(click);
    }
}
