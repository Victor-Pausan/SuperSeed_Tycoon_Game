using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject[] spaces; // Array of space GameObjects (Room, Apartment, House, Mansion)
    public int[] spaceCosts = { 0, 5000, 25000, 100000 }; // Costs for each space
    private int currentSpaceIndex = 0;

    public void BuyUpgrade(int index)
    {
        if (index <= currentSpaceIndex || index >= spaces.Length)
        {
            Debug.Log("Invalid upgrade or already owned!");
            return;
        }

        int cost = spaceCosts[index];
        if (PlayerData.suprBalance >= cost)
        {
            PlayerData.suprBalance -= cost;
            spaces[currentSpaceIndex].SetActive(false); // Hide old space
            spaces[index].SetActive(true);             // Show new space
            currentSpaceIndex = index;
            Debug.Log($"Upgraded to Space {index + 1} for S${cost}");
        }
        else
        {
            Debug.Log("Not enough Supr to upgrade!");
        }
    }
}