using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class InputCT : ConditionTask {

		//to set the desired input
		public KeyCode[] inputValue;  





		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {




			//Thank you again for this code, I understand the gist of it.
		
            bool movementInput = false;

			//goes throught the list of possible input
            for (int i = 0; i < inputValue.Length; i++)
            {
				//check for specific input (the public one)
                if (Input.GetKeyDown(inputValue[i]))
                {
                    movementInput = true;
                }
            }
            return movementInput;



          
		}
	}
}