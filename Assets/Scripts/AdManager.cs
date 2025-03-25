using UnityEngine;

public class AdManager : MonoBehaviour
{
    public int LaunchAd(int budget, float quality, float employeeBoost)
    {
        if (PlayerData.suprBalance < budget)
        {
            Debug.Log("Not enough Supr for this campaign!");
            return 0;
        }

        PlayerData.suprBalance -= budget;
        float baseBuyers = budget / 100f; // S$100 = 1 buyer baseline
        int newBuyers = Mathf.RoundToInt(baseBuyers * quality * employeeBoost * Random.Range(0.8f, 1.2f));
        
        PlayerData.totalBuyers += newBuyers;
        int revenue = newBuyers * 15; // S$15 per buyer
        PlayerData.suprBalance += revenue;
        PlayerData.xp += newBuyers; // 1 XP per buyer
        
        Debug.Log($"Ad Campaign: Cost S${budget}, New Buyers: {newBuyers}, Revenue: S${revenue}");
        return newBuyers;
    }
}