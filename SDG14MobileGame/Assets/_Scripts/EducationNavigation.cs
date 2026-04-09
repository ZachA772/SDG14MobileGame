using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationNavigation : MonoBehaviour
{
    [Header("Education Navigation")]
    //Reference to each explanation game object
    [SerializeField] private GameObject PlayerMovement;
    [SerializeField] private GameObject PlayerShoot;
    [SerializeField] private GameObject EnemyBehaviour;
    [SerializeField] private GameObject CollisionDetection;
    [SerializeField] private GameObject SceneChanging;
    private int screenshotCounter = 0;

    private void Start()
    {
        UpdateEducationScreen();
    }

    //Advances through education objects
    public void NextButton()
    {
        if (screenshotCounter < 4)
        {
            screenshotCounter++;
            UpdateEducationScreen();
        }
    }

    //Moves back through education objects
    public void PreviousButton()
    {
        if (screenshotCounter > 0)
        {
            screenshotCounter--;
            UpdateEducationScreen();
        }
    }

    private void UpdateEducationScreen()
    {
        //Disable all screens first
        PlayerMovement.SetActive(false);
        PlayerShoot.SetActive(false);
        EnemyBehaviour.SetActive(false);
        CollisionDetection.SetActive(false);
        SceneChanging.SetActive(false);

        //Enable the correct screen
        switch (screenshotCounter)
        {
            case 0:
                PlayerMovement.SetActive(true);
                break;
            case 1:
                PlayerShoot.SetActive(true);
                break;
            case 2:
                EnemyBehaviour.SetActive(true);
                break;
            case 3:
                CollisionDetection.SetActive(true);
                break;
            case 4:
                SceneChanging.SetActive(true);
                break;
        }
    }
}
