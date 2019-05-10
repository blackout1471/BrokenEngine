# BrokenEngine
A start on a 2d game engine.
This engine is a hobby project and will be developed for educational use only. The engine will use the pattern ECS (Entity-Component System)
Which requires the engine to have entities where the systems can interact with each other, and the system will handle all the render states and physics related stuff.
The engine will implement ecs because this will fix the issue with inheritance. So the entities will have components with data, and the systems will handle the data.

## Libraries
The Engine will use the libraries

Glfw net: https://github.com/luca-piccioni/OpenGL.Net

OpenGl Net: https://github.com/luca-piccioni/OpenGL.Net

Glfw Dll: https://www.glfw.org/

## TODO:
### Application Layer
- [x] Window
- [x] Input / Event system
### Graphics
- [ ] Textures
- [ ] TextureManager
- [ ] Texture Array Object
### Systems
- [x] System Manager
- [ ] Shaders
- [ ] BatchRenderer
- [ ] BasicRenderer
- [ ] Collision system between 2 entities
- [ ] Collision system for all entities
- [x] Vao(Vertex Array Object) Buffer
- [x] Vbo(Vertex Buffer Object) Buffer
- [x] Ibo(Index Buffer Object) Buffer
### Components
- [ ] Components
- [ ] Entities
- [ ] EntityManager
### Maths
- [x] Vectors
- [x] Matrices
### Utilities
- [x] File utilities
- [x] Shader utilities
- [x] Debug utilities
### Core
- [ ] Core abstraction
- [x] Time module
## Uml
![alt text](https://github.com/blackout1471/BrokenEngine/blob/master/BrokenEngine.jpg "Uml")
