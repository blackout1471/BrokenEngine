#version 330

in vec4 outColors;
in vec2 outTexturePos;
in float outTextureId;

uniform sampler2DArray textureArray;

void main() 
{
	vec4 finalColor = outColors;

	if (outTextureId != 1024) {
		finalColor *= texture(textureArray, vec3(outTexturePos.xy, outTextureId));
	}

	gl_FragColor = finalColor;
}
