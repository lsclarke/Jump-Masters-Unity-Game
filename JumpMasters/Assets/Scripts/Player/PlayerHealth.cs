using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    private PlayerMovement movement;
    [SerializeField] public float strength;
    [SerializeField] public float duration;
    [HideInInspector] public bool isKnockedBack = false;
    private void Start()
    {
        movement = this.GetComponent<PlayerMovement>();
    }

    public void TakeDamage(GameObject other)
    {
        StopAllCoroutines();
        isKnockedBack = true;
        movement.enabled = false;
        Health -= 1;
        Vector2 direction = (transform.position - other.transform.position).normalized;
        movement.physics.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(StopKnockBack(duration));
    }
    public IEnumerator StopKnockBack(float time)
    {
        yield return new WaitForSeconds(time);
        isKnockedBack = false;
        movement.enabled = true;

        movement.physics.linearVelocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("TAKE DAMAGE - Tag (trigger)");
            TakeDamage(collision.gameObject);
        }
    }
}
