using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

#if ENABLE_INPUT_SYSTEM

using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{


	public class StarterAssetsInputs : MonoBehaviour
	{
		public GameObject winPanel;
		public GameObject losePanel;
		public int vida;
		public Text texto;


		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;
		public bool lookFromTouch;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		[Header("Shooting Settings")]
		public GameObject proyectilePrefab;
		public Transform proyectileSpawnPoint;
		public float velocidadBalas;




#if ENABLE_INPUT_SYSTEM


		private void Start()
		{


		}

		private void Update()
		{
			texto.text = ("Vida: " + vida);
		}
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if (cursorInputForLook)
			{
				lookFromTouch = false;
				LookInput(value.Get<Vector2>());
			}
		}


		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnShoot()
		{
			Debug.Log("Click detectado.");
			RealizarDisparo();


		}
#endif



		private void RealizarDisparo()
		{
			Debug.Log("El disparo deberia estar ocurriendo.");

			GameObject newProjectile = Instantiate(proyectilePrefab, proyectileSpawnPoint.position + transform.forward, transform.rotation);

			newProjectile.GetComponent<Rigidbody>().AddForce(proyectileSpawnPoint.up * velocidadBalas, ForceMode.Impulse);

			Destroy(newProjectile, 5f);

		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Item"))
			{
				Destroy(other.gameObject);
				winPanel.SetActive(true);
				Time.timeScale = 0f;

			}
			if (other.CompareTag("Enemy"))
			{

				vida = vida - 25; 

				if (vida <= 0)
				{
					Destroy(other.gameObject);
					losePanel.SetActive(true);
					Time.timeScale = 0f;
				}
                

            }
            /*private void OnCollisionEnter(Collision collision)
            {

                if (collision.gameObject.CompareTag("Enemy"))
                {
                    Destroy(collision.gameObject);


                    losePanel.SetActive(true);


                }
                if (collision.gameObject.CompareTag("Collision"))
                {
                    Time.timeScale = 0f;

                    losePanel.SetActive(true);
                }


            }
            */

        }
	}
}
