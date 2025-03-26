using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float suprBalance = 100f;
    public float loanBalance = 0f;
    public float loanCollateralRatio = 5f;
    public float adEffectiveness = 1f;
    public int employees = 0;
    public int adCost = 10;
    public float collateralBalance = 0f;
    private float repaymentAmount = 0f;
    private bool isRepaying = false;
    private int adCampaigns = 0;
    private bool eligibleToBuyAd = false;

    public TextMeshProUGUI suprText;
    public TextMeshProUGUI loanText;
    public TextMeshProUGUI collatertalText;
    public TextMeshProUGUI runAdText;

    void Awake()
    {
        // Singleton pattern with DontDestroyOnLoad
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Only update UI if references exist
        if (suprText != null) suprText.text = $"SUPR: {suprBalance:F2}";
        if (loanText != null) loanText.text = $"Loan: {loanBalance:F2} SUPR";
        if (collatertalText != null) collatertalText.text = $"Collateral: {collateralBalance:F2} SUPR";
        if (runAdText != null) runAdText.text = $"Run ad campaign: {adCost:F2} SUPR";
    }

    public void TakeLoan(float amount)
    {
        float requiredCollateral = amount * loanCollateralRatio;
        if (suprBalance >= requiredCollateral)
        {
            suprBalance -= requiredCollateral;
            suprBalance += amount;
            collateralBalance = requiredCollateral;
            loanBalance += amount;

            eligibleToBuyAd = true;
            Debug.Log($"Loan taken: {amount} Supr");
        }
        else
        {
            Debug.Log("Not enough collateral!");
        }
    }

    public void RunAdCampaign()
    {
        if (suprBalance >= adCost && eligibleToBuyAd && !isRepaying)
        {
            adCampaigns += 1;
            adCost = 10 * adCampaigns * 2;
            
            suprBalance -= adCost;
            float newUsers = adCost * adEffectiveness * 0.1f;
            repaymentAmount = newUsers * 0.1f; // Calculate repayment per interval
            Debug.Log($"Ad campaign ran! New users: {newUsers}, Repayment per 10s: {repaymentAmount}");

            // Start repayment coroutine if not already running
            if (!isRepaying)
            {
                StartCoroutine(RepayLoanCoroutine());
            }
        }
    }

    private IEnumerator RepayLoanCoroutine()
    {
        isRepaying = true;
        while (loanBalance > 0 && repaymentAmount > 0)
        {
            yield return new WaitForSeconds(1f); // Wait 1 second
            loanBalance = Mathf.Max(0, loanBalance - repaymentAmount);
            suprBalance += repaymentAmount * 5;
            collateralBalance -= repaymentAmount * 5;
            Debug.Log($"Loan repaid by {repaymentAmount}. Remaining: {loanBalance}");
        }
        isRepaying = false;
        Debug.Log("Loan fully repaid or no active repayment!");
    }

    public void HireEmployee()
    {
        float cost = 100f;
        if (suprBalance >= cost)
        {
            suprBalance -= cost;
            employees++;
            adEffectiveness += 0.5f;
            Debug.Log($"Employee hired! Total: {employees}");
        }
    }
}