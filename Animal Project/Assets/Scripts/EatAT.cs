using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {



		//to get the bbparameter
        public BBParameter<Transform> foodTransform;
		public BBParameter<float> energy;



		//to get the animation 
        public float animationTimer;
        private float resetTimer;




		//For the play sound
        private AudioSource audioSource;
		public AudioClip eatingSound;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            //get reference to component

            audioSource = agent.GetComponent<AudioSource>();


			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {


	

			resetTimer = animationTimer;

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            resetTimer -= Time.deltaTime;
			//to play the sound and then move on to the next task (time based)
			if (resetTimer <= 0)
			{
				audioSource.PlayOneShot(eatingSound);
				//Destroy the food object the duck is nearest to
                GameObject.Destroy(foodTransform.value.gameObject);
				energy.value += 10;
				EndAction(true);
            }





        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}