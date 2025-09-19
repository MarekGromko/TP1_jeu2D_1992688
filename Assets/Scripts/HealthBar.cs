using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
/**
 Control when and how the health bar is shown
*/
public class HealthBar : MonoBehaviour
{
    public int TimeOnScreen = 400;
    public int TimeFading = 150;
    public HealthState hp;
    private SpriteRenderer sr;
    private int alarm = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        hp.OnDamage += OnDamage;
    }

    void OnDamage(int d, Transform _)
    {
        var scl = (float)hp.CurrentHealth() / (float)hp.baseHealth;
        transform.localScale = new Vector3(scl, transform.localScale.y, transform.localScale.z);
        alarm = TimeOnScreen + TimeFading;
    }

    void FixedUpdate()
    {
        alarm = Math.Max(0, alarm - 1);
        var color = new Color(sr.color.r, sr.color.g, sr.color.b,
            Math.Min(1f, (float)alarm/(float)TimeFading)
        );
        sr.color = color;
    }
}
