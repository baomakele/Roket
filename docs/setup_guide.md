# Rocket Game Project Setup Guide

## Overview
This document provides comprehensive setup instructions for the Rocket Game project, detailing scene configuration, prefab setup, and resource creation.

## Scene Configuration
1. **Open Unity** and load the Rocket Game project.
2. **Load the Main Scene:**  
   - Navigate to the `Scenes` folder and double-click on `MainScene.unity`.
3. **Configure Game Camera:**  
   - Select the `Main Camera` object in the hierarchy.
   - Adjust the `Clear Flags` to `Skybox`, and set the appropriate `Background` color.
   - Ensure `Culling Mask` includes layers needed for the game elements.

4. **Lighting Setup:**  
   - Go to `Window -> Rendering -> Lighting`.  
   - Configure the lighting settings to add ambient light, adjust intensity, and enable baked global illumination for realistic effects.
5. **Player Spawn Point:**  
   - Create an empty GameObject named `PlayerSpawnPoint`.  
   - Position it at the desired spawn location in the scene.

## Prefab Setup
1. **Creating Player Prefab:**  
   - In the `Prefabs` folder, create a new GameObject named `Player`. 
   - Attach necessary components such as Rigidbody, Collider, and Player Movement script.
   - Save the GameObject as a prefab in the `Prefabs` folder.

2. **Creating Enemy Prefab:**  
   - Similar to the player prefab, create an `Enemy` prefab, modifying mesh and materials as necessary for unique appearances.
   - Add scripts to manage enemy behavior (AI).

3. **Environment Prefabs:**  
   - Create environment items (trees, obstacles, etc.) as prefabs for reuse.  
   - Ensure all environment objects have collider components for interactive physics.

## Resource Creation
1. **Importing Assets:**  
   - Use the Unity Asset Store or import from external sources necessary game assets (sprites, sounds, etc.).
   - Save imported assets in organized folders (e.g., `Textures`, `Audio`, `Models`).

2. **Creating Materials:**  
   - For each model, create new materials in the `Materials` folder.  
   - Assign textures to the materials and adjust properties (e.g., metallic, smoothness).

3. **Sound Effects:**  
   - Import sound files and assign them to the appropriate game events, e.g., player actions, collisions.
   - Create audio sources on relevant game objects.

## Conclusion
Following this guide will help you set up the Rocket Game project quickly and effectively. Ensure to regularly commit your changes as you progress!