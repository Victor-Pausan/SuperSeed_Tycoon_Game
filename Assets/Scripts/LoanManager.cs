using UnityEngine;

public class LoanManager : MonoBehaviour
{
    public float TakeLoan(int amount, float interest)
    {
        if (PlayerData.loanAmount > 0)
        {
            Debug.Log("You already have an active loan!");
            return 0f;
        }

        PlayerData.suprBalance += amount;
        PlayerData.loanAmount = amount;
        PlayerData.loanInterest = interest;
        PlayerData.daysToRepay = 30;

        float totalRepay = amount * (1 + interest);
        Debug.Log($"Loan Taken: S${amount}, Total to Repay: S${totalRepay}, Due in {PlayerData.daysToRepay} days");
        return totalRepay;
    }

    public void RepayLoan(int amount)
    {
        if (PlayerData.suprBalance >= amount && PlayerData.loanAmount > 0)
        {
            PlayerData.suprBalance -= amount;
            PlayerData.loanAmount -= amount;
            if (PlayerData.loanAmount <= 0)
            {
                PlayerData.loanAmount = 0;
                PlayerData.loanInterest = 0f;
                PlayerData.daysToRepay = 0;
                Debug.Log("Loan fully repaid!");
            }
            else
            {
                Debug.Log($"Repaid S${amount}. Remaining debt: S${PlayerData.loanAmount}");
            }
        }
        else
        {
            Debug.Log("Not enough Supr to repay or no loan active!");
        }
    }
}