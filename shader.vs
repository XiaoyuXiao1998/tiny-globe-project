#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNorm;
layout (location = 2) in vec2 aTexCoord;

out vec3 Normal;
out vec2 TexCoord;
out vec3 FragPos;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
	gl_Position =projection * view *model* vec4(-aPos.x,aPos.z,aPos.y, 1.0);
	Normal = mat3(transpose(inverse(model))) * vec3(-aNorm.x,aNorm.z,aNorm.y);
	FragPos = vec3(model * vec4(-aPos.x,aPos.z,aPos.y,1.0));
	TexCoord = vec2(aTexCoord.x, aTexCoord.y);
}