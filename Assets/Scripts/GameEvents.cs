using System;

public static class GameEvents
{
    public static event Action<Enemy> OnEnemyHit = null;
    public static event Action<Enemy> OnEnemyDied = null;
    public static event Action<int> OnScoreChange = null;

    public static void ReportEnemyHit(Enemy _enemy)
    {
        OnEnemyHit?.Invoke(_enemy);
    }

    public static void ReportEnemyDied(Enemy _enemy)
    {
        OnEnemyDied?.Invoke(_enemy);
    }

    public static void ReportScoreChange(int _score)
    {
        OnScoreChange?.Invoke(_score);
    }
}
