using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public int coinsAmount;
    public static Inventory instance;
    public Text coinAmoutText;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Inventory instance duplicate");
            return;
        }

        instance = this;
    }

    public void AddCoins(int _amount)
    {
        coinsAmount += _amount;
        coinAmoutText.text = coinsAmount.ToString();

    }
}
