using UnityEngine;

public class BackToRoom : MonoBehaviour
{
    public GameObject dashboardCanvas;
    public GameObject room;
    void OnMouseDown()
    {
        room.SetActive(true);
        dashboardCanvas.SetActive(false);
    }
}