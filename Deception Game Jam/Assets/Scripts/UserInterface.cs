using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Text personTooltip;
    [SerializeField] private Text personCounter;
    [SerializeField] private Text timerTooltip;
    [SerializeField] private Text timerCounter;
    private GameManager instance;

    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    private void Update()
    {
        UpdateTooltips();
        UpdateTimer();
        //UpdatePersonCount();
    }
    public void UpdatePersonCount()
    {
        instance.personCount = 0;
        for(int i = 0; i< instance.myPersons.Count; i++)
        {
            if(instance.myPersons[i].GetComponent<NPCBehaviorScript>().spokenTo == true)
            {
                instance.personCount += 1;
            }
        } 
        personCounter.text = instance.personCount.ToString();
    }
    private void UpdateTimer()
    {
        if (instance.transformed == true)
        {
            instance.killTimer -= Time.deltaTime;
            timerCounter.text = ((int)instance.killTimer).ToString();
        }
        else
        {
            instance.talkTimer -= Time.deltaTime;
            timerCounter.text = ((int)instance.talkTimer).ToString();
        }
    }
    public void UpdateTooltips()
    {
        if(instance.transformed == true)
        {
            personTooltip.text = "People left to kill:";
            timerTooltip.text = "Time left until compromised:";
        }
    }
}
