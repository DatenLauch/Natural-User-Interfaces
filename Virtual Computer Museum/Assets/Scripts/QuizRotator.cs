using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizRotator : MonoBehaviour
{

    [SerializeField] Vector3 spin;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        spin = new Vector3 (0, 5, 0);
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spin * speed * Time.deltaTime);
    }
}
