using UnityEngine;
using UnityEngine.Events;

public class CollectibleManager : MonoBehaviour
{
    public int coinCount { get; private set; } = 0;

    public UnityEvent<int> OnCoinCountChanged;

    public void RegisterPlayer(PlayerController player)
    {
        player.OnCollectedCoin += CollectCoin;
    }

    private void CollectCoin()
    {
        coinCount++;
        OnCoinCountChanged?.Invoke(coinCount);
    }
}
