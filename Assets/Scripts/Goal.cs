using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public AudioClip clip;
    public GameObject img;

    private AudioSource audioSource;
    private int score;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puk"))
        {
            audioSource.PlayOneShot(clip);
            scoreText.text = (++score).ToString("D2");
            ++score;
            collision.transform.position = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            img.SetActive(true);
            Invoke("Ding", 0.5f);
        }
    }

    private void Ding()
    {
        img.SetActive(false);
    }

}
