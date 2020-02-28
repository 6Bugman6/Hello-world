 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Text countText;
    public Text winText;
    public float speed;
    public float jump;
    public int PickUpsNumber;

    private Rigidbody rb;
    private AudioSource ausur, ausur2;
    private int count;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        count = 0;
        ausur2 = GetComponent<AudioSource>();
        setCountText();
        winText.text = "";
    }
   
    void FixedUpdate () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        float Jump = 0.0f;
        if (rb.velocity.y <= 0.01 && rb.velocity.y >= -0.01) if (Input.GetButtonDown("Jump"))
            {
                ausur2.Play();
                Jump = jump * 10; }
        Vector3 movment = new Vector3(moveHorizontal,Jump,moveVertical);
        rb.AddForce(movment * speed);
        transform.Rotate(new Vector3(-transform.rotation.x, 0, -transform.rotation.z)*100);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pick Up"))
        {
            ausur = other.GetComponent<AudioSource>();
            ausur.Play();
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            if (count >= PickUpsNumber) winText.text = "You Win!";
        }
    }
    void setCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}
