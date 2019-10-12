using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    private GameManager instance;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text totalTxt;
    [SerializeField] private Text timerTxt;
    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        if(null != timerTxt)
        {
            timerTxt.text = instance.killTimer.ToString();
        }
        if(null != totalTxt)
        {
            totalTxt.text = "total";
        }
        scoreTxt.text = "score";
    }
    private void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            Restart();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Destroy(instance.gameObject);
    }

}
