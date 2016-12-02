using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonoSingleton<T> : MonoBehaviour where T : Component {
	private static T instance = null;
	private static bool isExiting = false;

	public static T Instance {
		get {
			if(instance != null)
				return instance;
			else if(instance == null && !isExiting) {
				GameObject newManager = new GameObject(string.Empty);
				instance = newManager.AddComponent<T>();
				instance.name = "_Singleton" + instance.GetComponent<T>().ToString();
				return instance;
			}
			return null;
		}
	}

	#region MonoBehaviour
	public virtual void Awake() {
		VerifySingleton();
		DontDestroyOnLoad(gameObject);
	}

	void OnApplicationQuit() {
		isExiting = true;
	}
	#endregion

	protected void VerifySingleton() {
		List<T> instanceList = new List<T>();

		// Ensure there are no duplicates
		if(instance != null) {
			Destroy(gameObject);
		}

		instanceList.AddRange(FindObjectsOfType<T>());

		// Not sure which instance should be the singleton.
		if(instanceList.Count > 1 && instance == null) {
			Debug.LogError("Multiple instances of a singleton exists, not sure which to set reference.", this);
			Debug.Break();
		}

		// If this is the only instance
		if(instanceList.Count == 1 && instance == null) {
			instance = this as T;
		}
	}

	public void UnloadSingleton(bool objToRemove) {
		string unloadMessage = (objToRemove)
			? name + " reference was unloaded."
			: name + " reference was unloaded and destroyed.";
		Debug.Log(unloadMessage);
		instance = null;
		if(objToRemove) {
			Destroy(gameObject);
		}
	}
}