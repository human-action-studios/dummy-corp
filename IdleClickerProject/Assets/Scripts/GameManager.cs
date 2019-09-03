using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //UI
    public Text currentFundsText;
    public Text incomeText;
    public Text multiplierText;

    float currentFunds;
    int funds;
    public int income;

    float spinnerMultiplier = 1f;
    int spinnerDisplayMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(720, 1280, false, 60);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
    }

    private void FixedUpdate()
    {
        //UpdateStats();
    }

    public void UpdateStats()
    {
        currentFunds += income * Time.deltaTime * spinnerDisplayMultiplier;
        funds = Mathf.RoundToInt(currentFunds);

        if (spinnerMultiplier > 1)
        {
            spinnerMultiplier -= 1 * Time.deltaTime;
            spinnerDisplayMultiplier = Mathf.RoundToInt(spinnerMultiplier);
        }

        if (spinnerMultiplier < 1)
        {
            spinnerMultiplier = 1;
        }

        UpdateHUD();
    }

    public void UpdateHUD()
    {
        currentFundsText.text = "$" + funds;
        incomeText.text = "$" + income + "/second";
        multiplierText.text = spinnerDisplayMultiplier + "x";
    }

    public void SpinnerTapped()
    {
        if (spinnerMultiplier <= 8)
        {
            spinnerMultiplier += 1;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
