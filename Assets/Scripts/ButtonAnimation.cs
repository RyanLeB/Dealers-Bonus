using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationTrigger : MonoBehaviour
{
    public Button button; 
    public Animator animator; 

    void Start()
    {
        button.onClick.AddListener(PlayAnimation);
    }

    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("PlayAnim");
        }
    }
}
