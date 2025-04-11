using UnityEngine;

public class EnemyThinker : MonoBehaviour
{
    public Brain brain;

    // Update is called once per frame
    void Update()
    {
        brain.Think(this);
    }
}
