using Unity.VisualScripting;
using UnityEngine;

public class BossHealthbar : MonoBehaviour
{
    [SerializeField] private EnemyHealth playerHealth;
    [SerializeField] private UnityEngine.UI.Image totalhealthBar;
    [SerializeField] private UnityEngine.UI.Image currenthealthBar;

    private GameObject BossHealthBar;
    public bool dead;


    private void Awake()
    {
        BossHealthBar = GameObject.Find("BossHealthBar");
    }

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;

        if (playerHealth.currentHealth <= 0)
        {
            BossHealthBar.SetActive(false);
        }
    }
}
