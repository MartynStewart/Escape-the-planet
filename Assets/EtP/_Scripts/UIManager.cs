using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]    Text seedText = default;
    [SerializeField]    Text timerText = default;
    [SerializeField]    Text counterText = default;
    [SerializeField]    Text zoneText = default;


    public void UpdateScore(int Score) {
        counterText.text = $"x {Score}"; 
    }

    public void UpdateZone(Zone newZone) {
        zoneText.text = newZone.name;
        SetUiColour(newZone.zoneColour);
        seedText.text = $"Current Seed:\n {newZone.GetZoneSeed()}";
    }

    public void SetUiColour(Color newColour) {
        seedText.color = newColour;
        timerText.color = newColour;
        counterText.color = newColour;
        zoneText.color = newColour;
    }

}
