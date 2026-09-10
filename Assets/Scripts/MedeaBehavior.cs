
using UnityEngine;

public class MedeaBehavior : MonoBehaviour
{
    public GameObject Player;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < 8) {
            if(Input.GetKeyDown(KeyCode.E))
                if (!animator.GetBool("Talking"))
                    animator.SetBool("Talking", true);
        }
        else
        {
            if (animator.GetBool("Talking"))
                animator.SetBool("Talking", false);
        }
    }
}
