using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class VictoryCondition : MonoBehaviour
{
    public string scenePath = null;
    public delegate void OnVictoryHandler();
    public event OnVictoryHandler OnVictoru;
    private Animator animator;
    private bool isVictory = false;
    public bool IsVictory() => isVictory;
    public void VictoryEnd()
    {
        // go to next scene !
        if (!String.IsNullOrEmpty(scenePath)) SceneManager.LoadScene(scenePath);
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Check()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
            isVictory = true;
            animator.SetTrigger("Victory");
        }

    }
}
