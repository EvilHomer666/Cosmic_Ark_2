using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] float hitPoints = 1;
    [SerializeField] int scoreValue = 250;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile_Lv01")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoreManager.IncrementScore(scoreValue); // Add score
        }
    }
}
