using UnityEngine;
using UnityEditor;

namespace TimelineUnityEvents {
	[CustomEditor(typeof(TimelineUnityEventBindings))]
	public class TimelineUnityEventBindingsEditor : Editor {
		public override void OnInspectorGUI() {
			var targetBindings = target as TimelineUnityEventBindings;
			if (GUILayout.Button(new GUIContent("Clear non-binding elements"))) {
				Undo.RecordObject(target, "Clear non-binding elements");
				targetBindings.ClearNonBindingElements();
			}
			base.OnInspectorGUI();
		}
	}
}
