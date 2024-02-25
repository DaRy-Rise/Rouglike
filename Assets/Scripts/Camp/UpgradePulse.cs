using UnityEngine;

public class UpgradePulse : MonoBehaviour
{
    public void Upgrade()
    {
        FindAnyObjectByType<TreeOfAbilityManager>().SetStaticPulse();
    }
}
