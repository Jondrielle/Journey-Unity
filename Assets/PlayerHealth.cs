using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Rigidbody2D player;
    private float health = 100f;
    public Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        healthbar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
