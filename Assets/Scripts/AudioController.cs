using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource death;
    public AudioSource damage;
    public AudioSource swoosh;
    public void PlayDeath() => death.Play();
    public void PlayDamage() => damage.Play();
    public void PlaySwoosh() => swoosh.Play();
}
