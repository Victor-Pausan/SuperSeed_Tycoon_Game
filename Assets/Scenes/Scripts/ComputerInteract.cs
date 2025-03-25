using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerInteract : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Switching to MonitorScene!");
        SceneManager.LoadScene("MonitorScene");
    }
}