using UnityEngine;

public class PlayerModel
{
    public int Score { get; set; }
    public int Health { get; set; }

    public PlayerModel()
    {
        Score = 0;
        Health = 100;
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void TakeDamage(int damage)
    {
        Health = Mathf.Max(0, Health - damage);
    }
}
