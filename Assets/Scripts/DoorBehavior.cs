using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    Animator animator;
    AudioSource sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Open", true);
        sound.PlayDelayed(0.1f);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Open", false);
        sound.PlayDelayed(0.2f);
    }
}
