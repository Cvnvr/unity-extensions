using UnityEngine;

/* *****************************************************************************
 * File: BoundsGetter.cs
 * Author: Conor Galvin - 15/07/2020
 * Description:
 *  Unity extensions for a Transform's bounds.
 *
 * History:
 *  15/07/2020 - Created
 * ****************************************************************************/

public static class BoundsGetter
{
	/// <summary>
	///    Returns the bounds of the object.
	/// </summary>
	/// <param name="transform"> </param>
	public static Bounds GetBounds(this Transform transform)
	{
		MeshRenderer meshRenderer = transform.GetComponent<MeshRenderer>();

		if (meshRenderer == null)
		{
			Debug.LogError(string.Format("Failed to get bounds: object '{0}' doesn't have a valid MeshRenderer component.", transform.name));

			return new Bounds();
		}

		return meshRenderer.bounds;
	}

	/// <summary>
	///    Returns the bounds of all of the object's children.
	/// </summary>
	/// <param name="transform"> </param>
	public static Bounds GetBoundsOfAllChildren(this Transform transform)
	{
		MeshRenderer[] childMeshRenderers = transform.GetComponentsInChildren<MeshRenderer>();
		Bounds bounds = new Bounds();

		if (childMeshRenderers.Length != 0)
		{
			bounds = childMeshRenderers[0].bounds;

			// Encapsulate the bounds of each of the child objects
			for (int i = 1; i < childMeshRenderers.Length; i++)
			{
				bounds.Encapsulate(childMeshRenderers[i].bounds);
			}
		}

		return bounds;
	}

	/// <summary>
	///    Returns the bounds of a child object at a given index.
	/// </summary>
	/// <param name="transform"> </param>
	/// <param name="childIndex"> </param>
	public static Bounds GetBoundsOfChildAtIndex(this Transform transform, int childIndex)
	{
		// Validate the index provided
		if ((childIndex < 0) || (childIndex >= transform.childCount))
		{
			Debug.LogError(string.Format("Failed to get bounds: value '{0}' is an invalid index.", childIndex));
			return new Bounds();
		}

		MeshRenderer meshRenderer = transform.GetChild(childIndex).GetComponent<MeshRenderer>();

		return meshRenderer.bounds;
	}
}