using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    public GameObject dashboardCanvas;
    //public GameObject upgradePanel;

    void Start()
    {
        dashboardCanvas.SetActive(false);
        //upgradePanel.SetActive(false);
    }

    void OnMouseDown()
    {
        dashboardCanvas.SetActive(!dashboardCanvas.activeSelf);
        //upgradePanel.SetActive(false);
    }
}