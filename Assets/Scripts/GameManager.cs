using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LoanManager loanManager;
    public AdManager adManager;
    public UpgradeManager upgradeManager;
    public float dayLength = 30f; // 1 day = 30 seconds
    private float dayTimer = 0f;

    void Start()
    {
        // Ensure components are assigned in Inspector or find them
        if (!loanManager) loanManager = GetComponent<LoanManager>();
        if (!adManager) adManager = GetComponent<AdManager>();
        if (!upgradeManager) upgradeManager = GetComponent<UpgradeManager>();
    }

    void Update()
    {
        // Simple day timer
        dayTimer += Time.deltaTime;
        if (dayTimer >= dayLength)
        {
            dayTimer = 0f;
            ProgressDay();
        }

        // Check level up
        GetComponent<PlayerData>().CheckLevelUp();
    }

    void ProgressDay()
    {
        if (PlayerData.daysToRepay > 0)
        {
            PlayerData.daysToRepay--;
            Debug.Log($"Day passed. Loan due in {PlayerData.daysToRepay} days.");
            if (PlayerData.daysToRepay <= 0)
            {
                Debug.Log("Loan overdue! Credit damaged.");
                PlayerData.loanAmount = 0; // Reset for simplicity (add penalties later)
            }
        }
    }

    // Example methods to hook to UI buttons
    public void TestLoan() { loanManager.TakeLoan(1000, 0.05f); }
    public void TestAd() { adManager.LaunchAd(500, 0.5f, 1.0f); }
    public void TestUpgrade() { upgradeManager.BuyUpgrade(1); }
}