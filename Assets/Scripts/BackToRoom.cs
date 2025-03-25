using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToRoom : MonoBehaviour
{
    public void ReturnToRoom()
    {
        SceneManager.LoadScene("RoomScene");
    }
}