using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] public Health playerHealth;
    [SerializeField] private UnityEngine.UI.Image totalhealthBar;
    [SerializeField] private UnityEngine.UI.Image currenthealthBar;

    private GameObject  BossHealthbar;


    private void Awake()
    {
        BossHealthbar = GameObject.Find("BossHealthBar");
    }

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
