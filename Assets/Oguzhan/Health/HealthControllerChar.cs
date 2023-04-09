using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerChar : MonoBehaviour
{
    public static int charHealth;
    public HealthBar charHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        charHealth = 100;
        charHealthBar.SetMaxHealth(charHealth);
        charHealthBar.Set_health(charHealth);

    }

    // Update is called once per frame
    void Update()
    {
        charHealthBar.Set_health(charHealth);
    }
}
