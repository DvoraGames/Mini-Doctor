using UnityEngine;

public class DeathScript : MonoBehaviour
{
    [Header("Dependências")]
    private Animator animator;
    private AudioSource audioSource;
    private AudioClip soundClip;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        soundClip = audioSource.clip;
    }

    public void ExplosionSound()
    {
        audioSource.PlayOneShot(soundClip);
    }

    public void Destroy()
    {
        Destroy(gameObject);
        UIScript.score += 10;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Die");
        }
    }
}
