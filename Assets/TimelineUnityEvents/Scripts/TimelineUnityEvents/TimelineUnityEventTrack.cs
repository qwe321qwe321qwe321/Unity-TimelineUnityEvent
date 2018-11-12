using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineUnityEvents {
    [TrackColor(1f, 0.392156f, 0.1215686f)]
    [TrackClipType(typeof(TimelineUnityEventClip))]
    [TrackBindingType(typeof(TimelineUnityEventBindings))]
    public class TimelineUnityEventTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var director = go.GetComponent<PlayableDirector>();
            var trackTargetObject = director.GetGenericBinding(this) as TimelineUnityEventBindings;
			if (trackTargetObject == null) {
				trackTargetObject = go.GetComponent<TimelineUnityEventBindings>();
				if(trackTargetObject == null) {
					Debug.Log("Create UnityEventBindings compoent.");
					trackTargetObject = go.AddComponent<TimelineUnityEventBindings>();
				}
				director.SetGenericBinding(this, trackTargetObject);
			}
            foreach (var clip in GetClips())
            {
                var playableAsset = clip.asset as TimelineUnityEventClip;
                if (playableAsset)
                {
					if (trackTargetObject)
					{
						playableAsset.TrackTargetBindings = trackTargetObject;
					}
                }
            }

            var scriptPlayable = ScriptPlayable<TimelineUnityEventMixerBehaviour>.Create(graph, inputCount);
            return scriptPlayable;
        }
    }
}