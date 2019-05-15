#version 330

layout(location = 0) in vec2 pos;
layout(location = 1) in vec4 colors;
layout(location = 2) in vec2 texturepos;
layout(location = 3) in float textureId;

uniform mat4 pr_matrix;
uniform mat4 modelView = mat(1.0);

out vec4 outColors;
out vec2 outTexturePos;
out float outTextureId;

void main() 
{
	gl_Position = pr_matrix * modelView * vec4(pos.xy, 1.0, 1.0);
	
	outColors = colors;
	outTexturePos = texturepos;
	outTextureId = textureId;
}