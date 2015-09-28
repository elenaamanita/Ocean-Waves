using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour 
{
	public Material m_material;
	GameObject m_mesh;
	
	Chunk[,,] m_Chunk;
	
	public int m_surfaceSeed = 3, m_caveSeed = 5;
	public int m_chunksX = 5, m_chunksY = 2, m_chunksZ = 5;
	public int m_voxelWidth = 25, m_voxelHeight = 25, m_voxelLength = 25;
	public int m_chunksAbove0 = 1;
	public float m_surfaceLevel = 0.0f;

	void Start () 
	{
		//Make 2 perlin noise objects, one is used for the surface and the other for the caves
		PerlinNoise m_surfacePerlin = new PerlinNoise(m_surfaceSeed);
		PerlinNoise  m_cavePerlin = new PerlinNoise(m_caveSeed);
	
		//Set some varibles for the marching cubes plugin
		MarchingCubes.SetTarget(0.0f);
		MarchingCubes.SetWindingOrder(2, 1, 0);
		MarchingCubes.SetModeToCubes();
		
		//create a array to hold the voxel chunks
		m_Chunk  = new Chunk[m_chunksX,m_chunksY,m_chunksZ];
		
		//The offset is used to centre the terrain on the x and z axis. For the Y axis
		//we can have a certain amount of chunks above the y=0 and the rest will be below
		Vector3 offset = new Vector3(m_chunksX*m_voxelWidth*-0.5f, -(m_chunksY-m_chunksAbove0)*m_voxelHeight, m_chunksZ*m_voxelLength*-0.5f);
		
		for(int x = 0; x < m_chunksX; x++)
		{
			for(int y = 0; y < m_chunksY; y++)
			{
				for(int z = 0; z < m_chunksZ; z++)
				{
					//The position of the voxel chunk
					Vector3 pos = new Vector3(x*m_voxelWidth, y*m_voxelHeight, z*m_voxelLength);
					//Create the voxel object
					m_Chunk[x,y,z] = new Chunk(pos+offset, m_voxelWidth, m_voxelHeight, m_voxelLength, m_surfaceLevel);
					//Create the voxel data
					m_Chunk[x,y,z].CreateVoxels(m_surfacePerlin);
          
					//Smooth the voxels, is optional but I think it looks nicer
					m_Chunk[x,y,z].SmoothVoxels();
					//Create the normals. This will create smoothed normal.
					//This is optional and if not called the unsmoothed mesh normals will be used
					m_Chunk[x,y,z].CalculateNormals();
					//Creates the mesh form voxel data using the marching cubes plugin and creates the mesh collider
					m_Chunk[x,y,z].CreateMesh(m_material);
					
				}
			}
		}
		
	}	
	
}
