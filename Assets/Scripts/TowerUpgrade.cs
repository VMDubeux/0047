using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public Turret turret; // Referência ao script da torre para atualizar

    public float upgradeRangeAmount = 5f; // Aumento do alcance do upgrade

    public void UpgradeTowerRange()
    {
        turret.range += upgradeRangeAmount; // Aumenta o alcance da torre
        Debug.Log("Tower range upgraded! New range: " + turret.range);
    }
}
