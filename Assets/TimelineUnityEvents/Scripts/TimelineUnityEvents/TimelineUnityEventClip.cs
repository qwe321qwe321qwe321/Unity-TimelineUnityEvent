using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineUnityEvents {
    [Serializable]
    public class TimelineUnityEventClip : PlayableAsset, ITimelineClipAsset
    {
        public TimelineUnityEventBehaviour template = new TimelineUnityEventBehaviour();
        public TimelineUnityEventBindings TrackTargetBindings { get; set; }

        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TimelineUnityEventBehaviour>.Create(graph, template);
            TimelineUnityEventBehaviour clone = playable.GetBehaviour();
			if (TrackTargetBindings != null) {
				clone.TargetBindings = TrackTargetBindings;
				clone.clip = this;
				clone.TargetBindings.AddEvent(this);
			}
			return playable;
        }
		// Check if the clip is still binding.
		public bool IsBinding(TimelineUnityEventBindings bindings) {
			return this.TrackTargetBindings == bindings;
		}
    }
}