using UnityEngine;
using UnityEngine.SceneManagement;


public class LifeManager : MonoBehaviour
{
    [Header("Dependências")]
    private Animator animator;
    private AudioSource audioSource;
    private AudioClip soundClip;

    [Header("Vida Config")]
    public int lifes;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        soundClip = audioSource.clip;

        lifes = 1;
    }

    private void Update()
    {
        if (lifes == 0)
        {
            animator.SetTrigger("Died");
        }
    }

    public void ExplosionSound()
    {
        audioSource.PlayOneShot(soundClip);
    }

    public void Destroy()
    {
        Destroy(gameObject);
        PlayerPrefs.SetInt("highest", UIScript.highestScore);
        SceneManager.LoadScene("GameOver");
    }
}