using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthBarText;
    public Health characterHealth;
    public GameObject fillArea;

    void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (healthBar.value == 0)
        {
            if (fillArea.activeSelf) fillArea.SetActive(false);
            return;
        }
        if (characterHealth.body)
        {
            healthBar.maxValue = characterHealth.MaxHP;
            healthBarText.text = $"{characterHealth.currentHP}/{characterHealth.MaxHP}";
        }
        else
        {
            healthBar.maxValue = characterHealth.maxHP;
            healthBarText.text = $"{characterHealth.currentHP}/{characterHealth.maxHP}";
        }
        healthBar.value = characterHealth.currentHP;

    }

}
