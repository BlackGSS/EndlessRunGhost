﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem
{
	static Dictionary<Difficulties, List<Chunk>> chunkPools = new Dictionary<Difficulties, List<Chunk>>();

	static Dictionary<Difficulties, Chunk[]> chunkPrefabs = new Dictionary<Difficulties, Chunk[]>();

	private static bool initialized;

	private static int _lastPrefabIndex = 0;

	public static Chunk GetChunkFromPool(Difficulties type)
	{
		//Cargamos todos los chunks de todos los tipos en chunkPrefabs
		if (!initialized)
		{
			Initialize();
		}

		Chunk chunk = null;

		//Comprobar si la lista del tipo solicitado existe y tiene algún elemento
		if (chunkPools.ContainsKey(type) && chunkPools[type].Count > 0)
		{
			// Debug.Log(chunkPools.ContainsKey(type) + "activar chunk");
			//Si es así, devolvemos el primer elemento de esa lista y lo sacamos de la lista.
			chunk = chunkPools[type][0];
			chunkPools[type].RemoveAt(0);
			chunk.gameObject.SetActive(true);
		}
		//si no es así, instanciamos un elemento del tipo seleccionado. 
		else
		{
			// Debug.Log(chunkPools.ContainsKey(type) + "crear nuevo chunk");
			int randomChunk = RandomIndex(type);
			chunk = GameObject.Instantiate(chunkPrefabs[type][randomChunk]); //TODO: Solucionar problema de alta repetititividad en una misma partida...
		}

		return chunk;
	}

	//TODO: Averiguar por qué cuando se instancian los de dificultad MEDIUM no se activan, sino que al desactivarlos y entrar por aquí crea uno directamente sin activar el otro

	/// <summary>
	/// Cargamos los prefabs de cada tipo una sola vez 
	/// </summary>
	private static void Initialize()
	{
		//Recorremos todas las dificultades del enum Dificulties y cargamos dinámicamente todos los prefabs de cada typo. 
		foreach (Difficulties type in Enum.GetValues(typeof(Difficulties)))
		{
			// Debug.Log(type);
			Chunk[] allPrefabsOfType = Resources.LoadAll<Chunk>("Chunks/" + type);
			chunkPrefabs[type] = allPrefabsOfType;
		}

		initialized = true;
	}

	public static void AddChunkToPool(Chunk chunk)
	{
		chunk.gameObject.SetActive(false);

		Difficulties type = chunk.dificult;

		//Comprobamos si el tipo de lista existe, 
		if (!chunkPools.ContainsKey(type))
		{
			//Si no existe, hay que añadir una lista nueva al diccionario.
			chunkPools.Add(type, new List<Chunk>());
		}

		//Añadimos el elemnto a la lista y lo desactivamos. 
		chunkPools[type].Add(chunk);
	}

	private static int RandomIndex(Difficulties type)
	{
		//Si solo hay un elemento en la carpeta lo devovlemos. 
		if (chunkPrefabs[type].Length <= 1)
		{
			return 0;
		}

		//Si no devolvemos un elemnto distinto al anterior
		int randomIndex = _lastPrefabIndex;
		while (randomIndex == _lastPrefabIndex)
		{
			randomIndex = UnityEngine.Random.Range(0, chunkPrefabs[type].Length);
		}

		_lastPrefabIndex = randomIndex;
		return randomIndex;
	}

	public static void ResetChunks()
	{
		chunkPools = new Dictionary<Difficulties, List<Chunk>>();
	}
}
