using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    [System.Serializable]
    public class AudioDetail
    {
        public AudioClip clip;
        public float volume = 1;
    }
    public AudioDetail death;
    public AudioDetail damage;
    public AudioDetail swoosh;
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayDeath() {
        if (death.clip) audioSource.PlayOneShot(death.clip, death.volume*audioSource.volume);
    }
    public void PlayDamage() {
        if (damage.clip) audioSource.PlayOneShot(damage.clip, damage.volume*audioSource.volume);
    }
    public void PlaySwoosh() {
         if (swoosh.clip) audioSource.PlayOneShot(swoosh.clip, swoosh.volume*audioSource.volume);
    }
}
