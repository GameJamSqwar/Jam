using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    #region Variables

    public float Health;
    public float healthDrainOverTime;
    /*
    public float Stamina;
    public float staminaOverTime;

    public float Hunger;
    public float hungerOverTime;

    public float Thirst;
    public float thirstOverTime;
    */
    public Slider HealthBar;
    /*
    public Slider StaminaBar;
    public Slider HungerBar;
    public Slider ThirstBar;
    
    public float minAmount = 5f;
    public float sprintSpeed = 5f;
    */
    Rigidbody myBody;

    #endregion
    public GameObject scoreText;
    public Animator anim;



    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score");
        myBody = GetComponent<Rigidbody>();
        HealthBar.maxValue = Health;
        HealthBar.value = Health;
        /*
        StaminaBar.maxValue = Stamina;
        HungerBar.maxValue = Hunger;
        ThirstBar.maxValue = Thirst;
        */
    }

    
    void Update()
    {
        CalculateValues();
    }

    private void CalculateValues()
    {
        if (healthDrainOverTime != 0)
        {
            Health -= healthDrainOverTime;
        }
        /*
        Hunger -= hungerOverTime * Time.deltaTime;
        Thirst -= thirstOverTime * Time.deltaTime;

        if (Hunger <= minAmount || Thirst <= minAmount)
        {
            Health -= healthOverTime * Time.deltaTime;
            Stamina -= staminaOverTime * Time.deltaTime;
        }

        if(myBody.velocity.magnitude >= sprintSpeed && myBody.velocity.y == 0)
        {
            Stamina -= staminaOverTime * Time.deltaTime;
            Hunger -= hungerOverTime * Time.deltaTime;
            Thirst -= thirstOverTime * Time.deltaTime;
        }
        else
        {
            Stamina += staminaOverTime * Time.deltaTime;
        }
        */
        if (Health <= 0)
        {
            print("Player Has Died");
            //TODO: 
            //Go to main menu or death screen here
            scoreText.GetComponent<Score>().ResetScore();
            scoreText.GetComponent<Score>().ResetCombo();

            GetComponent<Movement>().Die();
        }

        updateUI();
    }

    private void updateUI()
    {
        Health = Mathf.Clamp(Health, 0, 100f);
        /*
        Stamina = Mathf.Clamp(Stamina, 0, 100f);
        Hunger = Mathf.Clamp(Hunger, 0, 100f);
        Thirst = Mathf.Clamp(Thirst, 0, 100f);
        */

        HealthBar.value = Health;
        /*
        StaminaBar.value = Stamina;
        HungerBar.value = Hunger;
        ThirstBar.value = Thirst;
        */
    }

    public void TakeDamage(float amnt)
    {
        Health -= amnt;
        updateUI();
    }

    public void RecieveHealth(float amnt)
    {
        Health = (Health + amnt <= 100) ? Health + amnt : 100;
    }
}
