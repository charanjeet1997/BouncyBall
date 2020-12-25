using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject restartPanel;
    public Text pointText;
    public int points;
    public GameObject ball;
    
    private void Start()
    {
        points = 0;
        pointText.text = "0";
    }
    public void OnEnableRestartPanel()
    {
        restartPanel.SetActive(!restartPanel.activeSelf);
        ball.SetActive(!restartPanel.activeSelf);
        if(ball.activeSelf)
        {
            ball.transform.position = Vector3.zero;
        }
    }

    public void OnResetPoints()
    {
        points = 0;
    }

    public void OnUpdatePoints()
    {
        points += 1;
        pointText.text = points.ToString();
    }
}
