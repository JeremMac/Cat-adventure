using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Potion : MonoBehaviour
{

    [SerializeField] private TMP_Text PotionNumber;

    private GameObject PlayerH;
    private Health Phealth;

    public int potion = 10;
    // Start is called before the first frame update
    private void Awake()
    { 
        PlayerH = GameObject.Find("player");
        Phealth = PlayerH.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            potion -= 1;
            Phealth.AddHealth(3);
            if (potion <= 0)
            {
                potion = 0;
            }
        }
        PotionNumber.text = potion.ToString();
    }
}
