using UnityEngine;
using UnityEditor;
using Codice.CM.SEIDInfo;
using Unity.VisualScripting;

public class MeshColliderCreator : EditorWindow {
 
	[MenuItem("Mesh/Create Mesh in Children", false, 2000)] static void OpenWindow () {
 
		EditorWindow.GetWindow<MeshColliderCreator>(true);
	}
 
	void OnGUI () {
		if(GUILayout.Button("Create Terrain")){
 
			if(Selection.activeGameObject == null){
 
				EditorUtility.DisplayDialog("No object selected", "Please select an object.", "Ok");
				return;
			}
 
			else{
 
				CreateTerrain();
			}
		}
	}
 
	delegate void CleanUp();
 
	void CreateTerrain(){	
		GameObject selected = Selection.activeGameObject;

		foreach(Transform child in selected.transform)
		{
			if(child.GetComponent<SkinnedMeshRenderer>() == null)
			{
				continue;
			}

			if(child.GetComponent<MeshCollider>() == null)
			{
				child.AddComponent<MeshCollider>();
			}
			Mesh skinnedMesh = child.GetComponent<SkinnedMeshRenderer>().sharedMesh;
			child.GetComponent<MeshCollider>().sharedMesh = skinnedMesh;
		}
	}
}