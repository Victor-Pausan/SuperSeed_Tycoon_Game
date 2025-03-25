using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int suprBalance = 0;           // Currency in Supr (S$)
    public static int loanAmount = 0;            // Current loan debt
    public static float loanInterest = 0f;       // Interest rate of current loan
    public static int daysToRepay = 0;           // Days left to repay loan
    public static int totalBuyers = 0;           // Total Supr buyers
    public static int level = 1;                 // Player level
    public static int xp = 0;                    // Experience points

    void Start()
    {
        // Reset values for testing (optional: load from PlayerPrefs later)
        suprBalance = 0;
        loanAmount = 0;
        loanInterest = 0f;
        daysToRepay = 0;
        totalBuyers = 0;
        level = 1;
        xp = 0;
    }

    // Simple level-up check based on XP
    public void CheckLevelUp()
    {
        int xpNeeded = level * 100; // 100 XP per level
        if (xp >= xpNeeded)
        {
            level++;
            xp -= xpNeeded;
            Debug.Log("Level Up! New Level: " + level);
        }
    }
}