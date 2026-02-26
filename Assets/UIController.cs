using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject creditsUI;

    public void OpenCredits()
    {
        creditsUI.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsUI.SetActive(false);
    }
}
