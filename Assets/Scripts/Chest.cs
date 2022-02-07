using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Rigidbody2D silverChest;
    public ParticleSystem effects;
    public bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        effects = GetComponent<ParticleSystem>();
        silverChest = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().SetBool("Opening", false);
        effects.Pause();
    }

    public void OpenChest()
    {
        if (isOpened == false)
        {
            GetComponent<Animator>().SetBool("Opening", true);
            isOpened = true;
            effects.Play();
        }
    }

}
