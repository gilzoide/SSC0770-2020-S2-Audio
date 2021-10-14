using UnityEngine;

public class PlayerBerro : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;

    void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Berra");
        }
    }

    public void Berra()
    {
        audioSource.Play();
    }
}
