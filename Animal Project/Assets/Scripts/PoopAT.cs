using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PoopAT : ActionTask {

		//To give the poop prefab
		public GameObject poop;
		//Offset from agent for poop to spawn
		private Vector3 poopOffset;

		//for Audio
        private AudioSource audioSource;
        public AudioClip poopSound;


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


			//Instantiate the poop
			GameObject.Instantiate(poop, agent.transform.position - poopOffset, Quaternion.identity);
			//play the poop sound
			audioSource.PlayOneShot(poopSound);
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//Update the poop offset to always be behind the duck
			poopOffset = new Vector3(agent.transform.position.x, agent.transform.position.y, agent.transform.position.z - 1);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}