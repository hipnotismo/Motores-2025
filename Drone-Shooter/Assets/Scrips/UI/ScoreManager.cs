using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] TextMeshProUGUI civiliansToSave;
    [SerializeField] TextMeshProUGUI civiliansLost;

    private int saveScore = 0;
    private int loseScore = 0;

    private string save = "Civilians saved: ";
    private string lost = "Civilians lost: ";

    void Start()
    {
        
    }
    void Update()
    {
        civiliansToSave.text = save + saveScore.ToString();
        civiliansLost.text = lost + loseScore.ToString();

    }

    public void IncreaseSave()
    {
        saveScore++;
    }

    public void IncreaseLost()
    {
        loseScore++;
    }
}
