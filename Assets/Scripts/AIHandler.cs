using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject cpuWeapon;

    public string trait1 = "Honest, Confident, Fearless";
    public string trait2 = "Passive, Peaceful, Swift";
    public string trait3 = "Aggresive, Creative, Cunning";

    public string selectedTrait;

    List<string> aiTraits = new List<string>();

    public string objectName;

    private void Start()
    {
        aiTraits.Add(trait1);
        aiTraits.Add(trait2);
        aiTraits.Add(trait3);

        selectedTrait = aiTraits[Random.Range(0, 2)];
    }

    public void InitializeEnemyAI()
    {
        if(selectedTrait.Contains("Honest, Confident, Fearless"))
        {
            if(Random.Range(0, 100) > 70)
            {
                objectName = "Rock";
            }
            else
            {
                objectName = "Scissor";
            }
        }

        else if (selectedTrait.Contains("Passive, Peaceful, Swift"))
        {
            if (Random.Range(0, 100) > 70)
            {
                objectName = "Paper";
            }
            else
            {
                objectName = "Rock";
            }
        }

        else if (selectedTrait.Contains("Aggresive, Creative, Cunning"))
        {
            if (Random.Range(0, 100) > 70)
            {
                objectName = "Scissor";
            }
            else
            {
                objectName = "Paper";
            }
        }

        cpuWeapon.GetComponent<Image>().sprite = Resources.Load<Sprite>(objectName) as Sprite;
    }
}
