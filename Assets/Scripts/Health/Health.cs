using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    public float currentHealth { get; private set; }

    [SerializeField] Image[] healthbars;

    [HideInInspector] public int currentHealthBar;

    private Animator anim;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        currentHealthBar = healthbars.Length;

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); // Reduce Health

        if (currentHealth > 0)
        {
            // Player is Hurt
            anim.SetTrigger("hurt");
        } else
        {
            // Player is Dead
            StartCoroutine(DieAnimation(0.5f));
            
        }
    }
    public void AddHealth(float _addHealth, GameObject healthObject)
    {
        if(currentHealth < 3)
        {
            currentHealthBar = currentHealthBar + 1;
            int health = currentHealthBar - 1;
            currentHealth = Mathf.Clamp(currentHealth + _addHealth, 0, startingHealth); // Add Health
            healthbars[health].gameObject.SetActive(true);
            Destroy(healthObject);
        }

    }

    public void ReduceHealthBar()
    {
        if (currentHealthBar > 0)
        {
            int minusHealth = (currentHealthBar - 1);
            //Destroy(healthbars[minusHealth].gameObject); // Remove Heart on UI
            healthbars[minusHealth].gameObject.SetActive(false);
            currentHealthBar -= 1; // Reduce Health
        }
    }

    IEnumerator DieAnimation(float waitTime)
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(waitTime);
        rb2d.velocity = new Vector2(0f, 0f);
        GameObject.Find("Player").SetActive(false);
    }

}
