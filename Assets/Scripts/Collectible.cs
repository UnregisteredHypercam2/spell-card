﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public string targetTag = "Player";
    private Transform target;
    public Card card;
    public float speed;

    void Awake ()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            Inventory inv = other.gameObject.GetComponent<Player>().inventory;
            card.AddToInventory(inv);
            Destroy(gameObject);
        }
    }

    void FixedUpdate ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
