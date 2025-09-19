using UnityEngine;

[RequireComponent(typeof(AudioSource))]

/**
 Play audio at random Interval
*/
public class RandomAudio : MonoBehaviour
{
    public float chancesPercent = 0.1f;
    private AudioSource source;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (Random.Range(0f, 100f) < chancesPercent)
        {
            source.Play();
        }
    }
}
