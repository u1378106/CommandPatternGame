using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RPSCommandManager : MonoBehaviour
{
    private List<ICommand> _commandBuffer = new List<ICommand>();

    private static RPSCommandManager _instance;

    private UIHandler uIHandler;

    AudioManager audioManager;

    public static bool isUndo;

    public static RPSCommandManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("CommandManager is null");
            }
            return _instance;
        }
    }


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        uIHandler = GameObject.FindObjectOfType<UIHandler>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }

    public void RemoveCommand(ICommand command)
    {
        _commandBuffer.Remove(command);
    }

    public void Play()
    {
        audioManager.PlayMouseClickSound();
        StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine()
    {
        uIHandler.StartBattle(RPSCommand.buttonNames[0]);
        //_commandBuffer[_commandBuffer.Count - 1].Execute();
        yield return  null;
    }

    public void Rewind()
    {
        audioManager.PlayMouseClickSound();
        StartCoroutine(RewindRoutine());
    }

    IEnumerator RewindRoutine()
    {
        Enumerable.Reverse(_commandBuffer);
        if (_commandBuffer.Count - 1 > 0)
        {
            isUndo = true;
            _commandBuffer[0].Undo();
            RemoveCommand(_commandBuffer[0]);
                 
            //uIHandler.StartBattle(RPSCommand.buttonNames[0]);
        }
        yield return null;
    }

    public void Reset()
    {
        _commandBuffer.Clear();
    }

}
