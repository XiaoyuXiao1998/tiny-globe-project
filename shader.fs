#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec2 TexCoord;
in vec3 FragPos;

struct Material{
	sampler2D diffuse;
	vec3 specular;
	float shininess;
};

struct Light{
	vec3 position;
	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};
uniform vec3 viewPos;
uniform Material material;
uniform Light light;




void main()
{
	//ambinet;
	vec3 ambient = light.ambient *texture(material.diffuse,TexCoord).rgb;

	//diffuse
	vec3 norm = normalize(Normal);
	vec3 lightdir = normalize(light.position - FragPos);
	float diff = max(dot(norm,lightdir),0.0);
	vec3 diffuse = light.diffuse*diff*texture(material.diffuse,TexCoord).rgb;

	//specular
	vec3 viewdir = normalize(viewPos-FragPos);
	vec3 reflectDir = reflect(-lightdir,norm);
	float spec = pow(max(dot(viewdir,reflectDir),0),material.shininess);
	vec3 specular =light.specular * (spec*material.specular);

	vec3 result = ambient + specular + diffuse;
	FragColor = vec4(result,1.0);
}