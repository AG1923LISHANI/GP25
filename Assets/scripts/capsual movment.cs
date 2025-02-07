using UnityEngine;
using UnityEngine.SceneManagement;

public class capsualmovment : MonoBehaviour
{
   

         private float speed = 10f;
         public Rigidbody rb;
         bool alive = true;


         float horizontalInput;
         public float horizontalMultiplier = 2f;


         public void FixedUpdate()
         {
             if (!alive) return;

             Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
             Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
             rb.MovePosition(rb.position + forwardMove + horizontalMove);
         }
         // Start is called before the first frame update
         //void Start()
         //{

         //}

         // Update is called once per frame
         void Update()
         {
             horizontalInput = Input.GetAxis("Horizontal");

             if(transform.position.y < -5)
             {
                 Die();
             }
         }

         public void Die()
         {
             alive = false;

             //Restart the game
             Invoke("Restart", 5);
         }

         public void Restart()
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
}
