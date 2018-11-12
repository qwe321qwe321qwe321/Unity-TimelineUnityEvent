using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;

namespace TimelineUnityEvents {
	[Serializable]
	public class TimelineUnityEventBehaviour : PlayableBehaviour {
		/// <summary>
		/// The binding object on which events are invoked
		/// </summary>
		public TimelineUnityEventBindings TargetBindings;
		public TimelineUnityEventClip clip;


		public override void OnBehaviourPlay(Playable playable, FrameData info) {
			// Only invoke if time has passed to avoid invoking
			// repeatedly after resume
			if ((info.frameId == 0) || (info.deltaTime >= 0)) {
				if(TargetBindings != null) {
					TargetBindings.InvokeEvents(clip);
				}
			}
		}
	}
}