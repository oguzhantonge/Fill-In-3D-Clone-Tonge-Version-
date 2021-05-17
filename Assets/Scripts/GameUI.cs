using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public Image levelSlider;
    public Image currentLevelImage;
    public Image nextLevelImage;
    public Text currentLevelText, nextLevelText;

    public void LevelSliderFill(float fillAmount)
    {
        levelSlider.fillAmount = fillAmount; 
    }

    public void ChangeCurrentLevelText(int level)
    {
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }

   

}
