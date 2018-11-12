using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TimelineUnityEvents {
	public class TimelineUnityEventBindings : MonoBehaviour {
		[SerializeField]
		private List<TimelineUnityEventClip> eventKeyTable = new List<TimelineUnityEventClip>();
		[SerializeField]
		private List<UnityEvent> eventValueTable = new List<UnityEvent>();

		public void AddEvent(TimelineUnityEventClip clip) {
			ClearNullElements();
			if (eventKeyTable.IndexOf(clip) != -1) { // If Exist then return.
				return;
			}
			eventKeyTable.Add(clip);
			eventValueTable.Add(new UnityEvent());
		}

		public void RemoveEvent(TimelineUnityEventClip clip) {
			ClearNullElements();
			int found = eventKeyTable.IndexOf(clip);
			if (found != -1) {
				eventKeyTable.RemoveAt(found);
				eventValueTable.RemoveAt(found);
			}
		}
		// Invoke Events.
		public void InvokeEvents(TimelineUnityEventClip clip) {
			int found = eventKeyTable.IndexOf(clip);
			if (found != -1) {
				eventValueTable[found].Invoke();
			}
		}
		// Get index
		public int IndexOfEvents(TimelineUnityEventClip clip) {
			ClearNullElements();
			return eventKeyTable.IndexOf(clip);
		}
		// Remove all of null elements.
		public void ClearNullElements() {
			for (int i = 0; i < eventKeyTable.Count; i++) {
				if (eventKeyTable[i] == null) {
					eventKeyTable.RemoveAt(i);
					eventValueTable.RemoveAt(i);
					i -= 1;
				}
			}
		}
		// Remove all of non-binding elements
		public void ClearNonBindingElements() {
			for (int i = 0; i < eventKeyTable.Count; i++) {
				if (eventKeyTable[i].TrackTargetBindings && !eventKeyTable[i].IsBinding(this)) {
					eventKeyTable.RemoveAt(i);
					eventValueTable.RemoveAt(i);
					i -= 1;
				}
			}
		}
	}
}
