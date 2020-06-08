using UnityEngine.SceneManagement;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] allButtons;

    private int usedPowerCount;

    public void UsePower()
    {
        usedPowerCount++;
        if(usedPowerCount == 3)
        {
            DeactivateAllButtons();
        }
    }

    public void DeactivateAllButtons()
    {
        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].SetActive(false);
        }
    }

    public void HandleFinishButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
