using UnityEngine;

public abstract class Brain : ScriptableObject
{
    public abstract void Think(EnemyThinker thinker);
}
